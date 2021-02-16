using System;

namespace Library.CardGame
{
    public class Wallet : IWallet
    {
        public int Total { get; set; }
        public int Bet { get; set; }

        public void PlaceBet(int amount)
        {
            if (Total - amount < 0)
            {
                throw new InvalidOperationException("Not enough funds...");
            }
            Total -= amount;
            Bet += amount;
        }
        public void Win(int winnings)
        {
            Total += winnings;
            Bet = 0;
        }

        public override string ToString()
        {
            return $"Total £{Total}, Bet £{Bet}";
        }
    }
}