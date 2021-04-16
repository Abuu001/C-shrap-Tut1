using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JokesWebApp.Models;

namespace JokesWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //we can use ViewDataAttribute by [viewData on top of the propertie]
        // we can use this method to display data directly to views instead  of writing again in views
        [ViewData]
        public string Title { get; set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //view bag is used to pass data from an action(controller) to view - uses any type of data
            ViewBag.Title = 123;
            ViewBag.Data = new { Id = 22, Name = "Mutua" };
            ViewBag.Abu = new BookModel() { Id = 9, Author = "Reen" };

            //view data is used to pass data from an action(controller) to view but uses key value pair
            ViewData["School"] = "JKuaT";

            return View();
        }

        public ViewResult AboutUs()
        {
            return View();
        }
        public IActionResult Tim()
        {
            //we are using the data attribute from the prop
            Title = "Tim from controller";
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
