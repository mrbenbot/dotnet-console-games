using Library.CardGame;

namespace Pontoon
{
    public class PontoonCard : Card, IPontoonCard
    {

        public PontoonCard(CardSuit suit, CardValue value) : base(suit, value) { }

        public int MinValue
        {
            get
            {
                return GetValue(false);
            }
        }
        public int MaxValue
        {
            get
            {
                return GetValue(true);
            }
        }
        int GetValue(bool aceHigh)
        {
            switch (Value)
            {
                case CardValue.Ace:
                    return aceHigh ? 11 : 1;
                case CardValue.Ten:
                case CardValue.Jack:
                case CardValue.Queen:
                case CardValue.King:
                    return 10;
                default:
                    return (int)Value + 1;
            }
        }
    }
}