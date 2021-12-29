using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Search4Support.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Search4Support.ViewModels
{
    public class AddServiceTagViewModel
    {
        [Required(ErrorMessage = "Service is required")]
        public int ServiceId { get; set; }

        [Required(ErrorMessage = "Tag is required")]
        public int TagId { get; set; }

        public Service Service { get; set; }

        public List<SelectListItem> Tags { get; set; }

        public AddServiceTagViewModel(Service theService, List<Tag> possibleTags)
        {
            Tags = new List<SelectListItem>();

            foreach (var tag in possibleTags)
            {
                Tags.Add(new SelectListItem
                {
                    Value = tag.Id.ToString(),
                    Text = tag.Name
                });
            }

            Service = theService;
        }

        public AddServiceTagViewModel()
        {
        }
    }
}