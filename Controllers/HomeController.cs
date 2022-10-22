using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Polo_Tecnologico_Incluit.Models;
using Proyecto_Final_Polo_Tecnologico_Incluit.Rules;
using System.Diagnostics;

namespace Proyecto_Final_Polo_Tecnologico_Incluit.Controllers
{
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

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Suerte()
        {
            var rule = new PublicacionRule();
            var post = rule.GetPublicacionRandom();   
            return View(post);
        }
        public IActionResult AcercaDe()
        {
            return View();
        }
        public IActionResult Contacto()
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