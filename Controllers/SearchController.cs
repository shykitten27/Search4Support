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
    public class SearchController : Controller
    {
        internal static Dictionary<string, string> ColumnChoices = new Dictionary<string, string>()
                {
                    {"all", "All" },
                    {"provider", "Provider" },
                    {"category", "Category"},
                    {"location", "Location" },
                    {"tag", "Tag" },
                    {"keyword", "Keyword" }
                };
        internal static List<string> TableChoices = new List<string>()
                {
                    "provider",
                    "category",
                    "location",
                    "tag",
                    "keyword"
                };
        private ServiceDbContext context;

        public SearchController(ServiceDbContext dbContext)
        {
            context = dbContext;
        }


        //GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Service> services = new List<Service>();
            List<ServiceDetailViewModel> displayServices = new List<ServiceDetailViewModel>();

            if (string.IsNullOrEmpty(searchTerm))
            {
                services = context.Services
                    .Include(s => s.Provider)
                    .Include(s => s.Category)
                    .ToList();

                //foreach (var srv in services)
                //{
                //    List<ServiceCategory> serviceCategories = context.Categories
                //        .Where(sc => sc.Id == srv.Id)
                //        .Include(sc => sc.Name)
                //        .ToList();
                //}
            }

            else
            {
                if (searchType == "provider")
                {
                    services = context.Services
                        .Where(s => s.Provider.Name.Contains(searchTerm))
                        .Include(s => s.Provider)
                        .ToList();


                }

                else if (searchType == "category")
                {
                    services = context.Services
                        .Where(s => s.Category.Name.Contains(searchTerm))
                        .Include(s => s.Category)
                        .ToList();
                }

                //else if (searchType == "location")
                //{
                //    services = context.Services
                //        .Where(s => s.Location.Address == searchTerm)
                //        .Include(s => s.Location)
                //        .ToList();
                //}
            }


            ViewBag.columns = ListController.ColumnChoices;
            ViewBag.title = "Services with " + ColumnChoices[searchType] + ": " + searchTerm;
            ViewBag.services = services;
            return View(services);
        }
    }
}








