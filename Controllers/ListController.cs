﻿using Microsoft.AspNetCore.Mvc;
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
        };

        internal static List<string> TableChoices = new List<string>()
        {
            "provider",
            "category",
        };

        private ServiceDbContext context;

        public ListController(ServiceDbContext dbcontext)
        {
            context = dbcontext;
        }

        // GET:<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ColumnChoices;
            ViewBag.tablechoices = TableChoices;
            ViewBag.services = context.Services.ToList();
            ViewBag.categories = context.Categories.ToList();
            return View();
        }


        // list services by column and value
        public IActionResult Services(string column, string value)
        {
            List<Service> services = new List<Service>();
            List<ServiceDetailViewModel> displayServices = new List<ServiceDetailViewModel>();

            if (column.ToLower().Equals("all"))
            {
                services = context.Services
                    .ToList();

                    ServiceDetailViewModel newDisplayService = new ServiceDetailViewModel(service, serviceTags);
                    displayServices.Add(newDisplayService);
                }

                ViewBag.title = "All Services";
            }
            {
                if (column == "provider")
                {
                    services = context.Services
                        .Include(s => s.Provider)
                        .Where(s => s.Provider.Name == value)
                        .ToList();

                    foreach (Service service in services)
                    {
                        List<ServiceTag> serviceTags = context.ServiceTags
                            .Where(st => st.ServiceId == service.Id)
                            .Include(st => st.Tag)
                            .ToList();

                        ServiceDetailViewModel newDisplayService = new ServiceDetailViewModel(service, serviceTags);
                        displayServices.Add(newDisplayService);
                    }
                }

                else if (column == "category")
                {
                    services = context.Services
                        .Include(s => s.Category)
                        .Where(s => s.Category.Name == value)
                        .ToList();

                    foreach (Service service in services)
                    {
                        List<ServiceTag> serviceTags = context.ServiceTags
                            .Where(st => st.ServiceId == service.Id)
                            .Include(st => st.Tag)
                            .ToList();

                        ServiceDetailViewModel newDisplayService = new ServiceDetailViewModel(service, serviceTags);
                        displayServices.Add(newDisplayService);
                }
                }

                else if (column == "location")
                {
                    services = context.Services
                        .Include(s => s.Location)
                        .ToList();

                        ServiceDetailViewModel newDisplayService = new ServiceDetailViewModel(service, serviceTags);
                        displayServices.Add(newDisplayService);
                    }
                }

                else if (column == "tag")
                {
                    List<ServiceTag> serviceTags = context.ServiceTags
                        .Where(s => s.Tag.Name == value)
                        .ToList();

                    foreach (var service in serviceTags)
                    {
                        Service foundService = context.Services
                            .Include(s => s.Provider)
                            .Single(s => s.Id == service.ServiceId);

                        List<ServiceTag> displayTags = context.ServiceTags
                            .Where(st => st.TagId == foundService.Id)
                            .Include(st => st.Tag)
                            .ToList();

                        ServiceDetailViewModel newDisplayService = new ServiceDetailViewModel(foundService, displayTags);
                        displayServices.Add(newDisplayService);
                    }
                }
                ViewBag.title = "Services with " + ColumnChoices[column] + ": " + value;
            }

            return View();
        }
    }
}

