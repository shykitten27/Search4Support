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
    public class ListController : Controller
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

        public ListController(ServiceDbContext dbcontext)
        {
            context = dbcontext;
        }

        // GET:<controller>/
        //public IActionResult Index()
        //{
        //    ViewBag.columns = ColumnChoices;
        //    ViewBag.tablechoices = TableChoices;
        //    ViewBag.providers = context.Providers.ToList();
        //    ViewBag.services = context.Services.ToList();
        //    ViewBag.categories = context.Categories.ToList();
        //    ViewBag.locations = context.Locations.ToList();
        //    return View();
        //}

        public IActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "name_asc";
            ViewBag.ProvidersSortParm = String.IsNullOrEmpty(sortOrder) ? "provider_desc" : "";
            ViewBag.CategoriesSortParm = String.IsNullOrEmpty(sortOrder) ? "category_desc" : "";
            ViewBag.LocationsSortParm = String.IsNullOrEmpty(sortOrder) ? "location_desc" : "";

            var services = from s in context.Services
                           select s;
            switch (sortOrder)
            {
                case "name_desc":
                    services = services.OrderByDescending(s => s.Name);
                    break;
                case "provider":
                    services = services.OrderByDescending(s => s.Provider.Name);
                    break;
                case "category":
                    services = services.OrderByDescending(s => s.Category.Name);
                    break;
                case "location":
                    services = services.OrderByDescending(s => s.Location.Address);
                    break;
            }
            return View(services.ToList());
        }
    }
}


        // list services by column and value
//        public IActionResult Services(string column, string value)
//        {
//            List<Service> services;
//            List<ServiceListViewModel> displayServices = new List<ServiceListViewModel>();

//            if (column.ToLower().Equals("all"))
//            {
//                services = context.Services
//                    .Include(s => s.Provider)
//                    .ToList();

//                ViewBag.title = "All Services";
//            }
//            else
//            {
//                if (column == "provider")
//                {
//                    services = context.Services
//                        .Include(s => s.Provider)
//                        .Where(s => s.Provider.Name == value)
//                        .ToList();

//                    foreach(Service srv in services)
//                    {
//                        ServiceListViewModel newDisplayService = new ServiceListViewModel(srv);
//                        displayServices.Add(newDisplayService);
//                    }
//                }

//                else if (column == "category")
//                {
//                    services = context.Services
//                        .Include(s => s.Category)
//                        .Where(s => s.Category.Name == value) 
//                        .ToList();

//                    foreach (Service srv in services)
//                    {
//                        ServiceListViewModel newDisplayService = new ServiceListViewModel(srv);
//                        displayServices.Add(newDisplayService);
//                    }
//                }

//                else if (column == "location")
//                {
//                    services = context.Services
//                        .Include(s => s.Location)
//                        .Where(s => s.Location.Address == value)
//                        .ToList();

//                    foreach (Service srv in services)
//                    {
//                        ServiceListViewModel newDisplayService = new ServiceListViewModel(srv);
//                        displayServices.Add(newDisplayService);
//                    }
//                }

//                ViewBag.title = "Services with " + ColumnChoices[column] + ": " + value;
//            }
//            ViewBag.services = displayServices;

//            return View();
//        }
//    }
//}

