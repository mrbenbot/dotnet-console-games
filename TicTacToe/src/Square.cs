using System;
namespace TicTacToe
{
    public class Square
    {
        SquareState _state;

        public Square()
        {
            _state = SquareState.Empty;
        }
        public void Fill(SquareState state)
        {
            if (_state != SquareState.Empty)
            {
                throw new InvalidOperationException("Square allready filled...");
            };
            _state = state;
        }

        public override string ToString()
        {
            switch (_state)
            {
                case SquareState.Nought:
                    return "0";
                case SquareState.Cross:
                    return "X";
                case SquareState.Empty:
                default:
                    return " ";
            }
        }

        public override bool Equals(object obj)
        {
            var square = (Square)obj;
            return square._state == _state;
        }

        public bool Equals(SquareState state)
        {
            return _state == state;
        }

        public override int GetHashCode()
        {
            return _state.GetHashCode();
        }

    }
}