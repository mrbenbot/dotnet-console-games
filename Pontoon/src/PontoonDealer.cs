using System;
using Library.CardGame;

namespace Pontoon
{
    public class PontoonDealer : IPontoonPlayer
    {
        public IPontoonHand Hand;
        public string Name { get; }
        public int Bet { get; }

        public int Total { get; set; }

        public PontoonDealer(IPontoonHand hand)
        {
            Hand = hand;
            Name = "Dealer";
            Total = 1000;
        }

        public void MakeBet()
        {
            return;
        }
        public void TakeTurn(IDeck<IPontoonCard> deck)
        {
            Console.WriteLine(this);
            while (!Hand.IsBust && Hand.BestValue < 18)
            {
                var card = deck.Next();
                Hand.Add(card);
                Console.WriteLine(this);
            }
            if (Hand.IsBust)
            {
                Console.WriteLine($"{Name} BUST!!");
            }

        }
        public void Receive(IPontoonCard card)
        {
            Hand.Add(card);
        }

        public override string ToString()
        {
            return $"{Name}: {Hand} £{Total}";
        }

        public int CompareHand(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            PontoonPlayer otherPlayer = obj as PontoonPlayer;
            return Hand.CompareTo(otherPlayer.Hand);
        }

        public void Win(int winnings)
        {
            Total += winnings;
        }


        public void GiveCardsBack(IDeck<IPontoonCard> deck)
        {
            deck.Return(Hand.Empty());
        }
    }
}


