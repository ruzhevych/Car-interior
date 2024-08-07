using Car_interior.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Data.Data;

namespace Car_interior.Controllers
{
    public class HomeController : Controller
    {
        private InteriorDbContext context = new();
        public HomeController()
        {
        }

        public IActionResult Index()
        {
           var cars = context.Cars
                .Include(x => x.Category)
                .ToList();
            return View(cars);
        }

        public IActionResult Privacy()
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
