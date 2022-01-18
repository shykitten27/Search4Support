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
        public string MapLink { get; set; }
        public string Description {get; set;}
       
        //one:many Provider:Services
        public List<Service> Services { get; set; }
        public List<Provider> Providers { get; internal set; }

        public Provider()
        {
        }

        public Provider(string name, string phoneNumber, string address, string description)
        {
            string addressUrl = "https://www.google.com/maps/place/" + address.UrlEncode();
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            MapLink = addressUrl;
            Description = description;
            
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
            return Name;
        }
    }
}
