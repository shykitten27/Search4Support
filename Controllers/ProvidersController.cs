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

        // GET: ProvidersController
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

        
        public IActionResult Detail(int id)
        {
            
            Provider theProvider = context.Providers
                .Include(p => p.Services)
                .Single(p => p.Id == id);

            ProviderDetailViewModel viewModel = new ProviderDetailViewModel(theProvider);
            return View(viewModel);     
        }
    }
}
