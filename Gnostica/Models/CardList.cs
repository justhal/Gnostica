using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gnostica.Models
{
    public class CardList
    {
        public int ID { get; set; }

        public List<CardInCardList> Cards { get; set; }

        public CardList() : this(empty: true) { }

        public CardList(bool empty, ushort capacity = GnosticaParameters.TAROT_CARDS_PER_DECK)
        {
            Cards = new List<CardInCardList>(capacity);
        }

        public void Initialize(bool empty, bool shuffle = false)
        {
            if (!empty)
            {
                int order = 0;

                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                    {
                        this.Cards.Add(new CardInCardList(this, new Card(rank, suit), order++));
                    }
                }

                foreach (MajorArcana majorArcana in Enum.GetValues(typeof(MajorArcana)))
                {
                    this.Cards.Add(new CardInCardList(this, new Card(majorArcana), order++));
                }
            }

            if (shuffle)
            {
                Shuffle();
            }
        }

        public void Shuffle()
        {
            Random rng = new Random();
            var shuffled =
                from card in this.Cards
                orderby rng.Next()
                select card;
            var newDeck = shuffled.ToList();
            this.Cards.Clear();
            int order = 0;
            foreach (var card in newDeck)
            {
                card.Order = order++;
                this.Cards.Add(card);
            }
        }

        public Card Draw()
        {
            var card = Cards[0].Card;
            Cards.RemoveAt(0);
            return card;
        }

        public override String ToString()
        {
            return $"{Cards.Count}-card deck";
        }
    }
}
