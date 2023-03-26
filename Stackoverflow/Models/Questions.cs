using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverflow.Models
{
    public class Questions
    {
        public int ID { get; set; }
        public string EmployeeName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tag1 { get; set; }
        public string Tag2 { get; set; }
        public string Tag3 { get; set; }
        public string Tag4 { get; set; }
        public string Tag5 { get; set; }
        public string comment { get; set; }
        public string votes { get; set; }
        public string EmpComment { get; set; }
        public string UserReacted { get; set; }
        public DateTime DateTimePosted { get; set; }
        public string EmpCommentDateTimePosted { get; set; }
    }
}
