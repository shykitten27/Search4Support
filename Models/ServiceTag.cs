using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search4Support.Models
{
    public class ServiceTag
    {
        //not Id field since the ServiceId AND TagId pair function as primary key 
        //since event and tag should only be related once
        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }

        public ServiceTag()
        {
        }

        public override bool Equals(object obj)
        {
            return obj is ServiceTag tag &&
                   ServiceId == tag.ServiceId &&
                   EqualityComparer<Service>.Default.Equals(Service, tag.Service) &&
                   TagId == tag.TagId &&
                   EqualityComparer<Tag>.Default.Equals(Tag, tag.Tag);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ServiceId, Service, TagId, Tag);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
