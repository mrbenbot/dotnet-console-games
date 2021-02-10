using System;
using Xunit;
using TicTacToe;

namespace Test
{
    public class SquareTests
    {
        [Fact]
        public void Constructor_WithNoArgs_MakesEmptySquare()
        {
            Square square = new Square();

            bool expected = true;
            bool actual = square.Equals(SquareState.Empty);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(SquareState.Nought)]
        [InlineData(SquareState.Cross)]
        public void Fill_WhenEmpty_FillsSquare(SquareState state)
        {
            Square square = new Square();

            square.Fill(state);

            bool expected = true;
            bool actual = square.Equals(state);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Fill_WhenAllreadyFilled_ThrowsError()
        {
            Square square = new Square();

            square.Fill(SquareState.Cross);

            Assert.Throws<InvalidOperationException>(() => square.Fill(SquareState.Cross));
        }

        [Theory]
        [InlineData(SquareState.Nought, "0")]
        [InlineData(SquareState.Cross, "X")]
        [InlineData(SquareState.Empty, " ")]
        public void ToString_ReturnsCorrectString(SquareState state, string expected)
        {
            Square square = new Square();

            square.Fill(state);

            string actual = square.ToString();
            Assert.Equal(expected, actual);
        }
    }
}
