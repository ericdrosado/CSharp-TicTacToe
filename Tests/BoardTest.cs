using System;
using TicTacToe;
using Xunit;

namespace Tests.TicTacToe {

    public class BoardTest {

        private Board board;
        
        public BoardTest() {
            this.board = new Board();
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
        public void AddMarkerToGameBoard(int move) {
            string[] updatedBoard = this.board.GameBoard;
            string[] gameBoard = { "0", "1", "2", "3", "4", "5", "6", "7", "8" };

            gameBoard[move] = "X";
            this.board.UpdateBoard(move);

            Assert.Equal(gameBoard, updatedBoard);
        }

        [Theory]
        [InlineData(new object[] { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 } })]
        [InlineData(new object[] { new int[] { 0, 1, 2, 3 } })]
        [InlineData(new object[] { new int[] { 0, 2, 3, 5, 6, 8 } })]
        [InlineData(new object[] { new int[] { 6, 7, 8 } })]
        public void CheckAvailableSpaceCount(int[] moves) {
            string[] gameBoard = this.board.GameBoard;
            int availableMoves = gameBoard.Length - moves.Length;

            foreach (int move in moves ) {
                gameBoard[move] = "X";
                this.board.UpdateBoard(move);
            }

            Assert.Equal(availableMoves, this.board.GetAvailableSpaces.Count);
        }

    }
}
