using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverflow.Controllers
{

    public class LikeController : ControllerBase
    {
        public bool Index()
        {
            
            return false;
        }
if DEBUG
        [HttpPost]
else
        [HttpPost("/SubmitReaction")]
endif
        public ActionResult OnGetSubmitReaction(string ID, string reaction)
        {
            return new JsonResult("1");
        }
    }
}
