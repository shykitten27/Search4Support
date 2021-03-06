using Search4Support.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search4Support.ViewModels
{
    public class ProviderListViewModel
    {
        public int ProviderId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string MapLink { get; set; }





        public ProviderListViewModel(Provider theProvider)
        {
            ProviderId = theProvider.Id;
            Name = theProvider.Name;
            PhoneNumber = theProvider.PhoneNumber;
            Address = theProvider.Address;
            MapLink = theProvider.MapLink;
        }
    }
}
