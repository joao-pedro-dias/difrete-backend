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
    public class MainFretistaController : Controller
    {
        private readonly ILogger<MainFretistaController> _logger;

        public MainFretistaController(ILogger<MainFretistaController> logger)
        {
            _logger = logger;
        }

        public IActionResult MainFretista()
        {
            return View();
        }
        public IActionResult MainFretistaServicoDisp()
        {
            return View();
        }
        public IActionResult MainFretistaServicoRealizado()
        {
            return View();
        }
        public IActionResult MainFretistaCriarServ()
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
