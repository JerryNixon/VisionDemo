using System;

namespace ClientApp.Models
{
    public static class Extensions
    {
        public static string GetValueString(this int value)
        {
            return value.ToString("D2");
        }

        public static char GetCharacter(this Demo01.Models.CardInfo card)
        {
            switch ((int)card.Tag)
            {
                case 01 when (card.Suit == Demo01.Models.Suits.Hearts): return 'N';
                case 02 when (card.Suit == Demo01.Models.Suits.Hearts): return 'O';
                case 03 when (card.Suit == Demo01.Models.Suits.Hearts): return 'P';
                case 04 when (card.Suit == Demo01.Models.Suits.Hearts): return 'Q';
                case 05 when (card.Suit == Demo01.Models.Suits.Hearts): return 'R';
                case 06 when (card.Suit == Demo01.Models.Suits.Hearts): return 'S';
                case 07 when (card.Suit == Demo01.Models.Suits.Hearts): return 'T';
                case 08 when (card.Suit == Demo01.Models.Suits.Hearts): return 'U';
                case 09 when (card.Suit == Demo01.Models.Suits.Hearts): return 'V';
                case 10 when (card.Suit == Demo01.Models.Suits.Hearts): return 'W';
                case 11 when (card.Suit == Demo01.Models.Suits.Hearts): return 'X';
                case 12 when (card.Suit == Demo01.Models.Suits.Hearts): return 'Y';
                case 13 when (card.Suit == Demo01.Models.Suits.Hearts): return 'Z';
                default:
                    throw new NotSupportedException(card.ToString());
            }
        }
    }
}
