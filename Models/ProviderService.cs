using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search4Support.Models
{
    public class ProviderService
    {
        //public int Id { get; set; }
        public int ProviderId { get; set;}
        public Provider Provider { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public ProviderService()
        {
        }

        public override string ToString()
        {
            return Service.Name;
        }
    }
}
