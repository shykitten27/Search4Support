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
    public class SearchController
    {

        private ServiceDbContext context;

        public SearchController(ServiceDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Service> services;
            List<ServiceDetailViewModel> displayServices = new List<ServiceDetailViewModel>();

            if (string.IsNullOrEmpty(searchTerm))
            {
                services = context.Services
                   .Include(s => s.Provider)
                   .ToList();

                foreach (var service in services)
                {
                    List<ServiceSkill> serviceSkills = context.ServiceSkills
                        .Where(ss => ss.serviceId == service.Id)
                        .Include(ss => service.Skill)
                        .ToList();

                    ServiceDetailViewModel newDisplayService = new ServiceDetailViewModel(search, serviceSkills);
                    displayServices.Add(newDisplayService);
                }
            }
            else
            {
                if (searchType == "provider")
                {
                    services = context.Services
                        .Include(s => s.Provider)
                        .Where(s => s.Provider.Name == searchTerm)
                        .ToList();

                    foreach (Service service in services)
                    {
                        List<ServiceSkill> serviceSkills = context.JobSkills
                        .Where(ss => ss.ServiceId == service.Id)
                        .Include(ss => ss.Skill)
                        .ToList();

                        ServiceDetailViewModel newDisplayService = new ServiceDetailViewModel(service, serviceSkills);
                        displayServices.Add(newDisplayService);
                    }

                }
                else if (searchType == "skill")
                {
                    List<ServiceSkill> serviceSkills = context.ServiceSkills
                        .Where(s => s.Skill.Name == searchTerm)
                        .Include(s => s.Service)
                        .ToList();

                    foreach (var service in serviceSkills)
                    {
                        Service foundService = context.Services
                            .Include(s => s.Provider)
                            .Single(s => s.Id == service.ServiceId);

                        List<ServiceSkill> displaySkills = context.JobSkills
                            .Where(ss => ss.ServiceId == foundService.Id)
                            .Include(ss => ss.Skill)
                            .ToList();

                        ServiceDetailViewModel newDisplayJob = new ServiceDetailViewModel(foundService, displaySkills);
                        displayServices.Add(newDisplayService);
                    }
                }
            }

            ViewBag.columns = ListController.ColumnChoices;
            ViewBag.title = "Services with " + ListController.ColumnChoices[searchType] + ": " + searchTerm;
            ViewBag.jobs = displayServices;

            return View("Index");
        }
    }
}
