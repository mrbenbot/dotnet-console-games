using System.Collections.Generic;
using Xunit;
using Moq;

using Library.CardGame;

namespace Library.Tests
{
    public class HandTests
    {
        readonly static List<Card> _testCards = new List<Card>() { new Card(CardSuit.Clubs, CardValue.Ten), new Card(CardSuit.Hearts, CardValue.Three), new Card(CardSuit.Clubs, CardValue.Ace) };

        [Fact]
        public void Add_ShouldAddACard()
        {
            var hand = new Hand<Card>();

            hand.Add(new Card(CardSuit.Clubs, CardValue.Ten));

            int actual = hand.Cards.Count;
            int expected = 1;

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void Empty_ShouldReturnAllCards()
        {
            var hand = new Hand<Card>();

            foreach (var card in _testCards)
            {
                hand.Add(card);
            }

            List<Card> actual = hand.Empty();
            List<Card> expected = _testCards;

            Assert.Equal(expected, actual);
            Assert.Equal(string.Empty, hand.ToString());
            Assert.Empty(hand.Empty());
        }

        [Fact]
        public void Empty_ShouldEmptyList()
        {
            var hand = new Hand<Card>();

            foreach (var card in _testCards)
            {
                hand.Add(card);
            }

            hand.Empty();
            int actual = hand.Empty().Count;
            int expected = 0;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToString_ShouldReturnStringInCorrectFormat()
        {

            List<ICard> mockCards = new List<ICard>();
            for (int i = 0; i < 4; i++)
            {
                var mock = new Mock<Card>(CardSuit.Clubs, CardValue.Ace);
                mock.Setup(card => card.ToString()).Returns($"{i}");
                mockCards.Add(mock.Object);
            }

            var hand = new Hand<ICard>();

            foreach (var card in mockCards)
            {
                hand.Add(card);
            }

            string actual = hand.ToString();
            string expected = "0123";

            Assert.Equal(expected, actual);
        }
    }
}
