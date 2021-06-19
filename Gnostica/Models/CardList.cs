using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gnostica.Models
{
    public class CardList
    {
        public int ID { get; set; }
        public Card Card { get; set; }
        public int Order { get; set; }
    }
}
