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
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        [InlineData("4")]
        [InlineData("5")]
        [InlineData("6")]
        [InlineData("7")]
        [InlineData("8")]
        public void ReturnTrueIfInputIsOnBoard(string input) {
            bool hasValue = this.validateInput.IsInputOnBoard(input, this.board.GameBoard);

            Assert.Equal(true, hasValue);
        }

        [Theory]
        [InlineData("9")]
        [InlineData("1000")]
        [InlineData("!")]
        [InlineData(" ")]
        public void ReturnFalseIfInputIsNotOnBoard(string input) {
            bool hasValue = this.validateInput.IsInputOnBoard(input, this.board.GameBoard);

            Assert.Equal(false, hasValue);
        }

        [Theory]
        [InlineData("0")]
        [InlineData("10")]
        [InlineData("55")]
        [InlineData("100")]
        public void ReturnTrueIfInputIsNumericString(string input) {
            bool hasNumeric = this.validateInput.IsInputNumericString(input);

            Assert.Equal(true, hasNumeric);
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("!!")]
        [InlineData("Test")]
        [InlineData("T")]
        public void ReturnFalseIfInputIsNotNumericString(string input) {
            bool hasNumeric = this.validateInput.IsInputNumericString(input);

            Assert.Equal(false, hasNumeric);
        }

    }
}
