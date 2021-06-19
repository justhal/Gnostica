using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gnostica.Models
{
    public class Game
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Player> Players { get; set; }
        public Deck Deck { get; set; }
        public ushort Turn { get; set; }
        public ushort Round { get; set; }
    }
}
