using System;
using Xunit;

using Library.CardGame;

namespace Library.Tests
{
    public class CardTests
    {
        [Theory]
        [InlineData(CardSuit.Diamonds, CardValue.Two)]
        [InlineData(CardSuit.Spades, CardValue.Five)]
        [InlineData(CardSuit.Clubs, CardValue.Six)]
        [InlineData(CardSuit.Hearts, CardValue.Ten)]
        public void Constructor_ShouldTakeSuitAndValue(CardSuit suit, CardValue value)
        {
            var card = new Card(suit, value);
            CardSuit actualSuit = card.Suit;
            CardValue actualValue = card.Value;
            CardSuit expectedSuit = suit;
            CardValue expectedValue = value;

            Assert.Equal(expectedSuit, actualSuit);
            Assert.Equal(expectedValue, actualValue);
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
