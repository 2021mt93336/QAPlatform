using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StackOverflow.Models;

namespace StackOverflow.Pages.HomePage
{
    public class AskaQuestionModel : PageModel
    {
        public int edit { get; set; }
        public int id { get; set; }
        public Questions questions { get; set; }
        public void OnGet(int edit,int id)
        {
            if (edit == 1)
            {
                this.edit = edit;
                this.id = id;
                //questions = Utilities.Util.GetQuestion(id);
            }
        }
        
        public IActionResult OnPostSubmit()
        {
            string Title = Request.Form["title"] ;
            string Description = Request.Form["editor"];
            string Tags = Request.Form["tags"];
            string communication = Request.Form["isChecked"]=="on"?"1":"0";
            Description = Description.Replace("'","''");
            if (Utilities.Util.InsertQuestion( Title, Description, Tags, communication))
            {
                return Redirect("~/Index");
            }
            return Redirect("~/Error");
        }
        
    }
}
