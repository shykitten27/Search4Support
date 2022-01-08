using Search4Support.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Search4Support.ViewModels
{
    public class ServiceDetailViewModel
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public string CategoryName { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        public ServiceDetailViewModel(Service theService)
        {
            ServiceId = theService.Id;
            Name = theService.Name;
            ProviderName = theService.Provider.Name;
            CategoryName = theService.Category.Name;
            Address = theService.Provider.Address;
            Description = theService.Description;

        }
    }
}