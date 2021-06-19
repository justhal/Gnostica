using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Gnostica.Models
{
    public class Card : Target
    {
        public int ID { get; set; }
        public Suit? Suit { get; set; }
        public Rank? Rank { get; set; }
        public MajorArcana? MajorArcana { get; set; }
        public Type Type
        {
            get
            {
                if(Rank == Models.Rank.Ace
                    || Rank == Models.Rank.Two
                    || Rank == Models.Rank.Three
                    || Rank == Models.Rank.Four
                    || Rank == Models.Rank.Five
                    || Rank == Models.Rank.Six
                    || Rank == Models.Rank.Seven
                    || Rank == Models.Rank.Eight
                    || Rank == Models.Rank.Nine
                    || Rank == Models.Rank.Ten)
                {
                    return Type.Number;
                } else if (Rank == Models.Rank.Page
                    || Rank == Models.Rank.Knight
                    || Rank == Models.Rank.Queen
                    || Rank == Models.Rank.King)
                {
                    return Type.Royalty;
                }
                else
                {
                    return Type.MajorArcana;
                }
            }
        }
        public bool Valid { get { return IsValid(); } }

        public byte? RankNumber
        {
            get
            {
                if(Type == Type.Number)
                {
                    return (byte)Rank.Value;
                } else if(Type == Type.Royalty)
                {
                    return (byte)Rank.Value;
                } else
                {
                    return null;
                }
            }
        }

        public byte BidValue
        {
            get
            {
                if(Type == Type.Number)
                {
                    return RankNumber.Value;
                } else if(Type == Type.Royalty)
                {
                    return RankNumber.Value;
                } else
                {
                    return (byte)((byte)Models.Rank.King + (byte)MajorArcana.Value + 1);
                }
            }
        }

        public byte PointValue
        {
            get
            {
                if(Type == Type.Number)
                {
                    return 1;
                } else if(Type == Type.Royalty)
                {
                    return 2;
                } else if(Type == Type.MajorArcana)
                {
                    return 3;
                } else
                {
                    // This should never happen.
                    return 0;
                }
            }
        }

        public Card() { }

        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
            MajorArcana = null;
        }

        public Card(MajorArcana majorArcana)
        {
            Rank = null;
            Suit = null;
            MajorArcana = majorArcana;
        }

        public bool IsValid()
        {
            if(Type == Type.Number)
            {
                if(Suit != null && MajorArcana == null)
                {
                    return true;
                } else
                {
                    return false;
                }
            } else if(Type == Type.Royalty)
            {
                if(Suit != null && MajorArcana == null)
                {
                    return true;
                } else
                {
                    return false;
                }
            } else if(Type == Type.MajorArcana)
            {
                if(Suit == null && MajorArcana != null)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
            return false;
        }

        public override string ToString()
        {
            if(Type == Type.Number)
            {
                return $"{Rank.Value} of {Suit.Value}";
            } else if(Type == Type.Royalty)
            {
                return $"{Rank.Value} of {Suit.Value}";
            } else
            {
                switch (MajorArcana)
                {
                    case (Models.MajorArcana.Fool):
                        return "The Fool";
                    case (Models.MajorArcana.Magician):
                        return "The Magician";
                    case (Models.MajorArcana.HighPriestess):
                        return "The High Priestess";
                    case (Models.MajorArcana.Empress):
                        return "The Empress";
                    case (Models.MajorArcana.Emperor):
                        return "The Emperor";
                    case (Models.MajorArcana.Hierophant):
                        return "The Hierophant";
                    case (Models.MajorArcana.Lovers):
                        return "The Lovers";
                    case (Models.MajorArcana.Chariot):
                        return "The Chariot";
                    case (Models.MajorArcana.Strength):
                        return "Strength";
                    case (Models.MajorArcana.Hermit):
                        return "The Hermit";
                    case (Models.MajorArcana.WheelOfFortune):
                        return "Wheel of Fortune";
                    case (Models.MajorArcana.Justice):
                        return "Justice";
                    case (Models.MajorArcana.HangedMan):
                        return "The Hanged Man";
                    case (Models.MajorArcana.Death):
                        return "Death";
                    case (Models.MajorArcana.Temperence):
                        return "Temperence";
                    case (Models.MajorArcana.Devil):
                        return "The Devil";
                    case (Models.MajorArcana.Tower):
                        return "The Tower";
                    case (Models.MajorArcana.Star):
                        return "The Star";
                    case (Models.MajorArcana.Moon):
                        return "The Moon";
                    case (Models.MajorArcana.Sun):
                        return "The Sun";
                    case (Models.MajorArcana.Judgment):
                        return "Judgment";
                    case (Models.MajorArcana.World):
                        return "The World";
                }
            }
            // This should never happen.
            return base.ToString();
        }
    }

    public enum Suit
    {
        Cups,
        Rods,
        Discs,
        Swords
    }

    public enum Rank
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Page = 11,
        Knight = 12,
        Queen = 13,
        King = 14
    }

    public enum Type
    {
        Number,
        Royalty,
        MajorArcana
    }

    public enum MajorArcana
    {
        Fool = 0,
        Magician = 1,
        HighPriestess = 2,
        Empress = 3,
        Emperor = 4,
        Hierophant = 5,
        Lovers = 6,
        Chariot = 7,
        Strength = 8,
        Hermit = 9,
        WheelOfFortune = 10,
        Justice = 11,
        HangedMan = 12,
        Death = 13,
        Temperence = 14,
        Devil = 15,
        Tower = 16,
        Star = 17,
        Moon = 18,
        Sun = 19,
        Judgment = 20,
        World = 21
    }
}
