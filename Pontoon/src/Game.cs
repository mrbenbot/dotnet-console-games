using System;
using Library.CardGame;
using Library.Io;

namespace Pontoon
{
    public class Game
    {

        IConsole _console;
        IDeck<IPontoonCard> _deck;
        IPontoonPlayer[] _players;
        int _currentPlayerIndex { get; set; }

        IPontoonPlayer CurrentPlayer
        {
            get
            {
                return _players[_currentPlayerIndex];
            }
        }

        public Game(IPontoonPlayer[] players, IDeck<IPontoonCard> deck, IConsole console)
        {
            _players = players;
            _deck = deck;
            _console = console;
        }

        public void Play()
        {
            _deck.Shuffle();

            while (true)
            {
                PlayRound();
                _console.Print("<-- Next Round -->");
            }
        }

        public void PlayRound()
        {
            Deal(1);
            do
            {
                MakeBet();
            } while (NextPlayer());

            Deal(1);
            do
            {
                TakeTurn();
            } while (NextPlayer());

            CalculateWins();
            ReturnAllCards();
        }


        public void Deal(int numCards)
        {
            for (int i = 0; i < numCards; i++)
            {
                foreach (var player in _players)
                {
                    player.Receive(_deck.Next());
                }
            }
        }

        public void MakeBet()
        {
            CurrentPlayer.MakeBet();
        }

        public void TakeTurn()
        {
            CurrentPlayer.TakeTurn(_deck);
        }

        public void CalculateWins()
        {
            var dealer = _players[_players.Length - 1];

            for (int i = 0; i < _players.Length - 1; i++)
            {
                IPontoonPlayer player = _players[i];
                bool isWinner = player.CompareHand(dealer) > 0;
                int bet = player.Bet;
                if (isWinner)
                {
                    int winnings = bet * 2;
                    player.Win(winnings);
                    dealer.Win(-bet);
                    _console.Print($"{player.Name}: You win {winnings} x 2");
                    continue;
                }
                dealer.Win(bet);
                player.Win(0);
                _console.Print($"{player.Name}: You loose {bet}");
            }
        }

        public void ReturnAllCards()
        {
            foreach (var player in _players)
            {
                player.GiveCardsBack(_deck);
            }
        }

        public bool NextPlayer()
        {
            if (_currentPlayerIndex + 1 < _players.Length)
            {
                _currentPlayerIndex++;
                return true;
            }
            _currentPlayerIndex = 0;
            return false;
        }
    }
}