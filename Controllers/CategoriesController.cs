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
    public class CategoriesController : Controller

    {
        private ServiceDbContext context;

        public CategoriesController(ServiceDbContext dbContext)
        {
            context = dbContext;
        }

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


        // GET: ProvidersController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }


        public IActionResult Detail(int id)
        {

            Category theCategory = context.Categories
                .Include(c => c.Services)
                .Single(c => c.Id == id);

            

            CategoryDetailViewModel viewModel = new CategoryDetailViewModel(theCategory);
            return View(viewModel);     
        }
    }
}
