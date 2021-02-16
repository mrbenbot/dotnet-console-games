using System;
using Library.CardGame;
using Library.Io;

namespace Pontoon
{
    public class PontoonPlayer : IPontoonPlayer
    {
        static int numPlayers;
        IWallet Wallet;
        public IPontoonHand Hand;

        IConsole _console;
        public string Name { get; }

        public int Bet
        {
            get
            {
                return Wallet.Bet;
            }
        }

        public PontoonPlayer(IWallet wallet, IPontoonHand hand, IConsole console, string name = "")
        {
            Wallet = wallet;
            Hand = hand;
            Name = name == "" ? $"Player {++numPlayers}" : name;
            _console = console;
        }

        public void MakeBet()
        {
            _console.Print(ToString());
            _console.Print("Place your bet...");

            bool success = false;
            while (!success)
            {
                int bet = _console.GetInt();
                try
                {
                    Wallet.PlaceBet(bet);
                    success = true;
                }
                catch (InvalidOperationException e)
                {
                    _console.Print(e.Message);
                }
            }
        }
        public void TakeTurn(IDeck<IPontoonCard> deck)
        {
            bool hasStuck = false;
            while (!hasStuck && !Hand.IsBust)
            {
                _console.Print(ToString());
                _console.Print("[S]tick or [T]wist?");
                switch (Console.ReadLine().ToLowerInvariant())
                {
                    case "s":
                        hasStuck = true;
                        continue;
                    case "t":
                        var card = deck.Next();
                        Hand.Add(card);
                        break;
                    default:
                        continue;
                }
            }
            if (Hand.IsBust)
            {
                _console.Print(ToString());
                _console.Print($"{Name}: BUST!!!");
            }
        }
        public void Receive(IPontoonCard card)
        {
            Hand.Add(card);
        }

        public override string ToString()
        {
            return $"{Name}: {Hand} ({Wallet})";
        }

        public int CompareHand(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            PontoonDealer otherPlayer = obj as PontoonDealer;
            return Hand.CompareTo(otherPlayer.Hand);
        }

        public void Win(int winnings)
        {
            Wallet.Win(winnings);
        }

        public void GiveCardsBack(IDeck<IPontoonCard> deck)
        {
            deck.Return(Hand.Empty());
        }
    }
}