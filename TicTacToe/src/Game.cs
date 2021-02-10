using System;

namespace TicTacToe
{
    class Game
    {
        private IConsole _console;
        SquareState _currentPlayer = SquareState.Cross;
        Board _board;
        int _numMoves = 0;

        public Game()
        {
            _console = new PlayerConsole();
            _board = new Board(_console);
        }

        public void Play()
        {
            _board.Print(true);
            _console.Print($"\nNoughts and Crosses!\nType the corresponding number...\n");

            while (true)
            {
                bool winner = _board.CheckForWinner(_currentPlayer);
                if (winner || _numMoves > 8)
                {
                    _console.Print(winner ? "You Win!" : "No Winner!");
                    if (!HandlePlayAgain())
                    {
                        _console.Print("Thanks for playing!");
                        return;
                    };
                    Reset();
                    continue;
                }

                NextPlayer();

                bool moveSuccess = false;
                while (!moveSuccess)
                {
                    moveSuccess = HandleMove();
                }
                _board.Print(false);
            }
        }

        bool HandleMove()
        {
            int selection = _console.GetInt() - 1;
            try
            {
                _board.PickSquare(_currentPlayer, selection);
                return true;
            }
            catch (Exception error)
            {
                _console.Print(error.Message);
                return false;
            }
        }

        bool HandlePlayAgain()
        {
            _console.Print("Play Again? [y]es / [n]o");
            switch (_console.GetString().ToLowerInvariant())
            {
                case "y":
                case "yes":
                    return true;
                case "n":
                case "no":
                default:
                    return false;

            }
        }

        void Reset()
        {
            _board = new Board(_console);
            _numMoves = 0;
            _board.Print(true);
            _currentPlayer = SquareState.Cross;
        }

        void NextPlayer()
        {
            _currentPlayer = _currentPlayer != SquareState.Nought ? SquareState.Nought : SquareState.Cross;
            _console.Print($"Your move: {_currentPlayer}");
            _numMoves++;
        }
    }
}