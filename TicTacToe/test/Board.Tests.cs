using System;
using Xunit;
using Moq;
using TicTacToe;

namespace Test
{
    public class BoardTests
    {
        [Theory]
        [InlineData(true, "\n|1|2|3|\n|4|5|6|\n|7|8|9|\n")]
        [InlineData(false, "\n| | | |\n| | | |\n| | | |\n")]
        public void Print_PrintsCorrectBoardToConsole(bool showNumbers, string expected)
        {

            var mockConsole = new Mock<IConsole>();

            string actual = null;

            mockConsole.Setup(h => h.Print(It.IsAny<string>()))
                .Callback<string>(r => actual = r);

            var board = new Board(mockConsole.Object);
            board.Print(showNumbers);


            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(SquareState.Nought, 0, "\n|0| | |\n| | | |\n| | | |\n")]
        [InlineData(SquareState.Cross, 4, "\n| | | |\n| |X| |\n| | | |\n")]
        [InlineData(SquareState.Cross, 8, "\n| | | |\n| | | |\n| | |X|\n")]
        public void PickSquare_WithCorrectInput_PicksCorrectSquare(SquareState squareState, int squareIndex, string expected)
        {

            var mockConsole = new Mock<IConsole>();

            string actual = null;

            mockConsole.Setup(h => h.Print(It.IsAny<string>()))
                .Callback<string>(r => actual = r);

            var board = new Board(mockConsole.Object);

            board.PickSquare(squareState, squareIndex);
            board.Print(false);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(SquareState.Nought, -1)]
        [InlineData(SquareState.Cross, 9)]
        public void PickSquare_WithBadArguments_ThrowsArgumentException(SquareState squareState, int squareIndex)
        {

            var mockConsole = new Mock<IConsole>();
            var board = new Board(mockConsole.Object);

            Assert.Throws<ArgumentException>(() => board.PickSquare(squareState, squareIndex));
        }

        [Theory]
        [InlineData(SquareState.Nought, 1)]
        [InlineData(SquareState.Cross, 8)]
        public void PickSquare_SameSquareTwice_ThrowsInvalidOperationException(SquareState squareState, int squareIndex)
        {
            var mockConsole = new Mock<IConsole>();
            var board = new Board(mockConsole.Object);

            board.PickSquare(squareState, squareIndex);

            Assert.Throws<InvalidOperationException>(() => board.PickSquare(squareState, squareIndex));
        }


        [Theory]
        [InlineData(SquareState.Nought, new int[] { 0, 1, 2 }, true)]
        [InlineData(SquareState.Cross, new int[] { 0, 2, 4 }, false)]
        [InlineData(SquareState.Cross, new int[] { 0, 4, 8 }, true)]
        public void CheckForWinner_GivesCorrectOutput(SquareState squareState, int[] squareIndexes, bool expected)
        {

            var mockConsole = new Mock<IConsole>();
            var board = new Board(mockConsole.Object);

            foreach (int i in squareIndexes)
            {
                board.PickSquare(squareState, i);
            }

            bool actual = board.CheckForWinner(squareState);

            Assert.Equal(expected, actual);
        }
    }
}
