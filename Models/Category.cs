using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search4Support.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }


        //one:many Category:Services
        public List<Service> Services { get; set; }


        public Category(string name)
        {
            Name = name;
        }
        public Category()
        {
        }

        public override string ToString()
        {
            return Name;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


    }
}
