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
            //All searchType

            if (searchType.ToLower().Equals("all"))
            {
                //blank or null searchTerm
                if (searchTerm == null || searchTerm == "")
                {
                    services = context.Services
                        .Include(s => s.Provider)
                        .Include(s => s.Category)
                        .ToList();
                }
                else
                //you have entered a searchTerm
                {
                    List<Service> allServices = context.Services
                         .Include(s => s.Provider)
                         .Include(s => s.Category)
                         .ToList();
                    //if the search is contained in any of the columns aka searchType, return aka Add to service
                    foreach (Service srv in allServices)
                    {
                        if (srv.Name.ToLower().Contains(searchTerm.ToLower()))
                        {
                            services.Add(srv);
                        }
                        else if (srv.Provider.Name.ToLower().Contains(searchTerm.ToLower()))
                        {
                            services.Add(srv);
                        }
                        else if (srv.Category.Name.ToLower().Contains(searchTerm.ToLower()))
                        {
                            services.Add(srv);
                        }
                        else if (srv.Provider.Address.ToLower().Contains(searchTerm.ToLower()))
                        {
                            services.Add(srv);
                        }
                    }
                }

            } // end of searchTypeAll
            else
            {   //"provider" searchType
                if (searchType == "provider")
                    if (searchTerm == null || searchTerm == "")
                    {
                        services = context.Services
                            .Include(s => s.Provider)
                            .Include(s => s.Category)
                            .ToList();
                    }
                    else
                    {
                        services = context.Services
                            .Include(s => s.Category)
                            .Include(s => s.Provider)
                            .Where(s => s.Provider.Name.Contains(searchTerm.ToLower()))
                            .ToList();
                    }
                //"category" searchType
                else if (searchType == "category")
                    if (searchTerm == null || searchTerm == "")
                    {
                        services = context.Services
                            .Include(s => s.Category)
                            .Include(s => s.Provider)
                            .ToList();
                    }
                    else
                        services = context.Services
                            .Include(s => s.Category)
                            .Include(s => s.Provider)
                            .Where(s => s.Category.Name.Contains(searchTerm.ToLower()))
                            .ToList();

                //"location" searchType
                else if (searchType == "location")
                    if (searchTerm == null || searchTerm == "")
                    {
                        services = context.Services
                            .Include(s => s.Category)
                            .Include(s => s.Provider)
                            .ToList();
                    }
                    else
                        services = context.Services
                            .Include(s => s.Category)
                            .Include(s => s.Provider)
                            .Where(s => s.Provider.Address.Contains(searchTerm.ToLower()))
                            .ToList();
            }
            ViewBag.columns = ListController.ColumnChoices;
            ViewBag.title = "Services with " + ColumnChoices[searchType] + ": " + searchTerm;
            ViewBag.services = services;
            return View(services);
        }
    }
}
            
    

