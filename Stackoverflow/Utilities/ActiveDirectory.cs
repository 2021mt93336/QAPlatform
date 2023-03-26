using System;
using System.Collections.Generic;
using System.Linq;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Text.RegularExpressions;
using System.Reflection.PortableExecutable;

namespace StackOverflow.Utilities
{
    public class ActiveDirectory
    {
    }
     public abstract class ADObject
    {
        /// <summary>
        /// Object Type
        /// </summary>
        public ADObjectType ObjectType { get; protected set; }

        /// <summary>
        /// Object Name
        /// </summary>
        public string Name { get; protected set; }
    }
    class ADGroup : ADObject
    {
        /// <summary>
        /// Users in the group
        /// </summary>
        public List<ADObject> Members { get; set; }

        public ADGroup(string name)
        {
            Name = name;
            ObjectType = ADObjectType.Group;
            Members = new List<ADObject>();
        }
    }
    public enum ADObjectType
    {
        Group,
        User
    }
    public class ADUser : ADObject
    {
        public ADUser(string name)
        {
            Name = name;
            ObjectType = ADObjectType.User;
        }

        public static string GetFullName(string userName)
        {
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, userName);

            if (user != null && !string.IsNullOrEmpty(user.DisplayName))
            {
                return user.DisplayName;
            }
            else
            {
                return string.Empty;
            }
        }
    }
    public class ADManager
    {
        /// <summary>
        /// Local Active Directory Cache
        /// </summary>
        private static List<ADObject> Directory = new List<ADObject>();
        private static System.DirectoryServices.DirectoryEntry Entry = new System.DirectoryServices.DirectoryEntry();

        /// <summary>
        /// Returns list of eventual Members of the group
        /// </summary>
        /// <param name="group">Name of the group</param>
        /// <returns>List of eventual Members</returns>
        public static List<string> GetEventualMembers(string groupName)
        {
            List<string> Members = new List<string>();

            // Add the group if it is not there in the local directory otherwise get its handle
            ADGroup Group = GetGroup(groupName);

            // Add direct members
            Group.Members.Where(m => m.ObjectType == ADObjectType.User).ToList().ForEach(m =>
            {
                Members.Add(m.Name);
            });

            // Add sub group members
            foreach (ADObject member in Group.Members.Where(m => m.ObjectType == ADObjectType.Group).ToList())
            {
                Members.AddRange(GetEventualMembers(member.Name));
            }

            return Members.Distinct().ToList();
        }

        private static ADGroup GetGroup(string groupName)
        {
            // Check if the group is there in Directory Cache
            List<ADObject> Groups = Directory.Where(o => o.ObjectType == ADObjectType.Group && o.Name == groupName).ToList();

            if (Groups != null && Groups.Count > 0)
            {
                // group already exists in cache
                return (ADGroup)Groups[0];
            }
            else
            {
                // group does not exist, we need to add it to the local Directory
                ADGroup NewGroup = FetchGroupFromActiveDirectory(groupName);
                Directory.Add(NewGroup);

                return NewGroup;
            }
        }

        private static ADGroup FetchGroupFromActiveDirectory(string group)
        {
            ADGroup NewGroup = new ADGroup(group);

            // Active Directory filter query
            string Filter = string.Format("(&(cn={0})(objectClass=group))", group);

            // Properties to load
            string[] Properties = { "member" };


            DirectorySearcher Searcher = new DirectorySearcher(Entry, Filter, Properties)
            {
                PageSize = 1000
            };

            // Paging indexes
            int RangeStart = 0;
            int RangeStep = 0;
            bool Paging = false;

            // Search Active Directory
            SearchResult SearchResult = Searcher.FindOne();

            // check if group exists
            if (SearchResult == null)
            {
                // Either the group does not exist or it does not have any member
                Searcher.Dispose();
                return NewGroup;
            }

            // Identify Property String. It will be different for paging and non paging cases
            string Property = string.Empty;
            foreach (string PropertyName in SearchResult.Properties.PropertyNames)
            {
                if (Regex.Match(PropertyName, "^member;range=*").Success)
                {
                    Paging = true;
                    RangeStart = int.Parse(PropertyName.Split('=')[1].Split('-')[0]);
                    RangeStep = int.Parse(PropertyName.Split('=')[1].Split('-')[1]) - RangeStart + 1;
                    Property = PropertyName;
                }
            }

            // Set the property as "member" if no paging
            if (!Paging)
            {
                Property = Properties[0];
            }

            // Parse Search Results
            ParseSearchResults(NewGroup, SearchResult, Property);

            // Fetch Next Pages if paging is enabled
            while (Paging)
            {
                RangeStart = RangeStart + RangeStep;
                Property = string.Format("member;range={0}-{1}", RangeStart, RangeStart + RangeStep - 1);
                string[] PageProperties = new string[1];
                PageProperties[0] = Property;

                // Get Page
                DirectorySearcher PageSearcher = new DirectorySearcher(Entry, Filter, PageProperties);
                SearchResult PageSearchResult = PageSearcher.FindOne();

                if (!PageSearchResult.Properties.Contains(Property))
                {
                    // This is the last page
                    Property = string.Format("member;range={0}-{1}", RangeStart, "*");
                    Paging = false;
                }

                ParseSearchResults(NewGroup, PageSearchResult, Property);
                PageSearcher.Dispose();
            }

            // Dispose Searcher
            Searcher.Dispose();
            return NewGroup;
        }

        private static void ParseSearchResults(ADGroup group, SearchResult SearchResult, string Property)
        {
            foreach (string Value in SearchResult.Properties[Property])
            {
                // check if it is a user or sub group
                if (Value.Contains("OU=MTGroups"))
                {
                    // subgroup
                    group.Members.Add(GetGroup(Value.Split(',')[0].Split('=')[1]));
                }
                else if (Value.Contains("OU=Users") || Value.Contains("OU=LinkedMailboxes"))
                {
                    // user
                    group.Members.Add(new ADUser(Value.Split(',')[0].Split('=')[1]));
                }
            }
        }
    }
}
