using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gnostica.Models
{
    public class CardInCardList
    {
        public int ID { get; set; }
        public CardList Deck { get; set; }
        public Card Card { get; set; }
        public int Order { get; set; }

        public CardInCardList() { }

        public CardInCardList(CardList deck, Card card, int order = int.MaxValue)
        {
            Deck = deck;
            Card = card;
            Order = order;
        }
    }
}
