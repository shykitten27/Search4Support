using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search4Support.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        //one:one Service:Provider
        public Provider Provider { get; set; }
        public int ProviderId { get; set; }
       


        //one:one Service:ServiceCategory
        public Category Category { get; set; }
        public int CategoryId { get; set; }
       

        public Service()
        {
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is Service service &&
                   Id == service.Id &&
                   Name == service.Name &&
                   Description == service.Description &&
                   EqualityComparer<Provider>.Default.Equals(Provider, service.Provider) &&
                   ProviderId == service.ProviderId &&
                   EqualityComparer<Category>.Default.Equals(Category, service.Category) &&
                   CategoryId == service.CategoryId;
            
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
