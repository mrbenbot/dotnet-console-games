using System.Collections.Generic;
using Xunit;

using Library.CardGame;

namespace Pontoon.Tests
{
    public class PontoonHandTests
    {
        [Theory]
        [InlineData(new CardValue[] { CardValue.Ace, CardValue.Five, CardValue.Four }, 10)]
        [InlineData(new CardValue[] { CardValue.Ace, CardValue.Five, CardValue.Ace }, 7)]
        [InlineData(new CardValue[] { CardValue.Six, CardValue.Five }, 11)]
        public void MinValue_ReturnsTotalWithAceLow(CardValue[] values, int expected)
        {
            var hand = new PontoonHand(false);
            foreach (var cardValue in values)
            {
                hand.Add(new PontoonCard(CardSuit.Diamonds, cardValue));
            }

            int actual = hand.MinValue;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new CardValue[] { CardValue.Ace, CardValue.Five, CardValue.Four }, 20)]
        [InlineData(new CardValue[] { CardValue.Ace, CardValue.Five, CardValue.Ace }, 17)]
        [InlineData(new CardValue[] { CardValue.Six, CardValue.Five }, 11)]
        public void BestValue_ReturnsHighestTotal21OrUnder(CardValue[] values, int expected)
        {
            var hand = new PontoonHand(false);
            foreach (var cardValue in values)
            {
                hand.Add(new PontoonCard(CardSuit.Diamonds, cardValue));
            }

            int actual = hand.BestValue;

            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData(new CardValue[] { CardValue.Ten, CardValue.Ten, CardValue.Four }, true)]
        [InlineData(new CardValue[] { CardValue.Ace, CardValue.Five, CardValue.Ace }, false)]
        [InlineData(new CardValue[] { CardValue.King, CardValue.Queen, CardValue.Eight }, true)]
        public void IsBust_CardValuesOver21_IsTrue(CardValue[] values, bool expected)
        {
            var hand = new PontoonHand(false);
            foreach (var cardValue in values)
            {
                hand.Add(new PontoonCard(CardSuit.Diamonds, cardValue));
            }

            bool actual = hand.IsBust;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new CardValue[] { CardValue.Ace, CardValue.Two, CardValue.Three, CardValue.Four, CardValue.Five }, true)]
        [InlineData(new CardValue[] { CardValue.Ace, CardValue.Ace, CardValue.Two, CardValue.Three, CardValue.Four, CardValue.Five }, true)]
        [InlineData(new CardValue[] { CardValue.Ten, CardValue.Ten, CardValue.Five, CardValue.Five, CardValue.Ace }, false)]
        [InlineData(new CardValue[] { CardValue.King, CardValue.Queen, CardValue.Eight }, false)]
        public void IsFiveCardTrick_FiveOrMoreCardsLessThan21_IsTrue(CardValue[] values, bool expected)
        {
            var hand = new PontoonHand(false);
            foreach (var cardValue in values)
            {
                hand.Add(new PontoonCard(CardSuit.Diamonds, cardValue));
            }

            bool actual = hand.IsFiveCardTrick;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new CardValue[] { CardValue.Ace, CardValue.Ten }, true)]
        [InlineData(new CardValue[] { CardValue.Ace, CardValue.King }, true)]
        [InlineData(new CardValue[] { CardValue.Ten, CardValue.Ten }, false)]
        [InlineData(new CardValue[] { CardValue.King, CardValue.Queen, CardValue.Ace }, false)]
        public void IsPontoon_TwoCardsThatEqual21_IsTrue(CardValue[] values, bool expected)
        {
            var hand = new PontoonHand(false);
            foreach (var cardValue in values)
            {
                hand.Add(new PontoonCard(CardSuit.Diamonds, cardValue));
            }

            bool actual = hand.IsPontoon;

            Assert.Equal(expected, actual);
        }

        [Theory]
        // Pontoon vs Pontoon
        [InlineData(new CardValue[] { CardValue.Ace, CardValue.Ten }, new CardValue[] { CardValue.Ace, CardValue.King }, -1)]
        // Five Card trick < 21 vs Pontoon
        [InlineData(new CardValue[] { CardValue.Ace, CardValue.Ace, CardValue.Ace, CardValue.Ace, CardValue.Ace }, new CardValue[] { CardValue.Ace, CardValue.King }, -1)]
        // Pontoon vs 3 card 21
        [InlineData(new CardValue[] { CardValue.Ace, CardValue.Ten }, new CardValue[] { CardValue.Three, CardValue.Eight, CardValue.King }, 1)]
        // 21 vs < 21  
        [InlineData(new CardValue[] { CardValue.King, CardValue.Queen, CardValue.Ace }, new CardValue[] { CardValue.Ace, CardValue.Nine }, 1)]
        // < 21 vs < 21  
        [InlineData(new CardValue[] { CardValue.King, CardValue.Eight }, new CardValue[] { CardValue.Ace, CardValue.Six }, 1)]
        public void CompareTo_CompareToDealer_ReturnsCorrectInt(CardValue[] playerValues, CardValue[] dealerValues, int expected)
        {
            var playerHand = new PontoonHand(false);
            foreach (var cardValue in playerValues)
            {
                playerHand.Add(new PontoonCard(CardSuit.Diamonds, cardValue));
            }

            var dealerHand = new PontoonHand(true);
            foreach (var cardValue in dealerValues)
            {
                dealerHand.Add(new PontoonCard(CardSuit.Diamonds, cardValue));
            }

            int actual = playerHand.CompareTo(dealerHand);

            Assert.Equal(expected, actual);
        }

        [Theory]
        // Pontoon vs Pontoon
        [InlineData(new CardValue[] { CardValue.Ace, CardValue.Ten }, new CardValue[] { CardValue.Ace, CardValue.King }, 1)]
        // Five Card trick < 21 vs Pontoon
        [InlineData(new CardValue[] { CardValue.Ace, CardValue.Ace, CardValue.Ace, CardValue.Ace, CardValue.Ace }, new CardValue[] { CardValue.Ace, CardValue.King }, 1)]
        // Pontoon vs 3 card 21
        [InlineData(new CardValue[] { CardValue.Ace, CardValue.Ten }, new CardValue[] { CardValue.Three, CardValue.Eight, CardValue.King }, -1)]
        // 21 vs < 21  
        [InlineData(new CardValue[] { CardValue.King, CardValue.Queen, CardValue.Ace }, new CardValue[] { CardValue.Ace, CardValue.Nine }, -1)]
        // < 21 vs < 21  
        [InlineData(new CardValue[] { CardValue.King, CardValue.Eight }, new CardValue[] { CardValue.Ace, CardValue.Six }, -1)]
        public void CompareTo_DealerCompareToHand_ReturnsCorrectInt(CardValue[] playerValues, CardValue[] dealerValues, int expected)
        {
            var playerHand = new PontoonHand(false);
            foreach (var cardValue in playerValues)
            {
                playerHand.Add(new PontoonCard(CardSuit.Diamonds, cardValue));
            }

            var dealerHand = new PontoonHand(true);
            foreach (var cardValue in dealerValues)
            {
                dealerHand.Add(new PontoonCard(CardSuit.Diamonds, cardValue));
            }

            int actual = dealerHand.CompareTo(playerHand);

            Assert.Equal(expected, actual);
        }
    }
}
