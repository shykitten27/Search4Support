using Search4Support.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search4Support.ViewModels
{
    public class CategoryListViewModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }


        public CategoryListViewModel(Category theCategory)
        {
            Name = theCategory.Name;
        }
    }
}
