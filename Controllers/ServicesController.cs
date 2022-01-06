using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Search4Support.Data;
using Search4Support.Models;
using Search4Support.ViewModels;
using System.Collections.Generic;
using System.Linq;
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
            //default order by name ascending
            List<Service> services = context.Services.OrderBy(s => s.Name)
                .Include(s => s.Category)
                .ToList();

            return View(services);
        }

        public IActionResult Add()
        {
            //List<ServiceCategory> categories = context.Categories.ToList();
            //add sorting to category list
            //same for providers
            List<ServiceCategory> categories = context.Categories.OrderBy(c=>c.Name).ToList();
            List<Provider> providers = context.Providers.OrderBy(p => p.Name).ToList();
            AddServiceViewModel addServiceViewModel = new AddServiceViewModel(categories, providers);

            return View(addServiceViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddServiceViewModel addServiceViewModel)
        {
            if (ModelState.IsValid)
            {
                ServiceCategory theCategory = context.Categories.Find(addServiceViewModel.CategoryId);
                Provider theProvider = context.Providers.Find(addServiceViewModel.ProviderId);
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
                .Include(s => s.Provider)
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