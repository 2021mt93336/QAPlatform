using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using SearchEngine;
using StackOverflow.Models;

namespace StackOverflow.Pages.HomePage
{

    public class SearchOutputModel : PageModel
    {
        public List<Questions> questions = new List<Questions>();
        public string searchText { get; set; }
        public void OnGet(string search)
        {
            searchText = search;
            //List<SearchResult>  result =  SearchEngine.Program.Main(search);
            //string query = "";
            //foreach(var x in result)
            //{
            //    query += x.id.ToString()+",";
            //}
            //if (query.Length > 2)
            //{
            //    query = query.Substring(0, query.Length - 1);
            //    questions = Utilities.Util.GetSearchQuestions(query);
            //}
        }
    }
}
