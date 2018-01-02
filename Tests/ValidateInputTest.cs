﻿using System;
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

            Assert.True(hasValue);
        }

        [Theory]
        [InlineData("9")]
        [InlineData("1000")]
        [InlineData("!")]
        [InlineData(" ")]
        public void ReturnFalseIfInputIsNotOnBoard(string input) {
            bool hasValue = this.validateInput.IsInputOnBoard(input, this.board.GameBoard);

            Assert.False(hasValue);
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
        [InlineData("Te")]
        [InlineData("Test")]
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
