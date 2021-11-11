using BookWebMvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebMvc.Controlles
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            List<Book> lib = new();
            lib.Add(new Book { Id = 1, Title = "Title1", Description = "Descripcion askldjasd", PageCount = 5, Excerpt = "Excerptasdajsd" });
            lib.Add(new Book { Id = 2, Title = "Title2", Description = "Descripcion askldjasd", PageCount = 5, Excerpt = "Excerptasdajsd" });
            lib.Add(new Book { Id = 3, Title = "Title3", Description = "Descripcion askldjasd", PageCount = 5, Excerpt = "Excerptasdajsd" });
            lib.Add(new Book { Id = 4, Title = "Title4", Description = "Descripcion askldjasd", PageCount = 5, Excerpt = "Excerptasdajsd" });
            lib.Add(new Book { Id = 5, Title = "Title5", Description = "Descripcion askldjasd", PageCount = 5, Excerpt = "Excerptasdajsd" });
            lib.Add(new Book { Id = 6, Title = "Title6", Description = "Descripcion askldjasd", PageCount = 5, Excerpt = "Excerptasdajsd" });
            return View(lib);
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
