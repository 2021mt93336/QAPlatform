using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverflow.Models
{
    public class Comments
    {
        public string commentID { get; set; }
        public string EmployeeName { get; set; }
        public string PostID { get; set; }
        public string AnswerID { get; set; }
        public string Comment { get; set; }
        public string DateTimePOsted { get; set; }
    }
}
