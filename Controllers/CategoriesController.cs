using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Search4Support.Data;
using Search4Support.Models;
using Search4Support.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Search4Support.Controllers
{
    [Authorize]
    public class CategoriesController : Controller

    {
        private ServiceDbContext context;

        public CategoriesController(ServiceDbContext dbContext)
        {
            context = dbContext;
        }

        [AllowAnonymous]
        // GET: CategoriesController
        public IActionResult Index(string sortOrder, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            IQueryable<Category> categories = context.Categories
                .Include(c => c.Services);

            switch (sortOrder)
            {
                case "name_desc":
                    categories = categories.OrderByDescending(p => p.Name);
                    break;
                default:
                    categories = categories.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(categories.ToPagedList(pageNumber, pageSize));
        }

        [AllowAnonymous]
        // GET: ProvidersController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Detail(int id)
        {

            Category theCategory = context.Categories
                //.Include(c => c.Services)
                //.OrderBy(c => c.Name)
                //.Single(c => c.Id == id)
                
                .Join(context.Services,
                       left => left.Id,
                       right => right.CategoryId,
                       (left, right) => new { categories = left, services = right })
                .Join(context.Providers,
                       left => left.services.Id,
                       right => right.Id,
                       (left, right) => new { categories = left.categories, services = left.services, providers = right })
                .Where(c => c.Services.ProviderId == id);


            CategoryDetailViewModel viewModel = new CategoryDetailViewModel(theCategory);
            return View(viewModel);     
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddCategoryViewModel addCategoryViewModel = new AddCategoryViewModel();
            return View(addCategoryViewModel);
        }

        [HttpPost]
        public IActionResult ProcessAddCategoryForm(AddCategoryViewModel addCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                Category newCategory = new Category
                {
                    Name = addCategoryViewModel.Name,
                };

                context.Categories.Add(newCategory);
                context.SaveChanges();

                return Redirect("/Categories");
            }

            return View("Add", addCategoryViewModel);
        }
    }
}
