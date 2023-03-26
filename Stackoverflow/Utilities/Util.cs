using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StackOverflow.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace StackOverflow.Utilities
{
    public class Util
    {
        public static IConfiguration Configuration;
        public static string connectionString;
        public static string DBName;
        public static string ServerName;
        public static string UserName;
        public static string Password;
        public static int IsUserRegistered;
        public static IHttpContextAccessor context;

        public Util(IHttpContextAccessor _context)
        {
            context = _context;
        }
        public static string ut()
        {
            return "1";
        }
        public static string GetSqlConnection() {
            ServerName = Configuration.GetSection("ServerName").Value.ToString();
            DBName = Configuration.GetSection("DBName").Value.ToString();
            UserName = Configuration.GetSection("DBUserName").Value.ToString();
            Password = Configuration.GetSection("DBPassword").Value.ToString();
            return String.Format("Server={0};User ID={1};Password={2};Database={3};", ServerName, UserName, Password, DBName);


        }
        public static int UserDetail(string name)
        {
            string UserName = name;
            var connection = GetSqlConnection();
            var SqlUser = new SqlConnection(connection);
            try
            {
                string Query = $"SELECT * FROM Sapphire.dbo.MH_Users where EmployeeName = '{UserName}'";
                SqlUser.Open();
                using (var cmd = new SqlCommand(Query, SqlUser))
                {
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        IsUserRegistered = 1;
                        SqlUser.Close();
                    }
                    else
                    {
                        IsUserRegistered = 0;
                    }
                }
            }
            catch(Exception)
            {
                IsUserRegistered = 999;
                SqlUser.Close();
            }
            return 1;
        }
        public static List<Questions> GetQuestions(string IsUserQuestions,string name)
        {
            List<Questions> questions = new List<Questions>();
            string UserName = name;
            var connection = GetSqlConnection();
            var SqlUser = new SqlConnection(connection);
            try
            {
                string Query;
                if(IsUserQuestions == "")
                    Query = $"SELECT * FROM Sapphire.dbo.MH_Posts";
                else
                    Query = $"SELECT * FROM Sapphire.dbo.MH_Posts where EmployeeName = '{UserName}'";
                SqlUser.Open();

                using (var cmd = new SqlCommand(Query, SqlUser))
                {
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Questions q = new Questions();
                            q.ID = reader.GetInt32(0);
                            q.EmployeeName = reader.GetString(1);
                            q.Title = reader.GetString(2);
                            q.Description = reader.GetString(3);
                            q.Tag1 = SafeGetString(reader, 4);
                            q.Tag2 = SafeGetString(reader, 5);
                            q.Tag3 = SafeGetString(reader, 6);
                            q.Tag4 = SafeGetString(reader, 7);
                            q.Tag5 = SafeGetString(reader, 8);
                            q.DateTimePosted = reader.GetDateTime(9);
                            questions.Add(q);
                        }
                        SqlUser.Close();
                    }
                    else
                    {
                    }
                }
                return questions;
            }
            catch(Exception ex)
            {
                SqlUser.Close();

            }
            return questions;
        }
        public static List<Questions> GetSearchQuestions(string ids)
        {
            List<Questions> questions = new List<Questions>();
            string UserName = GetUserName();
            var connection = GetSqlConnection();
            var SqlUser = new SqlConnection(connection);
            try
            {
                string Query;
                Query = $"SELECT * FROM Sapphire.dbo.MH_Posts where postid IN({ids})";
                SqlUser.Open();
                using (var cmd = new SqlCommand(Query, SqlUser))
                {
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Questions q = new Questions();
                            q.ID = reader.GetInt32(0);
                            q.EmployeeName = reader.GetString(1);
                            q.Title = reader.GetString(2);
                            q.Description = reader.GetString(3);
                            q.Tag1 = SafeGetString(reader, 4);
                            q.Tag2 = SafeGetString(reader, 5);
                            q.Tag3 = SafeGetString(reader, 6);
                            q.Tag4 = SafeGetString(reader, 7);
                            q.Tag5 = SafeGetString(reader, 8);
                            q.DateTimePosted = reader.GetDateTime(9);
                            questions.Add(q);
                        }
                        SqlUser.Close();
                    }
                    else
                    {
                    }
                }
                return questions;
            }
            catch(Exception ex)
            {
                SqlUser.Close();
            }
            return questions;
        }
        public static List<Questions> GetQuestion(int PostId)
        {
            List<Questions> questions = new List<Questions>();

            string UserName = GetUserName();
            var connection = GetSqlConnection();
            var SqlUser = new SqlConnection(connection);
            try
            {
                string Query;
                Query = $"SELECT P.*,C.Comment,C.EmployeeName as EmpComment,C.[DateTimePosted] as CommentPostedDateTime,ISNULL((SELECT reaction from [dbo].[MH_Reactions] where postid ={PostId} and EmployeeName='{UserName}'),0) as UserReaction,(SELECT ISNULL(SUM(reaction),0) from [dbo].[MH_Reactions] where postid ={PostId}) as Votes FROM  [dbo].[MH_Posts] P LEFT JOIN [dbo].[MH_Comments] C  ON P.PostID = C.PostID  WHERE P.PostID = {PostId}  Order By C.DateTimePosted DESC";
                SqlUser.Open();
                using (var cmd = new SqlCommand(Query, SqlUser))
                {
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Questions q = new Questions();
                            q.ID = reader.GetInt32(0);
                            q.EmployeeName = reader.GetString(1);
                            q.Title = reader.GetString(2);
                            q.Description = reader.GetString(3);
                            q.Tag1 = SafeGetString(reader, 4);
                            q.Tag2 = SafeGetString(reader, 5);
                            q.Tag3 = SafeGetString(reader, 6);
                            q.Tag4 = SafeGetString(reader, 7);
                            q.Tag5 = SafeGetString(reader, 8);
                            q.DateTimePosted = reader.GetDateTime(9);
                            q.comment = SafeGetString(reader, 10);
                            q.EmpComment = SafeGetString(reader, 11);
                            q.UserReacted = reader.GetInt32(13).ToString();
                            q.votes = reader.GetInt32(14).ToString();
                            q.EmpCommentDateTimePosted = SafeGetDate(reader,12);
                            questions.Add(q);
                        }
                        SqlUser.Close();
                        return questions;
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
        public static string GetAnswers(int PostId)
        {

            string UserName = GetUserName();
            var connection = GetSqlConnection();
            var SqlUser = new SqlConnection(connection);
            try
            {
                string Query;
                Query = $"WITH CTE AS(	SELECT 		SUM(reaction) as Votes,a.aNSWERID AS ANSWERID	FROM [dbo].[MH_aNSWERS] A INNER JOIN [dbo].[MH_Reactions] R	ON A.ANSWERID = R.ANSWERID	WHERE A.POSTID = {PostId} 	GROUP BY A.ANSWERID)  SELECT	A.AnswerID,A.PostID,A.EmployeeName,Title,A.DateTimePosted,IsAnswer,ISNULL(cte.Votes,0) as Votes,CASE WHEN (select Reaction from [dbo].[MH_Reactions] where EmployeeName = '{UserName}' and answerid = A.answerid) = -1 THEN -1 WHEN (select Reaction from [dbo].[MH_Reactions] where EmployeeName = '{UserName}' and answerid = A.answerid) =1 then 1 else 0 end as userreacted,C.*FROM [dbo].[MH_aNSWERS] A LEFT JOIN [dbo].[MH_Comments] C ON A.ANSWERID = C.ANSWERID LEFT JOIN CTE ON A.AnswerID = CTE.ANSWERID WHERE A.POSTID = {PostId} ORDER BY iSaNSWER,A.ANSWERID DESC FOR JSON AUTO;";
                SqlUser.Open();
                using (var cmd = new SqlCommand(Query, SqlUser))
                {
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        string s = "";
                        while (reader.Read())
                        {
                            s = reader.GetString(0);
                        }
                        SqlUser.Close();
                        return s;
                    }
                    else
                    {
                    }
                }
                return "";

            }
            catch (Exception ex)
            {
                SqlUser.Close();
            }
            return "";
        }
        public static string GetAnswerDewscription(string AnswerID)
        {

            string UserName = GetUserName();
            var connection = GetSqlConnection();
            var SqlUser = new SqlConnection(connection);
            try
            {
                string Query;
                Query = $"SELECT AnswerDescription from sapphire.dbo.MH_Answers where AnswerID = {AnswerID}";
                SqlUser.Open();
                using (var cmd = new SqlCommand(Query, SqlUser))
                {
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        string s = "";
                        while (reader.Read())
                        {
                            return reader.GetString(0);
                        }
                        SqlUser.Close();
                        return s;
                    }
                    else
                    {
                    }
                }
                return "";

            }
            catch (Exception ex)
            {
                SqlUser.Close();
            }
            return "";
        }
        public static int InsertReaction(string reaction, string post, string answer,string isanswer)
        {
            string UserName = GetUserName();
            var connection = GetSqlConnection();
            var SqlUser = new SqlConnection(connection);
            try
            {
                string Query;
                Query = $"Sapphire.dbo.MH_InsertUserReaction";
                SqlUser.Open();
                int x;
                using (var command = new SqlCommand(Query, SqlUser))
                {
                   
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@EmployeeName", UserName);
                        command.Parameters.AddWithValue("@AnswerID", answer);
                        command.Parameters.AddWithValue("@PostID",post);
                        command.Parameters.AddWithValue("@reaction", reaction);
                        command.Parameters.AddWithValue("@IsAnswer", isanswer);
                        SqlParameter returnParameter = command.Parameters.Add("@RequestStatus", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;
                        x = command.ExecuteNonQuery();
                        x = (int)returnParameter.Value;
                }
                return x;

            }
            catch (Exception ex)
            {
                return -999;
            }
        }
        public static bool InserUserComment( string PostID, string AnswerID, string Comment)
        {
            string UserName = GetUserName();
            var connection = GetSqlConnection();
            var SqlUser = new SqlConnection(connection);
            
            try
            {
                string Query;
                Query = $"INSERT INTO dbo.MH_Comments (EmployeeName,PostID,AnswerID,Comment) VALUES ('{UserName}','{PostID}','{AnswerID}','{Comment}')";
                SqlUser.Open();
                using (var cmd = new SqlCommand(Query, SqlUser))
                {
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    SqlUser.Close();
                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool InserSubmittedAnswer(  string AnswerID)
        {
            string UserName = GetUserName();
            var connection = GetSqlConnection();
            var SqlUser = new SqlConnection(connection);
            
            try
            {
                string Query;
                Query = $"UPDATE dbo.MH_Answers SET IsAnswer=1 WHERE AnswerId = {AnswerID}";
                SqlUser.Open();
                using (var cmd = new SqlCommand(Query, SqlUser))
                {
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    SqlUser.Close();
                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool InsertQuestion( string Title, string Description, string Tags, string communication)
        {
            string UserName = GetUserName();
            var connection = GetSqlConnection();
            var SqlUser = new SqlConnection(connection);
            string[] tgs = Tags.Split(",");
            int countTgs = tgs.Length;
            string Tags1 = tgs[0];
            string Tags2 = "";
            string Tags3 = "";
            string Tags4 = "";
            string Tags5 = "";
            if (countTgs > 1)
                Tags2 = tgs[1];
            if (countTgs > 2)
                Tags3 = tgs[2];
            if (countTgs > 3)
                Tags4 = tgs[3];
            if (countTgs > 4)
                Tags5 = tgs[4];

            try
            {
                string Query;
                Query = $"INSERT INTO dbo.MH_Posts (EmployeeName,Title,Description,Tag1,Tag2,Tag3,Tag4,Tag5) VALUES ('{UserName}','{Title}','{Description}','{Tags1}','{Tags2}','{Tags3}','{Tags4}','{Tags5}')";
                SqlUser.Open();
                using (var cmd = new SqlCommand(Query, SqlUser))
                {
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    SqlUser.Close();
                }
                return true;

            }
            catch (Exception ex)
            {
                return true;
                SqlUser.Close();
            }
        }
        public static bool InserUserDetails(string dept,string team,string tags,string alerts)
        {
            string UserName = GetUserName();
            var connection = GetSqlConnection();
            var SqlUser = new SqlConnection(connection);
            try
            {
                string Query = $"INSERT INTO Sapphire.dbo.MH_Users Values ('{UserName}','{UserName}@micron.com',{alerts},'{tags}','{dept}','{team}')";
                SqlUser.Open();
                using (var cmd = new SqlCommand(Query, SqlUser))
                {
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
                }
            }
            catch(Exception ex)
            {
                SqlUser.Close();
                return false;
            }
            return true;
        }
        public static bool InserUserAnswer(string PostID,string answer)
        {
            string UserName = GetUserName();
            var connection = GetSqlConnection();
            var SqlUser = new SqlConnection(connection);
            try
            {
                string Query = $"INSERT INTO Sapphire.dbo.MH_Answers (PostID,EmployeeName,Title,AnswerDescription,isAnswer) Values ('{PostID}','{UserName}','','{answer}',0)";
                SqlUser.Open();
                using (var cmd = new SqlCommand(Query, SqlUser))
                {
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
                }
                var q = GetQuestion(int.Parse(PostID));
                Utilities.Teams_notification.sendMessagetoTeams(q[0].EmployeeName, "User", $"Your question has a answer with Title <b>{q[0].Title}</b> by user <b>{UserName}</b>.");
            }
            catch (Exception ex)
            {
                SqlUser.Close();
                return false;
            }
            return true;
        }
        public static string SafeGetString(SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }
        public static string SafeGetDate(SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetDateTime(colIndex).ToString();
            return string.Empty;
        }
        
        public static string GetUserName()
        {
            string user;

            //user = context.HttpContext.User.FindFirst(ClaimTypes.Name).Value.Replace("WINNTDOM\\","");
            user = "bphanipranav";
            return user;
        }
        public static string Like(string val)
        {
            if (val == "1")
                return "#59b559";
            return "gray";
        }
        public static string LikeDisabled(string val)
        {
            if (val == "1")
                return "disabled";
            return "";
        }
        public static string DisLikeDisabled(string val)
        {
            if (val == "-1")
                return "disabled";
            return "";
        }
        public static string Dislike(string val)
        {
            if (val == "-1")
                return "#ff5b5b";
            return "gray";
        }
    }
}
