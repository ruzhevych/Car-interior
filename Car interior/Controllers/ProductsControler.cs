using Microsoft.AspNetCore.Mvc;
using Car_interior.Data;
using Car_interior.Models;
using Car_interior.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Car_interior.Controllers
{
    public class ProductsController : Controller
    {
        private InteriorDbContext ctx = new InteriorDbContext();
        public ProductsController()
        { 
        }

        public IActionResult Index()
        {
            // .. load data from database ..
            var cars = ctx.Cars
                .Include(x => x.Category) // LEFT JOIN
                .Where(x => !x.Archived)
                .ToList();

            return View(cars);
        }

        // GET: 
        [HttpGet]
        public IActionResult Create()
        {
            LoadCategories();
            ViewBag.CreateMode = true;
            return View("Upsert");
        }

        // POST
        [HttpPost]
        public IActionResult Create(Cars model)
        {
            // TODO: add data validation

            ctx.Cars.Add(model);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cars = ctx.Cars.Find(id);

            if (cars == null) return NotFound();

            LoadCategories();
            ViewBag.CreateMode = false;
            return View("Upsert", cars);
        }

        [HttpPost]
        public IActionResult Edit(Cars model)
        {
            // TODO: add data validation

            ctx.Cars.Update(model);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var cars = ctx.Cars.Find(id);

            if (cars == null) return NotFound();

            ctx.Cars.Remove(cars);
            ctx.SaveChanges();

            return RedirectToAction("Archive");
        }

        public IActionResult Archive()
        {
            // .. load data from database ..
            var cars = ctx.Cars
                .Include(x => x.Category) // LEFT JOIN
                .Where(x => x.Archived)
                .ToList();

            return View(cars);
        }

        public IActionResult ArchiveItem(int id)
        {
            var cars = ctx.Cars.Find(id);

            if (cars == null) return NotFound();

            cars.Archived = true;
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult RestoreItem(int id)
        {
            var cars = ctx.Cars.Find(id);

            if (cars == null) return NotFound();

            cars.Archived = false;
            ctx.SaveChanges();

            return RedirectToAction("Archive");
        }

        private void LoadCategories()
        {
            // ViewBag.PropertyName = value;
            ViewBag.Categories = new SelectList(ctx.Categories.ToList(), "Id", "Name");
        }
    }
}
