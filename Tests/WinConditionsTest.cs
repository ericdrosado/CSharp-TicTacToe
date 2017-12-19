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
        public void ExpectToReturnTrueForWin(string[] gameBoard) {
            Assert.True(this.winConditions.IsWinner(gameBoard));
        }

        [Theory]
        [InlineData(new object[] { new string[] { "X", "X", "O", "3", "4", "X", "O", "7", "8" } })]
        [InlineData(new object[] { new string[] { "X", "O", "X", "X", "O", "5", "6", "7", "8" } })]
        [InlineData(new object[] { new string[] { "X", "1", "2", "3", "O", "X", "O", "7", "X" } })]
        public void ExpectToReturnFalseForNoWin(string[] gameBoard) {
            Assert.False(this.winConditions.IsWinner(gameBoard));
        }

    }
}

