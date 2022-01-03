using Search4Support.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search4Support.ViewModels
{
    public class ServiceListViewModel
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public string CategoryName { get; set; }


        public ServiceListViewModel(Service theService)
        {
            ServiceId = theService.Id;
            Name = theService.Name;
            ProviderName = theService.Provider.Name;
            CategoryName = theService.Category.Name;
         
        }

    }
}
