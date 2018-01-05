using System;
using TicTacToe;
using Xunit;

namespace Tests.TicTacToe {

    public class WinConditionsTest {

        private WinConditions winConditions;

        public WinConditionsTest() {
            this.winConditions = new WinConditions();
        }

        [Theory]
        [InlineData(new object[] { new string[] { "X", "X", "X", "3", "4", "O", "O", "7", "8" } })]
        [InlineData(new object[] { new string[] { "X", "O", "O", "X", "4", "5", "X", "7", "8" } })]
        [InlineData(new object[] { new string[] { "X", "1", "2", "3", "X", "O", "O", "7", "X" } })]
        [InlineData(new object[] { new string[] { "0", "1", "X", "3", "X", "O", "X", "7", "8" } })]
        [InlineData(new object[] { new string[] {"X", "X", "X", "X", "4", "5", "O", "7", "8", "9", "10", "O", "12", "O", "14", "15"} })]
        [InlineData(new object[] { new string[] {"X", "1", "O", "3", "X", "5", "6", "O", "X", "O", "10", "11", "X", "13", "14", "15"} })]
        [InlineData(new object[] { new string[] {"X", "1", "2", "O", "4", "X", "6", "7", "8", "9", "X", "11", "12", "13", "14", "X"} })]
        [InlineData(new object[] { new string[] {"0", "1", "2", "X", "4", "5", "X", "7", "8", "X", "10", "O", "X", "13", "O", "15"} })]
        public void ExpectToReturnTrueForWin(string[] gameBoard) {
            Assert.True(this.winConditions.IsWinner(gameBoard));
        }

        [Theory]
        [InlineData(new object[] { new string[] { "X", "X", "O", "3", "4", "X", "O", "7", "8" } })]
        [InlineData(new object[] { new string[] { "X", "O", "X", "X", "O", "5", "6", "7", "8" } })]
        [InlineData(new object[] { new string[] { "X", "1", "2", "3", "O", "X", "O", "7", "X" } })]
        [InlineData(new object[] { new string[] { "0", "1", "O", "3", "X", "5", "X", "7", "8" } })]
        [InlineData(new object[] { new string[] {"X", "X", "O", "X", "4", "5", "6", "7", "8", "9", "10", "O", "12", "O", "14", "15"} })]
        [InlineData(new object[] { new string[] {"X", "1", "2", "3", "O", "5", "6", "O", "X", "O", "10", "11", "X", "13", "14", "15"} })]
        [InlineData(new object[] { new string[] {"X", "1", "2", "3", "4", "O", "6", "7", "8", "9", "X", "11", "12", "13", "14", "X"} })]
        [InlineData(new object[] { new string[] {"0", "1", "2", "X", "4", "5", "X", "7", "8", "X", "10", "11", "O", "13", "O", "15"} })]
        public void ExpectToReturnFalseForNoWin(string[] gameBoard) {
            Assert.False(this.winConditions.IsWinner(gameBoard));
        }

    }
}

