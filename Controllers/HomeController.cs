using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Polo_Tecnologico_Incluit.Models;
using Proyecto_Final_Polo_Tecnologico_Incluit.Rules;
using System.Diagnostics;

namespace Proyecto_Final_Polo_Tecnologico_Incluit.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var rule = new PublicacionRule(_configuration);
            var rulePost = rule.GetPostHome();
            return View(rulePost);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Suerte()
        {
            var rule = new PublicacionRule(_configuration);
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