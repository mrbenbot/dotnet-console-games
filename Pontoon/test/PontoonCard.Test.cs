using System;
using Xunit;

using Library.CardGame;
using Pontoon;

namespace Tests
{
    public class CardTest
    {
        [Theory]
        [InlineData(CardSuit.Diamonds, CardValue.Two, 2)]
        [InlineData(CardSuit.Spades, CardValue.Five, 5)]
        [InlineData(CardSuit.Clubs, CardValue.Six, 6)]
        [InlineData(CardSuit.Hearts, CardValue.Ten, 10)]
        public void MaxValue_NumberCard_ShouldBeNumber(CardSuit suit, CardValue value, int expected)
        {
            var card = new PontoonCard(suit, value);
            int actual = card.MaxValue;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(CardSuit.Diamonds, CardValue.Two, 2)]
        [InlineData(CardSuit.Spades, CardValue.Five, 5)]
        [InlineData(CardSuit.Clubs, CardValue.Six, 6)]
        [InlineData(CardSuit.Hearts, CardValue.Ten, 10)]
        public void MinValue_NumberCard_ShouldBeNumber(CardSuit suit, CardValue value, int expected)
        {
            var card = new PontoonCard(suit, value);
            int actual = card.MinValue;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MinValue_Ace_ShouldBe1()
        {
            var card = new PontoonCard(CardSuit.Spades, CardValue.Ace);

            int actual = card.MinValue;
            int expected = 1;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MaxValue_Ace_ShouldBe11()
        {
            var card = new PontoonCard(CardSuit.Spades, CardValue.Ace);

            int actual = card.MaxValue;
            int expected = 11;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(CardSuit.Spades, CardValue.Ace, "[ A♤ ]")]
        [InlineData(CardSuit.Clubs, CardValue.Five, "[ 5♧ ]")]
        [InlineData(CardSuit.Hearts, CardValue.Jack, "[ J♡ ]")]
        [InlineData(CardSuit.Diamonds, CardValue.King, "[ K♢ ]")]
        public void ToString_ShouldReturnFormattedString(CardSuit suit, CardValue value, string expected)
        {
            var card = new Card(suit, value);

            string actual = card.ToString();

            Assert.Equal(expected, actual);
        }
    }
}
