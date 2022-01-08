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
            List<Provider> providers = context.Providers
                .Include(p => p.Services)
                .ToList();
            return View(providers);
        }
        

      
        //TODO: Having issues coming from Service Detail to Provider Detail - 
        public IActionResult Detail(int id)
        {
            //System.InvolvedOperationException: 'Sequence contains no elements'
            Provider theProvider = context.Providers
                .Include(p => p.Services)
                .Single(p => p.Id == id);
            //System.InvalidOperationException 'Lambda expression used inside Include is not valid'
            List<Service> services = context.Services
                .Where(s => s.ProviderId== id)
                .Include(s => s.Name)
                .ToList();

            ProviderDetailViewModel viewModel = new ProviderDetailViewModel(theProvider, services);
            return View(viewModel);
        }
    }
}
