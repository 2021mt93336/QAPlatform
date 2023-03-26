using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverflow.Models
{
    public class Answers
    {
        public string votes { get; set; }
        public string IsUserReacted { get; set; }
        public string AnswerID { get; set; }
        public string PostID { get; set; }
        public string EmployeeName { get; set; }
        public string Title { get; set; }
        public string AnswerDescription { get; set; }
        public string DatePosted { get; set; }
        public string IsAnswer { get; set; }
        public List<Comments> comments { get; set; }

    }
}
