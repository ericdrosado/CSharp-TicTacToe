using System;
using TicTacToe;
using Xunit;

namespace Tests.TicTacToe {

    public class UITest {

        private UI ui;

        public UITest() {
            IO io = new IO();
            this.ui = new UI(io);
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
        public void ReturnBoardWithMarkers()
        {
            string[] board = { "0", "X", "2", "O", "X", "5", "6", "7", "8" };
            string expectedBoard = "                       " + "0" + " | " + "X" + " | " + "2" +
                                   "\n                      " + "---+---+---\n" +
                                   "                       " + "O" + " | " + "X" + " | " + "5" +
                                   "\n                      " + "---+---+---\n" +
                                   "                       " + "6" + " | " + "7" + " | " + "8" + "\n";

            string actualBoard = this.ui.GameBoard(board);

            Assert.Equal(expectedBoard, actualBoard);
        }
    }
}
