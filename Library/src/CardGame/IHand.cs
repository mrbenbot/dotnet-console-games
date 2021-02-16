using System.Collections.Generic;

namespace Library.CardGame
{
    public interface IHand<CardType>
    {
        void Add(CardType card);
        List<CardType> Empty();

        string ToString();
    }
}