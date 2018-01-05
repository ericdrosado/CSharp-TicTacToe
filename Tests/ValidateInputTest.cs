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
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("5")]
        [InlineData("9")]
        public void ReturnTrueIfInputIsWithinBoardBounds(string input) {
            string[] board = new string[9];
            bool hasCorrectBoardValue = this.validateInput.IsInputWithinBoardBounds(board, input);

            Assert.True(hasCorrectBoardValue);
        }
        
        [Theory]
        [InlineData("0")]
        [InlineData("10")]
        [InlineData("12")]
        [InlineData("50")]
        public void ReturnFalseIfInputIsNotWithinBoardBounds(string input) {
            string[] board = new string[9];
            bool hasCorrectBoardValue = this.validateInput.IsInputWithinBoardBounds(board, input);

            Assert.False(hasCorrectBoardValue);
        }
        
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("5")]
        [InlineData("9")]
        public void ReturnTrueIfInputIsAvailableOnTheBoard(string input) {
            string[] board = {" "," ","X"," "," "," ","O"," "," "};
            bool hasCorrectBoardInput = this.validateInput.IsInputAvailableOnTheBoard(board, input);

            Assert.True(hasCorrectBoardInput);
        }
        
        [Theory]
        [InlineData("1")]
        [InlineData("3")]
        [InlineData("5")]
        [InlineData("7")]
        public void ReturnFalseIfInputIsNotAvailableOnTheBoard(string input) {
            string[] board = {"X"," ","X"," ","O"," ","O"," "};
            bool hasCorrectBoardInput = this.validateInput.IsInputAvailableOnTheBoard(board, input);

            Assert.False(hasCorrectBoardInput);
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

        [Theory]
        [InlineData("w")]
        [InlineData("!")]
        [InlineData("{")]
        [InlineData("T")]
        public void ReturnTrueIfInputIsASingleCharacter(string input) {
            bool hasSingleCharacter = this.validateInput.IsInputASingleCharacter(input);

            Assert.True(hasSingleCharacter);
        }
        
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("Te")]
        [InlineData("!@")]
        public void ReturnFalseIfInputIsNotASingleCharacter(string input) {
            bool hasSingleCharacter = this.validateInput.IsInputASingleCharacter(input);

            Assert.False(hasSingleCharacter);
        }

        [Fact]
        public void ReturnTrueIfComputerMarkerIsTheSameAsPlayer() {
            bool hasSameMarker = this.validateInput.IsTheSameMarkerAsPlayer("X", "X");

            Assert.True(hasSameMarker);
        }
        
        [Fact]
        public void ReturnFalseIfComputerMarkerIsNotTheSameAsPlayer() {
            bool hasSameMarker = this.validateInput.IsTheSameMarkerAsPlayer("X", "O");

            Assert.False(hasSameMarker);
        }
    }
}
