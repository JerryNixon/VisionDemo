using System;
using Demo01.Json;

namespace Demo01.Models
{
    public enum Suits
    {
        Hearts, Clubs, Spades, Diamonds
    }

    public class CardInfo
    {
        public CardInfo()
        {

        }

        public CardInfo(Prediction prediction)
        {
            Tag = prediction.Tag.ToTagsEnum();
            Suit = Suits.Hearts;
            Probility = prediction.Probability;
        }

        public Suits Suit { get; set;  }
        public double Probility { get; set; }
        public Tags Tag { get; set;  }
        public int Value => Math.Min(10, (int)Tag);

        public override string ToString()
        {
            return $"{Tag} of {Suit} @ {Probility}";
        }
    }
}
