using System;
using System.Linq;
using TicTacToe;
using Xunit;

namespace Tests.TicTacToe {

    public class BoardTest {

        private Board board;
        
        public BoardTest() {
            this.board = new Board();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        public void AddMarkerToGameBoard(int move) {
            string[] gameBoard = { "0", "1", "2", "3", "4", "5", "6", "7", "8" };

            gameBoard[move] = "X";
            this.board.UpdateBoard(move);

            Assert.Equal(gameBoard, this.board.GameBoard);
        }

        [Theory]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 })]
        [InlineData(new int[] { 0, 1, 2, 3 })]
        [InlineData(new int[] { 0, 2, 3, 5, 6, 8 })]
        [InlineData(new int[] { 6, 7, 8 })]
        public void CheckAvailableSpaceCount(int[] moves) {
            int availableMoves = this.board.GameBoard.Length - moves.Length;

            foreach (int move in moves ) {
                this.board.GameBoard[move] = "X";
                this.board.UpdateBoard(move);
            }

            Assert.Equal(availableMoves, this.board.AvailableSpaces().Count());
        }

    }
}
