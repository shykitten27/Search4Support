using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Search4Support.Data;
using Search4Support.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search4Support.Controllers
{
    public class ServicesController : Controller
    {
        private ServiceDbContext context;

        public ServicesController(ServiceDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: ServicesController
        public IActionResult Index()
        {
            List<Service> services = context.Services.ToList();
            return View(services);
        }

        // GET: ServicesController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: ServicesController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServicesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
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

        // GET: ServicesController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: ServicesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
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

        // GET: ServicesController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: ServicesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
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
