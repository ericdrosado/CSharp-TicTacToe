using System;
using System.Linq;
using TicTacToe;
using Xunit;

namespace Tests.TicTacToe {
    
    public class GameTest {
        
        private Board board;

        public GameTest() {
            this.board = new Board();
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [InlineData(new int[] { 1, 2, 3, 4 })]
        [InlineData(new int[] { 1, 2, 3, 5, 6, 8 })]
        [InlineData(new int[] { 6, 7, 8 })]
        public void ExpectMarkerToBePlaced(int[] moves) {
            this.board.CreateBoard(3);
            int spacesAvailableBefore = this.board.GetAvailableSpaces().Count();

            foreach (int move in moves) {
                this.board.UpdateBoard(move);
            }
            int spacesAvailableAfter = this.board.GetAvailableSpaces().Count();

            Assert.NotEqual(spacesAvailableBefore, spacesAvailableAfter);
        }

    }
}
