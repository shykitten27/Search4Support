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
        public List<Service> Services { get; set; }

        public ServiceCategory(string name)
        {
            Name = name;
        }
        public ServiceCategory()
        {
        }
    }
}
