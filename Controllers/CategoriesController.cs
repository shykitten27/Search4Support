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
    public class CategoriesController : Controller

    {
        private ServiceDbContext context;

        public CategoriesController(ServiceDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: CategoriesController
        public IActionResult Index()
        {
            List<Category> categories = context.Categories
                .Include(c => c.Services)
                .ToList();
            return View(categories);
        }


        // GET: ProvidersController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }


        public IActionResult Detail(int id)
        {

            Category theCategory = context.Categories
                .Include(p => p.Services)
                .Single(p => p.Id == id);

            

            CategoryDetailViewModel viewModel = new CategoryDetailViewModel(theCategory);
            return View(viewModel);     
        }
    }
}
