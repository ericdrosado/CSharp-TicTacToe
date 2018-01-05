using System;
using System.Linq;
using TicTacToe;
using Xunit;

namespace Tests.TicTacToe {
    
    public class BoardBuilderTest
    {

        private BoardBuilder boardBuilder;

        public BoardBuilderTest() {
            this.boardBuilder = new BoardBuilder();
        }
        
        [Fact]
        public void Return3x3Board() {
            string[] board = {" ", " ", " ", " ", " ", " ", " ", " ", " " };
            int boardSize = (int) Math.Sqrt(board.Length);
            string expectedBoard = "               " + " " + " | " + " " + " | " + " " + "    " + "0" + " | " + "1" + " | " + "2" +
                                   "\n              " + "---+---+---  ---+---+---\n" +
                                   "               " + " " + " | " + " " + " | " + " " + "    " + "3" + " | " + "4" + " | " + "5" +
                                   "\n              " + "---+---+---  ---+---+---\n" +
                                   "               " + " " + " | " + " " + " | " + " " + "    " + "6" + " | " + "7" + " | " + "8";

            string actualBoard = this.boardBuilder.BuildGameBoard(board, boardSize);

            Assert.Equal(expectedBoard, actualBoard);
        }
        
        [Fact]
        public void Return4x4Board() {
            string[] board = {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "};
            int boardSize = (int) Math.Sqrt(board.Length);
            string expectedBoard = "               " + " " + " | " + " " + " | " + " " + " | " + " " + "    " + "0" + " | " + "1" + " | " + "2" + " | " + "3" +
                                   "\n              " + "---+---+---+---  ---+---+---+---\n" +
                                   "               " + " " + " | " + " " + " | " + " " + " | " + " " + "    " + "4" + " | " + "5" + " | " + "6" + " | " + "7" +
                                   "\n              " + "---+---+---+---  ---+---+---+---\n" +
                                   "               " + " " + " | " + " " + " | " + " " + " | " + " " + "    " + "8" + " | " + "9" + " |" + "10" + " |" + "11" +
                                   "\n              " + "---+---+---+---  ---+---+---+---\n" +
                                   "               " + " " + " | " + " " + " | " + " " + " | " + " " + "   " + "12" + " |" + "13" + " |" + "14" + " |" + "15";

            string actualBoard = this.boardBuilder.BuildGameBoard(board, boardSize);

            Assert.Equal(expectedBoard, actualBoard);
        }

        [Fact]
        public void Return3x3BoardWithMarkers() {
            string[] board = { " ", "X", " ", "O", "X", " ", " ", " ", " " };
            int boardSize = (int) Math.Sqrt(board.Length);
            string expectedBoard = "               " + " " + " | " + "X" + " | " + " " + "    " + "0" + " | " + "1" + " | " + "2" +
                                   "\n              " + "---+---+---  ---+---+---\n" +
                                   "               " + "O" + " | " + "X" + " | " + " " + "    " + "3" + " | " + "4" + " | " + "5" +
                                   "\n              " + "---+---+---  ---+---+---\n" +
                                   "               " + " " + " | " + " " + " | " + " " + "    " + "6" + " | " + "7" + " | " + "8";


            string actualBoard = this.boardBuilder.BuildGameBoard(board, boardSize);

            Assert.Equal(expectedBoard, actualBoard);
        }
        
        [Fact]
        public void Return4x4BoardWithMarkers() {
            string[] board = {" ", "X", " ", "O", " ", " ", "O", " ", "X", " ", " ", " ", " ", " ", " ", " "};
            int boardSize = (int) Math.Sqrt(board.Length);
            string expectedBoard = "               " + " " + " | " + "X" + " | " + " " + " | " + "O" + "    " + "0" + " | " + "1" + " | " + "2" + " | " + "3" +
                                   "\n              " + "---+---+---+---  ---+---+---+---\n" +
                                   "               " + " " + " | " + " " + " | " + "O" + " | " + " " + "    " + "4" + " | " + "5" + " | " + "6" + " | " + "7" +
                                   "\n              " + "---+---+---+---  ---+---+---+---\n" +
                                   "               " + "X" + " | " + " " + " | " + " " + " | " + " " + "    " + "8" + " | " + "9" + " |" + "10" + " |" + "11" +
                                   "\n              " + "---+---+---+---  ---+---+---+---\n" +
                                   "               " + " " + " | " + " " + " | " + " " + " | " + " " + "   " + "12" + " |" + "13" + " |" + "14" + " |" + "15";

            string actualBoard = this.boardBuilder.BuildGameBoard(board, boardSize);

            Assert.Equal(expectedBoard, actualBoard);
        }
    }
}