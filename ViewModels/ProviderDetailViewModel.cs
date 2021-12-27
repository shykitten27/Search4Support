using Search4Support.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search4Support.ViewModels
{
    public class ProviderDetailViewModel
    {
        public int ProviderId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        //public string Description { get; set; }
        public List<Service> Services { get; set; }

        
        public ProviderDetailViewModel(Provider theProvider)
        {
            ProviderId = theProvider.Id;
            Name = theProvider.Name;
            Address = theProvider.Address;
            //Description = theProvider.Description;
            Services = theProvider.Services;
        }


    }
}
