using System;
using Library.CardGame;

namespace Pontoon
{
    public interface IPontoonHand : IHand<IPontoonCard>, IComparable
    {
        int MinValue { get; }

        int BestValue { get; }

        bool IsBust { get; }

        bool IsFiveCardTrick { get; }

        bool IsPontoon { get; }

    }
}