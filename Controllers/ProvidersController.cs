using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Authorize]
    public class ProvidersController : Controller
    {
        private ServiceDbContext context;

        public ProvidersController(ServiceDbContext dbContext)
        {
            context = dbContext;
        }

        [AllowAnonymous]
        // GET: ProvidersController
        public IActionResult Index(string sortOrder, int? page)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            IQueryable<Provider> providers = context.Providers
                .Include(p => p.Services);

            switch (sortOrder)
            {
                case "name_desc":
                    providers = providers.OrderByDescending(p => p.Name);
                    break;
                default:
                    providers = providers.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(providers.ToPagedList(pageNumber, pageSize));

        }

        [AllowAnonymous]
        // GET: ProvidersController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Detail(int id)
        {
            
            Provider theProvider = context.Providers
                .Include(p => p.Services)
                .Single(p => p.Id == id);
         

            ProviderDetailViewModel viewModel = new ProviderDetailViewModel(theProvider);
            return View(viewModel);    

        }

        [HttpGet]
        public IActionResult Add()
        {
            AddProviderViewModel addProviderViewModel = new AddProviderViewModel();
            return View(addProviderViewModel);
        }

        [HttpPost]
        public IActionResult ProcessAddProviderForm(AddProviderViewModel addProviderViewModel)
        {
            if (ModelState.IsValid)
            {
                Provider newProvider = new Provider
                {
                    Name = addProviderViewModel.Name,
                    PhoneNumber = addProviderViewModel.PhoneNumber,
                    Address = addProviderViewModel.Address,
                    //MapLink = addProviderViewModel.MapLink,
                    Description = addProviderViewModel.Description
                };

                context.Providers.Add(newProvider);
                context.SaveChanges();

                return Redirect("/Categories");
            }

            return View("Add", addProviderViewModel);
        }
    }
}
