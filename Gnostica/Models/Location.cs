using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gnostica.Models
{
    public class Location
    {
        public int ID { get; set; }
        public sbyte? X { get; set; }
        public sbyte? Y { get; set; }
        public bool Stash { get; set; }
    }
}
