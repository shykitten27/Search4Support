﻿using Search4Support.Models;
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
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public List<ProviderService> Services { get; set; }
        public string ServicesText { get; set; }
      
        

        
        public ProviderDetailViewModel(Provider theProvider, List<ProviderService> providerServices)
        {
            ProviderId = theProvider.Id;
            Name = theProvider.Name;
            PhoneNumber = theProvider.PhoneNumber;
            Address = theProvider.Address;
            Description = theProvider.Description;
            Services = theProvider.Services;
            
            ServicesText = "";

            for (int i = 0; i < providerServices.Count; i++)
            {
                ServicesText += providerServices[i].Service.Name;
                if(i < providerServices.Count - 1)
                {
                    ServicesText += ", ";
                }
            }
        }

       
    }
}
