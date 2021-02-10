using System.Collections.Generic;
using System;
using System.Text;
using System.Linq;

namespace TicTacToe
{
    public class Board
    {
        private readonly IConsole _console;

        private List<Square> _squares;
        private int[][] _winConditions = new int[][] {
            new int[] { 0, 1, 2 }, new int[] { 3, 4, 5 }, new int[] { 6, 7, 8 },
            new int[] { 0, 3, 6 }, new int[] { 1, 4, 7 }, new int[] { 2, 5, 8 },
            new int[] { 0, 4, 8 }, new int[] {6, 4, 2 }
        };

        public Board(IConsole console)
        {
            _console = console;
            _squares = new List<Square>();

            for (int i = 0; i < 9; i++)
            {
                _squares.Add(new Square());
            }
        }

        public void PickSquare(SquareState value, int index)
        {
            if (index > 8 || index < 0)
            {
                throw new ArgumentException("Pick a number between 1 and 9...");
            }
            _squares[index].Fill(value);
        }

        public bool CheckForWinner(SquareState state)
        {
            foreach (int[] lineToCheck in _winConditions)
            {
                if (lineToCheck.All(i => _squares[i].Equals(state)))
                {
                    return true;
                }
            }
            return false;
        }

        public void Print(bool showNumbers)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 9; i++)
            {
                if (i % 3 == 0)
                {
                    sb.Append("\n");
                    sb.Append("|");
                }
                sb.Append(showNumbers ? (i + 1).ToString() : _squares[i].ToString());
                sb.Append("|");
            }
            sb.Append("\n");
            _console.Clear();
            _console.Print(sb.ToString());
        }
    }
}