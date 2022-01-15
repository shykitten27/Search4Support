using Microsoft.AspNetCore.Mvc.Rendering;
using Search4Support.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Search4Support.ViewModels
{
    public class AddServiceViewModel
    {
        [Required(ErrorMessage ="Name of service is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description of service is required.")]
        [StringLength(500,MinimumLength = 3, ErrorMessage = "Description must be at least 3 and no more than 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="Provider is required.")]
        public int ProviderId { get; set; }

        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Providers { get; set; }

        //constructor takes a list of ServiceCategory
        public AddServiceViewModel(List<Category> categories, List<Provider> providers)
        {
            //create a new Categories listitem by looping thru all of the 
            //categories and adding them to the collection
            Categories = new List<SelectListItem>();
            foreach (var category in categories)
            {
                Categories.Add(
                    new SelectListItem
                    {
                        Value = category.Id.ToString(),
                        Text = category.Name
                    }
                ); ;
            }
            //create a new Providers listitem by looping thru all of the 
            //providers and adding them to the collection
            Providers = new List<SelectListItem>();
            foreach (var provider in providers)
            {
                Providers.Add(
                    new SelectListItem
                    {
                        Value = provider.Id.ToString(),
                        Text = provider.Name
                    }
                ); ;
            }
        }

        public AddServiceViewModel() { }
    }
}