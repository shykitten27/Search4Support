using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Search4Support.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string AddressUrl { get; set; }
        public string Description {get; set;}
       
        //one:many Provider:Services
        public List<ProviderService> Services { get; set; }
      

        public Provider()
        {
        }
        //public string GetUrl(string address)
        //{
        //    string gMaps = "https://www.google.com/maps/place/";
        //    return gMaps + Uri.EscapeDataString(address);
        //}

        public Provider(string name, string phoneNumber, string address, string description, List<ProviderService> providerServices)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            AddressUrl = GetUrl(address);
            Description = description;
            Services = providerServices;
        }



        public override string ToString()
        {
            return Name;
        }
        public override bool Equals(object obj)
        {
            return obj is Provider provider &&
                   Id == provider.Id &&
                   Name == provider.Name &&
                   Address == provider.Address;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Address);
        }
    }
}
