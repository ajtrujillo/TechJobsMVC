using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;
using System;

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

            if (searchType.Equals("all"))
            {
                searchResults.Add(JobData.FindByValue(searchTerm));
            }

            else
            {
                searchResults.Add(JobData.FindByColumnAndValue(searchType, searchTerm));
            }

            ViewBag.title = "Search by" + ListController.columnChoices[searchType] + ":" + searchTerm;
            ViewBag.jobs = searchResults;
            return ViewBag;
        }



    }
}
