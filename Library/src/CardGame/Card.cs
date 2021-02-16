using System.Collections.Generic;

namespace Library.CardGame
{
    public class Card : ICard
    {
        public static Dictionary<CardSuit, string> SuitDictionary = new Dictionary<CardSuit, string>() { { CardSuit.Clubs, "♧" }, { CardSuit.Diamonds, "♢" }, { CardSuit.Hearts, "♡" }, { CardSuit.Spades, "♤" }, };
        public static Dictionary<CardValue, string> ValueDictionary = new Dictionary<CardValue, string>() { { CardValue.Ace, "A" }, { CardValue.Two, "2" }, { CardValue.Three, "3" }, { CardValue.Four, "4" }, { CardValue.Five, "5" }, { CardValue.Six, "6" }, { CardValue.Seven, "7" }, { CardValue.Eight, "8" }, { CardValue.Nine, "9" }, { CardValue.Ten, "10" }, { CardValue.Jack, "J" }, { CardValue.Queen, "Q" }, { CardValue.King, "K" } };
        public CardSuit Suit { get; }
        public CardValue Value { get; }

        public Card(CardSuit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        }

        public override string ToString()
        {
            return $"[ {ValueDictionary[Value]}{SuitDictionary[Suit]} ]";
        }
    }
}