using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using StackOverflow.Models;
using StackOverflow.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StackOverflow.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public  List<Questions> questions = new List<Questions>();
        public static IHttpContextAccessor ac;
        public string name;

        public IndexModel(ILogger<IndexModel> logger,IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            ac = contextAccessor;
        }

        public void OnGet(string profile)
        {
            name = "bphanipranav";//ac.HttpContext.User.FindFirst(ClaimTypes.Name).Value.Replace("WINNTDOM\\","");
            var x = Util.UserDetail(name);
            Util u = new Util(ac);
            name = Util.GetUserName();
            if (profile == "1")
                questions = Util.GetQuestions("1",name);
            else
                questions = Util.GetQuestions("",name);

        }
        public static string GetUser()
        {
            return ac.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
        }
    }
}
