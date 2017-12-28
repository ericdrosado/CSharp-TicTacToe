using System;
using TicTacToe;
using Xunit;

namespace Tests.TicTacToe {

    public class UITest {

        private UI ui;

        public UITest() {
            IO io = new IO();
            ValidateInput validateInput = new ValidateInput();
            this.ui = new UI(io, validateInput);
        }

        [Fact]
        public void Return3x3BoardWithoutMarkers() {
            string[] board = {"0", "1", "2", "3", "4", "5", "6", "7", "8" };
            int boardSize = (int) Math.Sqrt(board.Length);
            string expectedBoard = "                       " + "0" + " | " + "1" + " | " + "2" +
                                   "\n                      " + "---+---+---\n" +
                                   "                       " + "3" + " | " + "4" + " | " + "5" +
                                   "\n                      " + "---+---+---\n" +
                                   "                       " + "6" + " | " + "7" + " | " + "8" ;

            string actualBoard = this.ui.BuildBoard(board, boardSize);

            Assert.Equal(expectedBoard, actualBoard);
        }
        
        [Fact]
        public void Return4x4BoardWithoutMarkers() {
            string[] board = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15"};
            int boardSize = (int) Math.Sqrt(board.Length);
            string expectedBoard = "                       " + "0" + " | " + "1" + " | " + "2" + " | " + "3" +
                                   "\n                      " + "---+---+---+---\n" +
                                   "                       " + "4" + " | " + "5" + " | " + "6" + " | " + "7" +
                                   "\n                      " + "---+---+---+---\n" +
                                   "                       " + "8" + " | " + "9" + " |" + "10" + " |" + "11" + 
                                   "\n                      " + "---+---+---+---\n" +
                                   "                      " + "12" + " |" + "13" + " |" + "14" + " |" + "15";

            string actualBoard = this.ui.BuildBoard(board, boardSize);

            Assert.Equal(expectedBoard, actualBoard);
        }

        [Fact]
        public void Return3x3BoardWithMarkers() {
            string[] board = { "0", "X", "2", "O", "X", "5", "6", "7", "8" };
            int boardSize = (int) Math.Sqrt(board.Length);
            string expectedBoard = "                       " + "0" + " | " + "X" + " | " + "2" +
                                   "\n                      " + "---+---+---\n" +
                                   "                       " + "O" + " | " + "X" + " | " + "5" +
                                   "\n                      " + "---+---+---\n" +
                                   "                       " + "6" + " | " + "7" + " | " + "8" ;

            string actualBoard = this.ui.BuildBoard(board, boardSize);

            Assert.Equal(expectedBoard, actualBoard);
        }
        
        [Fact]
        public void Return4x4BoardWithMarkers() {
            string[] board = {"0", "X", "2", "O", "4", "5", "O", "7", "X", "9", "10", "11", "12", "13", "14", "15"};
            int boardSize = (int) Math.Sqrt(board.Length);
            string expectedBoard = "                       " + "0" + " | " + "X" + " | " + "2" + " | " + "O" +
                                   "\n                      " + "---+---+---+---\n" +
                                   "                       " + "4" + " | " + "5" + " | " + "O" + " | " + "7" +
                                   "\n                      " + "---+---+---+---\n" +
                                   "                       " + "X" + " | " + "9" + " |" + "10" + " |" + "11" + 
                                   "\n                      " + "---+---+---+---\n" +
                                   "                      " + "12" + " |" + "13" + " |" + "14" + " |" + "15";

            string actualBoard = this.ui.BuildBoard(board, boardSize);

            Assert.Equal(expectedBoard, actualBoard);
        }

    }
}
