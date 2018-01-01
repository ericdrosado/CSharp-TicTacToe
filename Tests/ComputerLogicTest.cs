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
        public void ExpectAIToBlockTopHorizontalWin3x3() {
            string[] gameBoard = { "X", "X", "2", "3", "O", "5", "6", "7", "8" };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(2, move);
        }

        [Fact]
        public void ExpectAIToBlockMiddleHorizontalWin3x3() {
            string[] gameBoard = { "O", "1", "2", "X", "X", "5", "6", "7", "8" };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(5, move);
        }

        [Fact]
        public void ExpectAIToBlockBottomHorizontalWin3x3() {
            string[] gameBoard = { "0", "1", "2", "3", "O", "5", "X", "7", "X" };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(7, move);
        }

        [Fact]
        public void ExpectAIToBlockLeftVerticalWin3x3() {
            string[] gameBoard = { "X", "1", "2", "X", "O", "5", "6", "7", "8" };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(6, move);
        }

        [Fact]
        public void ExpectAIToBlockMiddleVerticalWin3x3() {
            string[] gameBoard = { "O", "X", "2", "3", "4", "5", "6", "X", "8" };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(4, move);
        }

        [Fact]
        public void ExpectAIToBlockRightVerticalWin3x3() {
            string[] gameBoard = { "O", "X", "X", "3", "O", "5", "6", "7", "X" };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(5, move);
        }

        [Fact]
        public void ExpectAIToBlockForwardDiagonalWin3x3() {
            string[] gameBoard = { "O", "1", "X", "3", "X", "5", "6", "7", "8" };

            int move = this.computerLogic.GetMove(gameBoard);
 
            Assert.Equal(6, move);
        }

        [Fact]
        public void ExpectAIToBlockBackwardDiagonalWin3x3() {
            string[] gameBoard = { "X", "1", "O", "3", "X", "5", "6", "7", "8" };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(8, move);
        }

        [Theory]
        [InlineData(new object[] { new string[] { "O", "O", "2", "X", "X", "5", "X", "7", "8" } })]
        [InlineData(new object[] { new string[] { "X", "X", "2", "X", "O", "5", "O", "7", "8" } })]
        [InlineData(new object[] { new string[] { "X", "X", "2", "X", "O", "O", "6", "7", "O" } })]
        public void ExpectAIToWin3x3(string[] gameBoard) {

            int move = this.computerLogic.GetMove(gameBoard);
            int winMove = 2;

            Assert.Equal(winMove, move);
        }
        
        [Fact]
        public void ExpectAIToBlockRow1For4x4() {
            string[] gameBoard = { "X", "X", "X", "3", "4", "O", "6", "7", "8", "O", "10", "11", "12", "13", "14", "15" };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(3, move);
        }
        
        [Fact]
        public void ExpectAIToBlockRow2For4x4() {
            string[] gameBoard = { "0", "O", "2", "3", "4", "X", "X", "X", "8", "9", "10", "O", "12", "13", "14", "15" };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(4, move);
        }
        
        [Fact]
        public void ExpectAIToBlockRow3For4x4() {
            string[] gameBoard = { "0", "O", "2", "3", "4", "5", "6", "7", "X", "9", "X", "X", "12", "O", "14", "15" };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(9, move);
        }
        
        [Fact]
        public void ExpectAIToBlockRow4For4x4() {
            string[] gameBoard = { "0", "1", "2", "3", "O", "5", "6", "7", "8", "9", "O", "11", "X", "X", "14", "X" };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(14, move);
        }
        
        [Fact]
        public void ExpectAIToBlockColumn1For4x4() {
            string[] gameBoard = { "X", "1", "O", "O", "X", "5", "6", "7", "X", "9", "10", "11", "12", "13", "14", "15" };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(12, move);
        }
        
        [Fact]
        public void ExpectAIToBlockColumn2For4x4() {
            string[] gameBoard = { "0", "X", "2", "3", "4", "5", "6", "O", "8", "X", "10", "11", "O", "X", "14", "15" };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(5, move);
        }
        
        [Fact]
        public void ExpectAIToBlockColumn3For4x4() {
            string[] gameBoard = { "0", "1", "X", "O", "4", "5", "X", "O", "8", "9", "10", "11", "12", "13", "X", "15" };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(10, move);
        }
        
        [Fact]
        public void ExpectAIToBlockColumn4For4x4() {
            string[] gameBoard = { "0", "1", "2", "3", "4", "5", "6", "X", "8", "9", "10", "X", "12", "13", "14", "X" };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(3, move);
        }
        
        [Fact]
        public void ExpectAIToBlockForwardDiagonalFor4x4() {
            string[] gameBoard = { "0", "O", "2", "X", "4", "5", "X", "7", "8", "X", "O", "11", "12", "13", "14", "15" };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(12, move);
        }
        
        [Fact]
        public void ExpectAIToBlockBackwardDiagonalFor4x4() {
            string[] gameBoard = { "0", "1", "O", "3", "4", "X", "6", "7", "8", "9", "X", "11", "O", "13", "14", "X" };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(0, move);
        }

    }
}
