using System.Collections.Generic;
using System;


namespace Library.CardGame
{
    public interface IDeck<CardType>
    {
        string ToString();
        void Shuffle();
        CardType Next();
        void Return(CardType card);
        void Return(IEnumerable<CardType> cards);
    }
}
