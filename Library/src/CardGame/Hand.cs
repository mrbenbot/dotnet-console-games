using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;



namespace Library.CardGame
{
    public class Hand<CardType> : IHand<CardType>
    {
        public List<CardType> Cards { get; set; }
        public Hand()
        {
            Cards = new List<CardType>();
        }

        public Hand(List<CardType> cards)
        {
            Cards = cards;
        }

        public void Add(CardType card)
        {
            Cards.Add(card);
        }

        public List<CardType> Empty()
        {
            var cards = new List<CardType>(Cards);
            Cards.Clear();
            return cards;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var card in Cards)
            {
                sb.Append(card.ToString());
            }
            return sb.ToString();
        }
    }
}