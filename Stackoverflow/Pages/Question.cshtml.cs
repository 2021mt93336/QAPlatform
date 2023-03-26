using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;

using StackOverflow.Models;

namespace StackOverflow.Pages
{
    public class QuestionModel : PageModel
    {
        public List<Questions> q = new List<Questions>();
        public List<Answers> ans = new List<Answers>();
        public int id;
        public bool isThereAnswer = false;
        public void OnGet(int id)
        {
            this.id = id;
           q =  Utilities.Util.GetQuestion(id);
           ParseAnswerData(Utilities.Util.GetAnswers(id));
        }
        public IActionResult OnPostSubmit()
        {
            var PostId = Request.Form["id"];
            var edito = Request.Form["editor"].ToString().Replace("'","''");
            if (Utilities.Util.InserUserAnswer(PostId, edito))
            {
                return Redirect("~/Index");
            }
            return Redirect("~/Error");
        }
        public IActionResult OnPostAnswerThis()
        {
            if(Utilities.Util.InserSubmittedAnswer(Request.Form["Answerid"].ToString()))
                return Redirect("~/Index");
            return Redirect("~/Error");
        }
        public ActionResult OnGetSubmitReaction(string reaction, string post, string answer, string isanswer)
        {
            return new JsonResult( Utilities.Util.InsertReaction(reaction, post, answer, isanswer).ToString() );
        }
        public IActionResult OnPostAddComment()
        {
            var AnswerID = Request.Form["Answerid"];
            var PostID = Request.Form["PostID"];
            var edito = Request.Form["comment"];
            var id = Request.Form["PostIDfor"];
            id = string.IsNullOrEmpty(PostID) ?id:PostID;
           
            if (Utilities.Util.InserUserComment(PostID,AnswerID, edito))
            {
                return Redirect($"~/Question?id={id}");
            }
            return Redirect("~/Error");
        }
        public void ParseAnswerData(string s)
        {
            string json = s;
            if (s == "")
            {

            }
            else
            {
                var getResult = JArray.Parse(json);             
                foreach (JObject o in getResult.Children<JObject>())
                {

                    Answers a = new Answers();
                    a.IsAnswer = o["IsAnswer"].ToString();
                    if(a.IsAnswer == "True")
                    {
                        isThereAnswer = true;
                    }
                    a.Title = o["Title"].ToString();
                    a.AnswerID = o["AnswerID"].ToString();
                    a.AnswerDescription = Utilities.Util.GetAnswerDewscription(a.AnswerID);

                    a.PostID = o["PostID"].ToString();
                    a.EmployeeName = o["EmployeeName"].ToString();
                    a.DatePosted = o["DateTimePosted"].ToString();
                    a.PostID = o["PostID"].ToString();
                    a.votes = o["Votes"].ToString();
                    a.IsUserReacted = o["userreacted"].ToString();
                    var x = (JArray)o["C"];
                    if (x.HasValues)
                    {
                        List<Comments> comm = new List<Comments>();
                        foreach (JObject o1 in x.Children<JObject>())
                        {
                            if (o1.Count > 0)
                            {
                                Comments c = new Comments();
                                c.commentID = o1["CommentID"].ToString();
                                c.EmployeeName = o1["EmployeeName"].ToString();
                                c.PostID = o1["PostID"].ToString();
                                c.AnswerID = o1["AnswerID"].ToString();
                                c.Comment = o1["Comment"].ToString();
                                c.DateTimePOsted = o1["DateTimePosted"].ToString();
                                comm.Add(c);
                            }
                        }
                        a.comments = comm;
                    }
                    ans.Add(a);
                }
            }
        }

    }
}
