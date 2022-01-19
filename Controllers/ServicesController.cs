using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using Search4Support.Data;
using Search4Support.Models;
using Search4Support.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Search4Support.Controllers
{
    [Authorize]
    public class ServicesController : Controller
    {
        private ServiceDbContext context;

        public ServicesController(ServiceDbContext dbContext)
        {
            context = dbContext;
        }

        [AllowAnonymous]
        // GET: ServicesController
        public IActionResult Index(string sortOrder, int? page )
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.ProviderSortParm = sortOrder == "Provider" ? "provider_desc" : "Provider";
            ViewBag.CategorySortParm = sortOrder == "Category" ? "category_desc" : "Category";
            
            IQueryable<Service> services = context.Services
                .Include(s => s.Category)
                .Include(s => s.Provider);
                

            switch(sortOrder)
            {
                case "name_desc":
                    services = services.OrderByDescending(s => s.Name);
                    break;
                case "Provider":
                    services = services.OrderBy(s => s.Provider.Name);
                    break;
                case "provider_desc":
                    services = services.OrderByDescending(s => s.Provider.Name);
                    break;
                case "Category":
                    services = services.OrderBy(s => s.Category.Name);
                    break;
                case "category_desc":
                    services = services.OrderByDescending(s => s.Category.Name);
                    break;
                default:
                    services = services.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(services.ToPagedList(pageNumber, pageSize));
        }

        [AllowAnonymous]
        public IActionResult Detail(int id)
        {
            Service theService = context.Services
                .Include(s => s.Category)
                .Include(s => s.Provider)
                .Single(s => s.Id == id);

            List<ServiceTag> serviceTags = context.ServiceTags
                .Where(st => st.ServiceId == id)
                .Include(st => st.Tag)
                .ToList();

            ServiceDetailViewModel viewModel = new ServiceDetailViewModel(theService, serviceTags);
            return View(viewModel);
        }

        // GET: ServicesController/Add
        public IActionResult Add()
        {
            List<Category> categories = context.Categories.OrderBy(c => c.Name).ToList();
            List<Provider> providers = context.Providers.OrderBy(p => p.Name).ToList();
            AddServiceViewModel addServiceViewModel = new AddServiceViewModel(categories, providers);
            return View(addServiceViewModel);
        }

        [HttpPost]
        public IActionResult ProcessAddServiceForm(AddServiceViewModel addServiceViewModel)
            //process the add form
        {
            if (ModelState.IsValid)
            {
                Provider theProvider = context.Providers.Find(addServiceViewModel.ProviderId);
                Category theCategory = context.Categories.Find(addServiceViewModel.CategoryId);
                Service newService = new Service
                {
                    Name = addServiceViewModel.Name,
                    Description = addServiceViewModel.Description,
                    Category = theCategory,
                    Provider = theProvider
                };

                context.Services.Add(newService);
                context.SaveChanges();

                return Redirect("/Services");
            }

            return View("Add", addServiceViewModel);
        }

        public IActionResult Delete()
        {
            List<Service> services = context.Services.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] serviceIds)
        {
            foreach (int serviceId in serviceIds)
            {
                Service theService = context.Services.Find(serviceId);
                context.Services.Remove(theService);
            }

            context.SaveChanges();

            return Redirect("/Services");
        }

        // POST: ServicesController/Add
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
        }

        //// GET: ServicesController/Edit/5
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