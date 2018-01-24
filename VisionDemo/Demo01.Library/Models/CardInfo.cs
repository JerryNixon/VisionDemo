using System;

namespace Demo01.Models
{
    public enum Suits
    {
        Hearts, Clubs, Spades, Diamonds
    }

    public class CardInfo
    {
        public CardInfo(string tag)
        {
            Tag = Enum.Parse<Tags>(tag);
            Suit = Suits.Hearts;
            switch (Tag)
            {
                case Tags.Ace:
                    Value = 1;
                    break;
                case Tags.Jack:
                    Value = 11;
                    break;
                case Tags.Queen:
                    Value = 12;
                    break;
                case Tags.King:
                    Value = 13;
                    break;
                default:
                    throw new NotSupportedException(Tag.ToString());
            }
        }
        public Suits Suit { get; }
        public Tags Tag { get; }
        public int Value { get; }
    }
}
