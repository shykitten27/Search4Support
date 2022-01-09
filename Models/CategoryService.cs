using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search4Support.Models
{
    public class CategoryService
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }


        public CategoryService()
        {
        }

        public override string ToString()
        {
            return Service.Name;
        }
    }
}
