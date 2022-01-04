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
        

      

        public IActionResult Detail(int id)
        {
            Provider theProvider = context.Providers
                .Include(p => p.Services)
                .Single(s => s.Id == id);
            List<ProviderService> services = context.ProviderServices
                .Where(ps => ps.ProviderId== id)
                .Include(ps => ps.Provider)
                .Include(ps => ps.Service)
                .ToList();

            ProviderDetailViewModel viewModel = new ProviderDetailViewModel(theProvider, services);
            return View(viewModel);
        }
    }
}
