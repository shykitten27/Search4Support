using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Search4Support.Data;
using Search4Support.Models;
using Search4Support.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search4Support.Controllers
{
    public class CategoryController : Controller

    {
        private ServiceDbContext context;

        public CategoryController(ServiceDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: CategoriesController
        public IActionResult Index()
        {
            List<Category> categories = context.Categories
                .Include(c => c.Services)
                .ToList();
            return View(categories);
        }


        // GET: ProvidersController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }


        public IActionResult Detail(int id)
        {

            Category theCategory = context.Categories
                .Include(p => p.Services)
                .Single(p => p.Id == id);

            List<CategoryService> categoryServices = context.CategoryServices
                .Where(cs => cs.ServiceId == id)
                .Include(cs => cs.Category)
                .Include(cs => cs.Service)
                .ToList();

            CategoryDetailViewModel viewModel = new CategoryDetailViewModel(theCategory, categoryServices);
            return View(viewModel);     
        }
    }
}
