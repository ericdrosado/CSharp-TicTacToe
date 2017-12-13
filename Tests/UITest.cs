using System;
using TicTacToe;
using Xunit;

namespace Tests.TicTacToe {

    public class UITest {

        private Board board;
        private UI ui;

        public UITest() {
            this.board = new Board();
            IO io = new IO();
            ValidateInput validateInput = new ValidateInput(board);
            this.ui = new UI(board, io, validateInput);
        }

        [Fact]
        public void ReturnBoardWithoutMarkers() {
            string[] board = {"0", "1", "2", "3", "4", "5", "6", "7", "8" };
            string expectedBoard = "                       " + "0" + " | " + "1" + " | " + "2" +
                                   "\n                      " + "---+---+---\n" +
                                   "                       " + "3" + " | " + "4" + " | " + "5" +
                                   "\n                      " + "---+---+---\n" +
                                   "                       " + "6" + " | " + "7" + " | " + "8" + "\n";

            string actualBoard = this.ui.GameBoard(board);

            Assert.Equal(expectedBoard, actualBoard);
        }

        [Fact]
        public void ReturnBoardWithMarkers() {
            string[] board = { "0", "X", "2", "O", "X", "5", "6", "7", "8" };
            string expectedBoard = "                       " + "0" + " | " + "X" + " | " + "2" +
                                   "\n                      " + "---+---+---\n" +
                                   "                       " + "O" + " | " + "X" + " | " + "5" +
                                   "\n                      " + "---+---+---\n" +
                                   "                       " + "6" + " | " + "7" + " | " + "8" + "\n";

            string actualBoard = this.ui.GameBoard(board);

            Assert.Equal(expectedBoard, actualBoard);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ExpectMarkerToBePlaced(int move) {
            string[] gameBoard = this.board.GameBoard;

            this.ui.PlaceMarker(move);

            gameBoard[move] = "X";

            Assert.Equal(gameBoard, this.board.GameBoard);
        }
    }
}
