using System;

namespace TicTacToe
{
    class Game
    {
        private IConsole _console;
        SquareState _currentPlayer = SquareState.Nought;
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
            _console.Print($"\nNoughts and Crosses!\nPlayer: {_currentPlayer}\ntype the corresponding number...\n");
            while (true)
            {
                bool success = false;
                while (!success)
                {
                    if (_numMoves > 8)
                    {
                        _console.Print("No Winner!");
                        if (!HandlePlayAgain())
                        {
                            return;
                        }
                        Reset();
                        continue;
                    }
                    int selection = _console.GetInt() - 1;
                    try
                    {
                        _board.PickSquare(_currentPlayer, selection);
                        success = true;
                    }
                    catch (Exception error)
                    {
                        _console.Print(error.Message);
                    }
                }
                _board.Print(false);
                var winner = _board.CheckForWinner(_currentPlayer);

                if (winner)
                {
                    _console.Print("You Win!");
                    if (!HandlePlayAgain())
                    {
                        return;
                    };
                    Reset();
                    continue;
                }
                NextPlayer();
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
            _console.Print($"Your move: {_currentPlayer}");
        }

        void NextPlayer()
        {
            _currentPlayer = _currentPlayer == SquareState.Cross ? SquareState.Nought : SquareState.Cross;
            _console.Print($"Your move: {_currentPlayer}");
            _numMoves++;
        }
    }
}