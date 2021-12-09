﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search4Support.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public Tag(string name)
        {
            Name = name;
        }
        public Tag()
        {
        }

        public override bool Equals(object obj)
        {
            return obj is Tag tag &&
                   Id == tag.Id &&
                   Name == tag.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
