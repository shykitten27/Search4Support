using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search4Support.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Description {get; set;}
       
        //one:many Provider:Services
        public List<Service> Services { get; set; }
        
      

        public Provider()
        {
        }
        public Provider(string name, string phoneNumber, string address, string description)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            Description = description;
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
            return HashCode.Combine(Id, Name, PhoneNumber, Address, Description);
        }
    }
}
