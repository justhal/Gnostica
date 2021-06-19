using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gnostica.Models
{
    public class DeckList
    {
        public int ID { get; set; }
        public Deck Deck { get; set; }
        public Card Card { get; set; }
        public int Order { get; set; }

        public DeckList() { }

        public DeckList(Deck deck, Card card, int order)
        {
            Deck = deck;
            Card = card;
            Order = order;
        }
    }
}
