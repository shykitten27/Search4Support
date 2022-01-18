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
        public List<Service> Services { get; set; }
        public List<Provider> Providers { get; set; }


        public CategoryDetailViewModel(Category theCategory)
        {
            Name = theCategory.Name;
            Services = theCategory.Services;
        }
    }
}
