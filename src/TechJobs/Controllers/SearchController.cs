using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

        //[Route("/View/Search/Index")]
        //[HttpPost]
        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.columnChoices;
            List<Dictionary<string, string>> searchResults = new List<Dictionary<string, string>>();

            if (searchType= "all")
            {
                searchResults.Add = JobData.FindbyValue(searchTerm);
            }

            else
            {
                searchResults.Add = JobData.FindByColumnAndValue(searchType, searchTerm);
            }

            ViewBag.title = "Search by" + ListController.columnChoices[searchType] + ":" + searchTerm;
            ViewBag.jobs = searchResults;
        }



    }
}
