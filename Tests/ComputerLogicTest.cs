using System;
using TicTacToe;
using Xunit;

namespace Tests.TicTacToe {
    
    public class ComputerLogicTest {

        private ComputerLogic computerLogic;
        
        public ComputerLogicTest() {
            Board board = new Board();
            board.SetMarkers("X", "O");
            WinConditions winConditions = new WinConditions();
            this.computerLogic = new ComputerLogic(winConditions);
        }
        

        [Fact]
        public void ExpectAIToBlockTopHorizontalWin3x3() {
            string[] gameBoard = { "X", "X", " ", "O", " ", " ", " ", " ", " " };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(2, move);
        }

        [Fact]
        public void ExpectAIToBlockMiddleHorizontalWin3x3() {
            string[] gameBoard = { " ", " ", " ", "X", "X", " ", " ", " ", " " };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(5, move);
        }

        [Fact]
        public void ExpectAIToBlockBottomHorizontalWin3x3() {
            string[] gameBoard = { " ", " ", " ", " ", "O", " ", "X", " ", "X" };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(7, move);
        }

        [Fact]
        public void ExpectAIToBlockLeftVerticalWin3x3() {
            string[] gameBoard = { "X", " ", " ", "X", "O", " ", " ", " ", " " };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(6, move);
        }

        [Fact]
        public void ExpectAIToBlockMiddleVerticalWin3x3() {
            string[] gameBoard = { "O", "X", " ", " ", " ", " ", " ", "X", " " };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(4, move);
        }

        [Fact]
        public void ExpectAIToBlockRightVerticalWin3x3() {
            string[] gameBoard = { "O", "X", "X", " ", "O", " ", " ", " ", "X" };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(5, move);
        }

        [Fact]
        public void ExpectAIToBlockForwardDiagonalWin3x3() {
            string[] gameBoard = { "O", " ", "X", " ", "X", " ", " ", " ", " " };

            int move = this.computerLogic.GetMove(gameBoard);
 
            Assert.Equal(6, move);
        }

        [Fact]
        public void ExpectAIToBlockBackwardDiagonalWin3x3() {
            string[] gameBoard = { "X", " ", "O", " ", "X", " ", " ", " ", " " };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(8, move);
        }

        [Theory]
        [InlineData(new object[] { new string[] { "O", "O", " ", "X", "X", " ", "X", " ", "8" } })]
        [InlineData(new object[] { new string[] { "X", "X", " ", "X", "O", " ", "O", " ", "8" } })]
        [InlineData(new object[] { new string[] { "X", "X", " ", "X", "O", "O", " ", " ", "O" } })]
        public void ExpectAIToWin3x3(string[] gameBoard) {

            int move = this.computerLogic.GetMove(gameBoard);
            int winMove = 2;

            Assert.Equal(winMove, move);
        }
        
        [Fact]
        public void ExpectAIToBlockRow1For4x4() {
            string[] gameBoard = { "X", "X", "X", " ", " ", "O", " ", " ", " ", "O", " ", " ", " ", " ", " ", " " };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(3, move);
        }
        
        [Fact]
        public void ExpectAIToBlockRow2For4x4() {
            string[] gameBoard = { " ", "O", " ", " ", " ", "X", "X", "X", " ", " ", " ", "O", " ", " ", " ", " " };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(4, move);
        }
        
        [Fact]
        public void ExpectAIToBlockRow3For4x4() {
            string[] gameBoard = { " ", "O", " ", " ", " ", " ", " ", " ", "X", "X", " ", "X", " ", "O", " ", " " };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(10, move);
        }
        
        [Fact]
        public void ExpectAIToBlockRow4For4x4() {
            string[] gameBoard = { " ", " ", " ", " ", "O", " ", " ", " ", " ", " ", "O", " ", "X", "X", "X", " " };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(15, move);
        }
        
        [Fact]
        public void ExpectAIToBlockColumn1For4x4() {
            string[] gameBoard = { "X", " ", "O", "O", "X", " ", " ", " ", "X", " ", " ", " ", " ", " ", " ", " " };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(12, move);
        }
        
        [Fact]
        public void ExpectAIToBlockColumn2For4x4() {
            string[] gameBoard = { " ", "X", " ", " ", " ", " ", " ", "O", " ", "X", " ", " ", "O", "X", " ", " " };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(5, move);
        }
        
        [Fact]
        public void ExpectAIToBlockColumn3For4x4() {
            string[] gameBoard = { " ", " ", "X", "O", " ", " ", "X", "O", " ", " ", " ", " ", " ", " ", "X", " " };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(10, move);
        }
        
        [Fact]
        public void ExpectAIToBlockColumn4For4x4() {
            string[] gameBoard = { " ", " ", " ", " ", " ", " ", " ", "X", " ", " ", " ", "X", " ", " ", " ", "X" };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(3, move);
        }
        
        [Fact]
        public void ExpectAIToBlockForwardDiagonalFor4x4() {
            string[] gameBoard = { " ", "O", " ", "X", " ", " ", "X", " ", " ", "X", "O", " ", " ", " ", " ", " " };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(12, move);
        }
        
        [Fact]
        public void ExpectAIToBlockBackwardDiagonalFor4x4() {
            string[] gameBoard = { " ", " ", "O", " ", " ", "X", " ", " ", " ", " ", "X", " ", "O", " ", " ", "X" };

            int move = this.computerLogic.GetMove(gameBoard);

            Assert.Equal(0, move);
        }

    }
}
