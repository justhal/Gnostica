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
        public CardLocation? cardLocation { get; set; }

        public enum CardLocation
        {
            Hand,
            Board,
            Deck,
            Discards
        }

        public bool IsValid()
        {
            if(Stash)
            {
                if(X == null && Y == null && cardLocation == null)
                {
                    return true;
                }
            } else
            {
                if(cardLocation == CardLocation.Board)
                {
                    if(X != null && Y != null)
                    {
                        return true;
                    }
                } else
                {
                    if(X == null && Y == null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
