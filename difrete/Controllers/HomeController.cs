using difrete.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace difrete.Controllers
{
    //controller referente ao front
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SAC()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Fretista()
        {
            return View();
        }
        public IActionResult Contratante()
        {
            return View();
        }
        public IActionResult MainContratante()
        {
            return View();
        }

        public IActionResult MainFretista()
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
