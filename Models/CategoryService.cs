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

        public override bool Equals(object obj)
        {
            return obj is CategoryService service &&
                   CategoryId == service.CategoryId &&
                   EqualityComparer<Category>.Default.Equals(Category, service.Category) &&
                   ServiceId == service.ServiceId &&
                   EqualityComparer<Service>.Default.Equals(Service, service.Service);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CategoryId, Category, ServiceId, Service);
        }
    }
}
