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
    public class ProvidersController : Controller
    {
        private ServiceDbContext context;

        public ProvidersController(ServiceDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: ServicesController
        public IActionResult Index()
        {
            //System.InvalidOperationException: 'Sequence contains no elements'
            List<Provider> providers = context.Providers
                .Include(p => p.Services)
                .ToList();
            return View(providers);
        }


        // GET: ProvidersController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        //TODO: Having issues coming from Service Detail to Provider Detail - 
        public IActionResult Detail(int id)
        {
            //System.InvolvedOperationException: 'Sequence contains no elements'
            Provider theProvider = context.Providers
                .Include(p => p.Services)
                .Single(p => p.Id == id);

            List<ProviderService> providerServices = context.ProviderServices
                .Where(ps => ps.ServiceId== id)
                .Include(ps => ps.Provider)
                .Include(ps => ps.Service)
                .ToList();

            ProviderDetailViewModel viewModel = new ProviderDetailViewModel(theProvider, providerServices);
            return View(viewModel);
        }
    }
}
