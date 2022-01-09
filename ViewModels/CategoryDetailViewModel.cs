using Search4Support.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search4Support.ViewModels
{
    public class CategoryDetailViewModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<CategoryService> Services { get; set; }


        public CategoryDetailViewModel(Category theCategory, List<CategoryService> categoryServices)
        {
            Name = theCategory.Name;
            Services = categoryServices;
        }
    }
}
