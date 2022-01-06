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
        public ServiceCategory Category { get; set; }
        public int CategoryId { get; set; }
     


        public Service()
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
