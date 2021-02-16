using System.Collections.Generic;
using System.Linq;
using Library.CardGame;
using Library.Io;

namespace Pontoon
{
    class Program
    {
        static void Main(string[] args)
        {
            var console = new PlayerConsole();
            console.Print("How Many Players?");
            int numPlayers = console.GetInt();
            var game = new Game(GetPlayers(console, numPlayers), new Deck<IPontoonCard>(Deck<PontoonCard>.GetDeckOfType()), console);
            game.Play();
        }


        public static IPontoonPlayer[] GetPlayers(IConsole console, int numberOfPlayers = 1)
        {
            var players = Enumerable.Range(0, numberOfPlayers).Select(_ =>
            {
                var wallet = new Wallet { Total = 100 };
                var hand = new PontoonHand(false);
                return new PontoonPlayer(wallet, hand, console);
            }).ToList<IPontoonPlayer>();

            players.Add(new PontoonDealer(new PontoonHand(true)));
            return players.ToArray();
        }
    }
}
