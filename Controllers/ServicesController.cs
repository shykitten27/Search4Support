using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Search4Support.Data;
using Search4Support.Models;
using Search4Support.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Service> services = context.Services
                .Include(s => s.Category)
                .ToList();

            return View(services);
        }

        public IActionResult Add()
        {
            List<ServiceCategory> categories = context.Categories.ToList();
            AddServiceViewModel addServiceViewModel = new AddServiceViewModel(categories);

            return View(addServiceViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddServiceViewModel addServiceViewModel)
        {
            if (ModelState.IsValid)
            {
                ServiceCategory theCategory = context.Categories.Find(addServiceViewModel.CategoryId);
                Service newService = new Service
                {
                    Name = addServiceViewModel.Name,
                    Description = addServiceViewModel.Description,
                    Category = theCategory
                };

                context.Services.Add(newService);
                context.SaveChanges();

                return Redirect("/Services");
            }

            return View("Add", addServiceViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.events = context.Services.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] serviceIds)
        {
            foreach (int eventId in serviceIds)
            {
                Service theService = context.Services.Find(serviceIds);
                context.Services.Remove(theService);
            }

            context.SaveChanges();

            return Redirect("/Services");
        }

        [AllowAnonymous]
        // /Services/Detail/5 where 5 is the id of the service i.e. path parameter
        public IActionResult Detail(int id)
        {
            Service theService = context.Services
                .Include(s => s.Category)
                .Single(s => s.Id == id);

            //new collection of tags where only those returned from query
            //meet the serviceId and eager load the tags
            List<ServiceTag> serviceTags = context.ServiceTags
                .Where(st => st.ServiceId == id)
                .Include(st => st.Tag)
                .ToList();

            ServiceDetailViewModel viewModel = new ServiceDetailViewModel(theService, serviceTags);
            return View(viewModel);
        }
    }
}