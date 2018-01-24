using System;

namespace Demo01.Models
{
    public static partial class Extensions
    {
        public static Tags ToTagsEnum(this string tagString)
        {
            return Enum.Parse<Tags>(tagString);
        }

        public static bool IsCardTag(this Tags tag)
        {
            switch (tag)
            {
                case Tags.Ace:
                case Tags.Two:
                case Tags.Three:
                case Tags.Four:
                case Tags.Five:
                case Tags.Six:
                case Tags.Seven:
                case Tags.Eight:
                case Tags.Nine:
                case Tags.Ten:
                case Tags.Jack:
                case Tags.Queen:
                case Tags.King:
                    return true;
                default:
                    return false;
            }
        }
    }
}
