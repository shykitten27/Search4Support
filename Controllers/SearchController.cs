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

            //if (searchType.ToLower().Equals("all"))
            //{
            if (string.IsNullOrEmpty(searchTerm))
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
                        .Where(s => s.Provider.Name.Contains(searchTerm))
                        .ToList();
                }
                else if (searchType == "category")
                {
                    services = context.Services
                        .Include(s => s.Category)
                        .Where(s => s.Category.Name.Contains(searchTerm))
                        .ToList();
                }
                else if (searchType == "location")
                {
                    services = context.Services
                        .Include(s => s.Provider)
                        .Include(s => s.Category)
                        .Where(s => s.Provider.Address.Contains(searchTerm))
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
