using System;
using TicTacToe;
using Xunit;

namespace Tests.TicTacToe {
    
    public class ComputerLogicTest {

        private ComputerLogic computerLogic;
        
        public ComputerLogicTest() {
            WinConditions winConditions = new WinConditions();
            this.computerLogic = new ComputerLogic(winConditions);
        }

        [Fact]
        public void ExpectAIToBlockTopHorizontalWin() {
            string[] gameBoard = { "X", "X", "2", "3", "O", "5", "6", "7", "8" };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(2, move);
        }

        [Fact]
        public void ExpectAIToBlockMiddleHorizontalWin() {
            string[] gameBoard = { "O", "1", "2", "X", "X", "5", "6", "7", "8" };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(5, move);
        }

        [Fact]
        public void ExpectAIToBlockBottomHorizontalWin() {
            string[] gameBoard = { "0", "1", "2", "3", "O", "5", "X", "7", "X" };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(7, move);
        }

        [Fact]
        public void ExpectAIToBlockLeftVerticalWin() {
            string[] gameBoard = { "X", "1", "2", "X", "O", "5", "6", "7", "8" };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(6, move);
        }

        [Fact]
        public void ExpectAIToBlockMiddleVerticalWin() {
            string[] gameBoard = { "O", "X", "2", "3", "4", "5", "6", "X", "8" };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(4, move);
        }

        [Fact]
        public void ExpectAIToBlockRightVerticalWin() {
            string[] gameBoard = { "O", "X", "X", "3", "O", "5", "6", "7", "X" };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(5, move);
        }

        [Fact]
        public void ExpectAIToBlockForwardDiagonalWin() {
            string[] gameBoard = { "O", "1", "X", "3", "X", "5", "6", "7", "8" };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(6, move);
        }

        [Fact]
        public void ExpectAIToBlockBackwardDiagonalWin() {
            string[] gameBoard = { "X", "1", "O", "3", "X", "5", "6", "7", "8" };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(8, move);
        }

        [Theory]
        [InlineData(new object[] { new string[] { "O", "O", "2", "X", "X", "5", "X", "7", "8" } })]
        [InlineData(new object[] { new string[] { "X", "X", "2", "X", "O", "5", "O", "7", "8" } })]
        [InlineData(new object[] { new string[] { "X", "X", "2", "X", "O", "O", "6", "7", "O" } })]
        public void ExpectAIToWin(string[] gameBoard) {

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(2, move);
        }

    }
}
