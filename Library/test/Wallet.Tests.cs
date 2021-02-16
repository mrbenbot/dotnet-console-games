using System;
using Xunit;

using Library.CardGame;

namespace Library.Tests
{
    public class WalletTests
    {
        [Fact]
        public void PlaceBet_WhenNotEnoughFunds_ThrowsError()
        {
            var wallet = new Wallet { Total = 0 };

            Assert.Throws<InvalidOperationException>(() => wallet.PlaceBet(100));

        }

        [Fact]
        public void PlaceBet_WhenEnoughFunds_PlacesBet()
        {
            var wallet = new Wallet { Total = 100 };
            int expectedBet = 50;
            int expectedTotal = wallet.Total - expectedBet;

            wallet.PlaceBet(expectedBet);

            int actualBet = wallet.Bet;
            int actualTotal = wallet.Total;

            Assert.Equal(expectedBet, actualBet);
            Assert.Equal(expectedTotal, actualTotal);
        }

        [Theory]
        [InlineData(100, 50, 0)]
        [InlineData(0, 100, 200)]
        [InlineData(123, 123, 10)]
        public void Win_WithInputZeroOrGreater_AddsToTotalAndResetsBet(int total, int bet, int winnings)
        {
            var wallet = new Wallet { Total = total, Bet = bet };
            int expectedTotal = total + winnings;
            int expectedBet = 0;

            wallet.Win(winnings);

            int actualBet = wallet.Bet;
            int actualTotal = wallet.Total;

            Assert.Equal(expectedBet, actualBet);
            Assert.Equal(expectedTotal, actualTotal);
        }

        [Theory]
        [InlineData(100, 50)]
        [InlineData(1, 1)]
        [InlineData(0, 1000)]
        public void ToString_ReturnsStringInCorrectFormat(int total, int bet)
        {
            var wallet = new Wallet { Total = total, Bet = bet };
            string expected = $"Total £{total}, Bet £{bet}";

            string actual = wallet.ToString();

            Assert.Equal(expected, actual);
        }
    }
}
