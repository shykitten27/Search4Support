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
            {"location", "Location" }
        };
        internal static List<string> TableChoices = new List<string>()
        {
            "provider",
            "category",
            "location"
        };
        private ServiceDbContext context;

        public SearchController(ServiceDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            ViewBag.columns = ColumnChoices;
            ViewBag.tablechoices = TableChoices;
            ViewBag.providers = context.Providers.ToList();
            ViewBag.services = context.Services.ToList();
            ViewBag.categories = context.Categories.ToList();
            //ViewBag.locations = context.Locations.ToList();
            return View();
        }

        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    ViewBag.columns = ListController.ColumnChoices;
        //    return View();
        //}

        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Service> services = new List<Service>();

            if (searchType.ToLower().Equals("all"))
            {
                services = context.Services
                    .Include(s => s.Provider)
                    .Include(s => s.Category)
                    .ToList();

            }
            else
            {
                if (searchType == "provider")
                {
                    services = context.Services
                        .Include(s => s.Provider)
                        .Where(s => s.Provider.Name == searchTerm)
                        .ToList();
                }
                else if (searchType == "category")
                {
                    services = context.Services
                        .Include(s => s.Category)
                        .Where(s => s.Category.Name == searchTerm)
                        .ToList();
                }
                else if (searchType == "location")
                {
                    services = context.Services
                        .Include(s => s.Provider)
                        .Where(s => s.Provider.Address.Contains(searchTerm))
                        .ToList();
                }
            }

            ViewBag.columns = ListController.ColumnChoices;
                ViewBag.title = "Services with " + ColumnChoices[searchType] + ": " + searchTerm;
                ViewBag.services = services;
                return View(services);
            }

        }
    }
