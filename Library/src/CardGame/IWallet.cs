using System;

namespace Library.CardGame
{
    public interface IWallet
    {
        int Total { get; set; }
        int Bet { get; set; }

        void PlaceBet(int amount);
        void Win(int winnings);
    }
}