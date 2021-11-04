using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gnostica.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        
        public List<PlayerGame> PlayerGames { get; set; }

        public void Initialize()
        {
            PlayerGames = new List<PlayerGame>(GnosticaParameters.MAX_EXPECTED_GAMES_PER_PLAYER);
        }
    }
}
