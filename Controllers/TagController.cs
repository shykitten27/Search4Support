using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Search4Support.Data;
using Search4Support.Models;
using Search4Support.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using X.PagedList;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Search4Support.Controllers
{
    [Authorize]
    public class TagController : Controller
    {
        private ServiceDbContext context;

        public TagController(ServiceDbContext dbContext)
        {
            context = dbContext;
        }

        [AllowAnonymous]
        // GET: /<controller>/
        public IActionResult Index(string sortOrder, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            IQueryable<Tag> tags = context.Tags;

            switch (sortOrder)
            {
                case "name_desc":
                    tags = tags.OrderByDescending(t => t.Name);
                    break;
                default:
                    tags = tags.OrderBy(t => t.Name);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(tags.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult Add()
        {
            Tag tag = new Tag();
            return View(tag);
        }

        [HttpPost]
        public IActionResult Add(Tag tag)
        {
            if (ModelState.IsValid)
            {
                context.Tags.Add(tag);
                context.SaveChanges();
                return Redirect("/Tag/");
            }

            return View("Add", tag);
        }

        public IActionResult AddService(int id)
        {
            Service theService = context.Services.Find(id);
            List<Tag> possibleTags = context.Tags.OrderBy(t => t.Name).ToList();

            AddServiceTagViewModel viewModel = new AddServiceTagViewModel(theService, possibleTags);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddService(AddServiceTagViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                int serviceId = viewModel.ServiceId;
                int tagId = viewModel.TagId;

                List<ServiceTag> existingItems = context.ServiceTags
                    .Where(st => st.ServiceId == serviceId)
                    .Where(st => st.TagId == tagId)
                    .ToList();

                if (existingItems.Count == 0)
                {
                    ServiceTag serviceTag = new ServiceTag
                    {
                        ServiceId = serviceId,
                        TagId = tagId
                    };

                    context.ServiceTags.Add(serviceTag);
                    context.SaveChanges();
                }
                return Redirect("/Services/Detail/" + serviceId);
            }

            return View(viewModel);
        }

        [AllowAnonymous]
        public IActionResult Detail(int id)
        {
            //query all service tags where the id matches the service and eager fetch the Service and Tag data
            //then convert to a list and return the view as service tags as the model object
            List<ServiceTag> serviceTags = context.ServiceTags
                .Where(st => st.TagId == id)
                .Include(st => st.Service)
                .Include(st => st.Tag)
                .ToList();

            return View(serviceTags);
        }
    }
}