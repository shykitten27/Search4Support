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
        public Location Location { get; set; }
        public int LocationId { get; set; }

        public Provider()
        {
        }
        public Provider(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            return obj is Provider provider &&
                   Id == provider.Id &&
                   Name == provider.Name &&
                   EqualityComparer<Location>.Default.Equals(Location, provider.Location) &&
                   LocationId == provider.LocationId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Location, LocationId);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
