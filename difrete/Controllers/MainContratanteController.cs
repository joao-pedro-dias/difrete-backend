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
    public class MainContratanteController : Controller
    {
        private readonly ILogger<MainContratanteController> _logger;

        public MainContratanteController(ILogger<MainContratanteController> logger)
        {
            _logger = logger;
        }

        public IActionResult MainContratante()
        {
            return View();
        }
        public IActionResult MainContratanteServicoDisp()
        {
            return View();
        }
        public IActionResult MainContratanteServicoRealizado()
        {
            return View();
        }

        public IActionResult MainContratanteSolicitacaoPen()
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
