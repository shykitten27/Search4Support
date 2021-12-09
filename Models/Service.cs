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
        public Provider Provider { get; set; }
        public int ProviderId { get; set; }
        public ServiceCategory Category { get; set; }
        public int CategoryId { get; set; }
        public Location Location { get; set; }
        public int LocationId { get; set; }
        public string Description { get; set; }
        public List<ServiceCategory> ServiceCategories { get; set; }
        public List<ServiceTag> ServiceTags { get; set; }

        public Service()
        {
        }
        public Service(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override bool Equals(object obj)
        {
            return obj is Service service &&
                   Id == service.Id &&
                   Name == service.Name &&
                   EqualityComparer<Provider>.Default.Equals(Provider, service.Provider) &&
                   ProviderId == service.ProviderId &&
                   EqualityComparer<ServiceCategory>.Default.Equals(Category, service.Category) &&
                   CategoryId == service.CategoryId &&
                   EqualityComparer<Location>.Default.Equals(Location, service.Location) &&
                   LocationId == service.LocationId &&
                   Description == service.Description &&
                   EqualityComparer<List<ServiceCategory>>.Default.Equals(ServiceCategories, service.ServiceCategories) &&
                   EqualityComparer<List<ServiceTag>>.Default.Equals(ServiceTags, service.ServiceTags);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Name);
            hash.Add(Provider);
            hash.Add(ProviderId);
            hash.Add(Category);
            hash.Add(CategoryId);
            hash.Add(Location);
            hash.Add(LocationId);
            hash.Add(Description);
            hash.Add(ServiceCategories);
            hash.Add(ServiceTags);
            return hash.ToHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
