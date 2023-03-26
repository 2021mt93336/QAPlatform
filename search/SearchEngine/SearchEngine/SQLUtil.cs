using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SearchEngine
{
	public class SQLUtil
	{
		public static string ServerName { get; private set; }
		public static string DBName { get; private set; }
		public static string UserName { get; private set; }
		public static string Password { get; private set; }

		public static string GetSqlConnection()
        {
            ServerName = "BOMSSDEVL693\\BOMSSDEVL693";
            DBName = "sapphire";
            UserName = "sapphire";
            Password = "ZD5@n&PRcL@uCNTntb62ePbqE4bFzX";
            return String.Format("Server={0};User ID={1};Password={2};Database={3};Trusted_Connection=True;", ServerName, UserName, Password, DBName);

        }

        public static List<SearchResult> GetQuestions()
        {
            var connection = GetSqlConnection();
            var SqlUser = new SqlConnection(connection);
            List<SearchResult> questions = new List<SearchResult>();
            try
            {
                string Query;
                Query = $"SELECT [PostID],[Title] FROM Sapphire.dbo.MH_Posts";
                SqlUser.Open();
                using (var cmd = new SqlCommand(Query, SqlUser))
                {
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var question = new SearchResult()
                            {
                                id = int.Parse(reader["PostId"].ToString()),
                                question = reader["Title"].ToString()
                            };
                            questions.Add(question);
                        }
                        SqlUser.Close();
                    }
                    else
                    {
                    }
                }
                return questions;

            }
            catch (Exception ex)
            {
                SqlUser.Close();
            }
            return questions;
        }
    }
}
