using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gnostica.Models
{
    public class Deck
    {
        public int ID { get; set; }

        public List<DeckList> DeckList { get; set; }

        public Deck() : this(empty: true) { }

        public Deck(bool empty)
        {
            DeckList = new List<DeckList>();
            Initialize(empty);
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
                        this.DeckList.Add(new DeckList(this, new Card(rank, suit), order++));
                    }
                }

                foreach (MajorArcana majorArcana in Enum.GetValues(typeof(MajorArcana)))
                {
                    this.DeckList.Add(new DeckList(this, new Card(majorArcana), order++));
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
                from card in this.DeckList
                orderby rng.Next()
                select card;
            var newDeck = shuffled.ToList();
            this.DeckList.Clear();
            int order = 0;
            foreach (var card in newDeck)
            {
                card.Order = order++;
                this.DeckList.Add(card);
            }
        }

        public override String ToString()
        {
            return $"{DeckList.Count}-card deck";
        }
    }
}
