﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search4Support.Models
{
    public class Location
    {
        public int Id { get; set; }
        /*public string Name { get; set; }*/
        public string Address { get; set; }

        public Location(string name, string address)
        {
            /*Name = name;*/
            Address = address;
        }
        public Location()
        {
        }

        public override bool Equals(object obj)
        {
            return obj is Location location &&
                   Id == location.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
