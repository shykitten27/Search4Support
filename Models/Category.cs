using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search4Support.Models
{
    public class Category
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<Service> Services { get; set; }

        public Category(string name)
        {
            Name = name;
        }

        public Category()
        {
        }

        public override bool Equals(object obj)
        {
            return obj is Category category &&

                   Id == category.Id &&
                   EqualityComparer<List<Service>>.Default.Equals(Services, category.Services);
        }
        
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Id, Services);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
