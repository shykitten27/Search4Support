using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search4Support.Models
{
    public class ServiceCategory
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<Service> services { get; set; }

        public ServiceCategory(string name)
        {
            Name = name;
        }
        public ServiceCategory()
        {
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
