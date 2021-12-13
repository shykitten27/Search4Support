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
    public class ServiceCategoryController : Controller
    {
        private ServiceDbContext context;

        public ServiceCategoryController(ServiceDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<ServiceCategory> categories = context.Categories.ToList();
            return View(categories);
        }
    }
}
