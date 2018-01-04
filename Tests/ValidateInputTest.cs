using System;
using TicTacToe;
using Xunit;

namespace Tests.TicTacToe {

    public class ValidateInputTest {

        private Board board;
        private ValidateInput validateInput;

        public ValidateInputTest() {
            this.board = new Board();
            this.validateInput = new ValidateInput();
        }

        [Theory]
        [InlineData("0")]
        [InlineData("10")]
        [InlineData("55")]
        [InlineData("100")]
        public void ReturnTrueIfInputIsNumericString(string input) {
            bool hasNumeric = this.validateInput.IsInputNumericString(input);

            Assert.True(hasNumeric);
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("!")]
        [InlineData("Test")]
        [InlineData("T")]
        public void ReturnFalseIfInputIsNotNumericString(string input) {
            bool hasNumeric = this.validateInput.IsInputNumericString(input);

            Assert.False(hasNumeric);
        }
        
        [Theory]
        [InlineData("3")]
        [InlineData("4")]
        public void ReturnTrueIfBoardSizeIsCorrect(string input) {
            bool hasCorrectBoardSize = this.validateInput.IsCorrectBoardSize(input);

            Assert.True(hasCorrectBoardSize);
        }
        
        [Theory]
        [InlineData("2")]
        [InlineData("5")]
        [InlineData("10")]
        public void ReturnFalseIfBoardSizeIsIncorrect(string input) {
            bool hasCorrectBoardSize = this.validateInput.IsCorrectBoardSize(input);

            Assert.False(hasCorrectBoardSize);
        }
    }
}
