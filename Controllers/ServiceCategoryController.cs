using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class ServiceCategoryController : Controller
    {
        private ServiceDbContext context;

        public ServiceCategoryController(ServiceDbContext dbContext)
        {
            context = dbContext;
        }

        [AllowAnonymous]
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            //default order by name ascending
            List<ServiceCategory> categories = context.Categories.OrderBy(c => c.Name).ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddServiceCategoryViewModel addServiceCategoryViewModel = new AddServiceCategoryViewModel();
            return View(addServiceCategoryViewModel);
        }
        [HttpPost]
        public IActionResult ProcessAddServiceCategoryForm(AddServiceCategoryViewModel addServiceCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                ServiceCategory newCategory = new ServiceCategory
                {
                    Name = addServiceCategoryViewModel.Name,
                };

                context.Categories.Add(newCategory);
                context.SaveChanges();

                return Redirect("/ServiceCategory");
            }

            return View("Add", addServiceCategoryViewModel);
        }
    }
}
