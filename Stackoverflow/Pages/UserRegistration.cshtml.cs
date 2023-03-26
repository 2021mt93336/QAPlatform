using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StackOverflow.Pages
{
    public class UserRegistrationModel : PageModel
    {
        public int RegistrationSuccess = 0;
        public void OnGet()
        {
            RegistrationSuccess = Utilities.Util.IsUserRegistered;
        }
        public IActionResult OnPostSubmit()
        {
            var deartment = Request.Form["Department"];
            var team = Request.Form["Team"];
            var alert = Request.Form["isChecked"];
            var tags = Request.Form["Tags"];
            if (Utilities.Util.InserUserDetails(deartment, team, tags, alert))
            {
                RegistrationSuccess = 1;
                string user = Utilities.Util.GetUserName();
                Utilities.SendMail.MailUser($"Hi {user}.\r\rWelcome to AKIO. The single destination for your questions in Micron.\r",user+"@micron.com","","Registration Success");
                return Redirect("~/Index");
            }
            else
            {
                return Redirect("~/Error");
            }
        }
    }
}
