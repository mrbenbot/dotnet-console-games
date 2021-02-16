using System.Collections.Generic;
using System.Linq;
using Library.CardGame;

namespace Pontoon
{
    public class PontoonHand : Hand<IPontoonCard>, IPontoonHand
    {
        bool _isDealer;
        public PontoonHand(bool isDealer) : base()
        {
            _isDealer = isDealer;
        }

        public PontoonHand(bool isDealer, List<IPontoonCard> cards) : base(cards)
        {
            _isDealer = isDealer;
        }

        public int MinValue
        {
            get
            {
                return Cards.Aggregate(0, (acc, cur) => acc + cur.MinValue);
            }
        }

        public int BestValue
        {
            get
            {
                int value = MinValue;
                int numAces = Cards.FindAll(c => c.Value == CardValue.Ace).Count;
                for (int i = 0; i < numAces; i++)
                {
                    int nextValue = value + 10;
                    if (nextValue > 21)
                    {
                        return value;
                    }
                    value = nextValue;
                }
                return value;
            }
        }

        public bool IsBust
        {
            get
            {
                return MinValue > 21;
            }
        }

        public bool IsFiveCardTrick
        {
            get
            {
                return Cards.Count >= 5 && !IsBust;
            }
        }

        public bool IsPontoon
        {
            get
            {
                return Cards.Count == 2 && BestValue == 21;
            }
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            PontoonHand otherHand = obj as PontoonHand;
            // Hands with more than 21 points are bust and are worthless. 
            if (otherHand.IsBust && !IsBust)
            {
                return 1;
            }
            if (IsBust && !otherHand.IsBust)
            {
                return -1;
            }
            if (IsBust && otherHand.IsBust)
            {
                if (_isDealer)
                {
                    return 1;
                }
                return -1;
            }
            // The best hand of all is a Pontoon, which is 21 points in two cards - this can only consist of ace plus a picture card or ten.
            if (IsPontoon && !otherHand.IsPontoon)
            {
                return 1;
            }
            if (!IsPontoon && otherHand.IsPontoon)
            {
                return -1;
            }
            if (IsPontoon && otherHand.IsPontoon)
            {
                if (_isDealer)
                {
                    return 1;
                }
                return -1;
            }
            // Next best after a Pontoon is a Five Card Trick, which is a hand of five cards totaling 21 or less.
            if (IsFiveCardTrick && !otherHand.IsFiveCardTrick)
            {
                return 1;
            }
            if (!IsFiveCardTrick && otherHand.IsFiveCardTrick)
            {
                return -1;
            }
            if (IsFiveCardTrick && otherHand.IsFiveCardTrick)
            {
                if (BestValue == otherHand.BestValue)
                {
                    if (_isDealer)
                    {
                        return 1;
                    }
                    return -1;
                }
                return BestValue - otherHand.BestValue;
            }
            int diff = BestValue - otherHand.BestValue;

            if (diff == 0)
            {
                if (_isDealer)
                {
                    return 1;
                }
                return -1;
            }
            return diff;
        }
    }
}