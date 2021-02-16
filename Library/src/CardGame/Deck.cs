using System.Collections.Generic;
using System;
using System.Text;


namespace Library.CardGame
{
    public class Deck<CardType> : IDeck<CardType>
    {
        public List<CardType> Cards;
        public Deck(IEnumerable<CardType> cards)
        {
            Cards = new List<CardType>(cards);
        }

        public void Shuffle()
        {
            Random rand = new Random();
            int n = Cards.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                CardType value = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = value;
            }
        }

        public CardType Next()
        {
            CardType card = Cards[0];
            Cards.RemoveAt(0);
            return card;
        }

        public void Return(CardType card)
        {
            Cards.Add(card);
        }

        public void Return(IEnumerable<CardType> cards)
        {
            Cards.AddRange(cards);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var card in Cards)
            {
                sb.Append(card);
            }
            return sb.ToString();
        }

        public static List<CardType> GetDeckOfType(int numDecks = 1)
        {
            var suits = Enum.GetValues(typeof(CardSuit));
            var values = Enum.GetValues(typeof(CardValue));
            var cards = new List<CardType>();
            for (int i = 0; i < numDecks; i++)
            {
                foreach (CardSuit suit in suits)
                {
                    foreach (CardValue value in values)
                    {
                        var card = (CardType)Activator.CreateInstance(typeof(CardType), new object[] { suit, value });
                        cards.Add(card);
                    }
                }
            }
            return cards;
        }
    }
}


