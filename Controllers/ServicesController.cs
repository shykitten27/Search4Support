using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Search4Support.Data;
using Search4Support.Models;
using Search4Support.ViewModels;
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

        // GET: ServicesController/Add
        public IActionResult Add()
        {
            AddServiceViewModel addServiceViewModel = new AddServiceViewModel();
            return View(addServiceViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddServiceViewModel addServiceViewModel)
        {
            if (ModelState.IsValid)
            {
                Service theService = new Service
                {
                    Name = addServiceViewModel.Name,
                    Description = addServiceViewModel.Description
                };

                context.Services.Add(theService);
                context.SaveChanges();

                return Redirect("/Services");
            }

            return View("Add", addServiceViewModel);
        }

/*        // POST: ServicesController/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/

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
