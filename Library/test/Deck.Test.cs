using System.Collections.Generic;
using Xunit;

using Library.CardGame;

namespace Library.Tests
{
    public class DeckTests
    {
        [Fact]
        public void GetDeckOfType_WithNoArg_Returns52CardList()
        {
            var cards = Deck<Card>.GetDeckOfType();

            int actual = cards.Count;
            int expected = 52;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 52)]
        [InlineData(2, 104)]
        [InlineData(4, 208)]
        public void GetDeckOfType_WithNDecks_ReturnsCorrectLengthList(int numDecks, int expected)
        {
            var cards = Deck<Card>.GetDeckOfType(numDecks);

            int actual = cards.Count;

            Assert.Equal(expected, expected);
        }

        [Fact]
        public void Shuffle_ChangesOrderOfCards()
        {
            var deck = new Deck<Card>(Deck<Card>.GetDeckOfType());
            var initialOrder = new List<Card>(deck.Cards);

            deck.Shuffle();

            var nextOrder = new List<Card>(deck.Cards);

            Assert.NotEqual(initialOrder, nextOrder);
        }

        [Fact]
        public void Next_ReturnsCardAndRemovesFromDeck()
        {
            var inputCard = new Card(CardSuit.Spades, CardValue.Ace);
            var deck = new Deck<Card>(new List<Card>() { inputCard });

            Card actual = deck.Next();
            Card expected = inputCard;

            Assert.Equal(expected, actual);
            Assert.Empty(deck.Cards);
        }

        [Fact]
        public void Return_WithSingleCard_AddsCardToDeck()
        {
            var inputCard = new Card(CardSuit.Spades, CardValue.Ace);
            var deck = new Deck<Card>(new List<Card>());

            deck.Return(inputCard);

            var expected = inputCard;
            var actual = deck.Cards[0];

            Assert.Equal(expected, actual);
            Assert.Single(deck.Cards);
        }

        [Fact]
        public void Return_WithListOfCards_AddsCardsToDeck()
        {
            var inputList = new List<Card>() { new Card(CardSuit.Spades, CardValue.Ace), new Card(CardSuit.Clubs, CardValue.Ace) };
            var deck = new Deck<Card>(new List<Card>());

            deck.Return(inputList);

            var expected = inputList;
            var actual = deck.Cards;

            Assert.Equal(expected, actual);
            Assert.Equal(expected.Count, actual.Count);
        }

        [Fact]
        public void ToString_ReturnsCorrectString()
        {
            var inputList = new List<Card>() { new Card(CardSuit.Spades, CardValue.Ace), new Card(CardSuit.Clubs, CardValue.Ace) };
            var deck = new Deck<Card>(inputList);

            string expected = "[ A♤ ][ A♧ ]";
            string actual = deck.ToString();

            Assert.Equal(expected, actual);
        }
    }
}
