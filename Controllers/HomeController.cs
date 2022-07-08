using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TheCapitalBurguer.Models;
using TheCapitalBurguer.Repository;

namespace TheCapitalBurguer.Controllers
{
    public class HomeController : Controller
    {
        private MenuRepository menuRepository;

        public HomeController()
        {
            menuRepository = new MenuRepository();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Menu2()
        {
            var model = menuRepository.ObtenerMenu();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
