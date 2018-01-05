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
            string expectedBoard = "               " + " " + " | " + " " + " | " + " " + "    " + "1" + " | " + "2" + " | " + "3" +
                                   "\n              " + "---+---+---  ---+---+---\n" +
                                   "               " + " " + " | " + " " + " | " + " " + "    " + "4" + " | " + "5" + " | " + "6" +
                                   "\n              " + "---+---+---  ---+---+---\n" +
                                   "               " + " " + " | " + " " + " | " + " " + "    " + "7" + " | " + "8" + " | " + "9";

            string actualBoard = this.boardBuilder.BuildGameBoard(board, boardSize);

            Assert.Equal(expectedBoard, actualBoard);
        }
        
        [Fact]
        public void Return4x4Board() {
            string[] board = {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "};
            int boardSize = (int) Math.Sqrt(board.Length);
            string expectedBoard = "               " + " " + " | " + " " + " | " + " " + " | " + " " + "    " + "1" + " | " + "2" + " | " + "3" + " | " + "4" +
                                   "\n              " + "---+---+---+---  ---+---+---+---\n" +
                                   "               " + " " + " | " + " " + " | " + " " + " | " + " " + "    " + "5" + " | " + "6" + " | " + "7" + " | " + "8" +
                                   "\n              " + "---+---+---+---  ---+---+---+---\n" +
                                   "               " + " " + " | " + " " + " | " + " " + " | " + " " + "    " + "9" + " |" + "10" + " |" + "11" + " |" + "12" +
                                   "\n              " + "---+---+---+---  ---+---+---+---\n" +
                                   "               " + " " + " | " + " " + " | " + " " + " | " + " " + "   " + "13" + " |" + "14" + " |" + "15" + " |" + "16";

            string actualBoard = this.boardBuilder.BuildGameBoard(board, boardSize);

            Assert.Equal(expectedBoard, actualBoard);
        }

        [Fact]
        public void Return3x3BoardWithMarkers() {
            string[] board = { " ", "X", " ", "O", "X", " ", " ", " ", " " };
            int boardSize = (int) Math.Sqrt(board.Length);
            string expectedBoard = "               " + " " + " | " + "X" + " | " + " " + "    " + "1" + " | " + "2" + " | " + "3" +
                                   "\n              " + "---+---+---  ---+---+---\n" +
                                   "               " + "O" + " | " + "X" + " | " + " " + "    " + "4" + " | " + "5" + " | " + "6" +
                                   "\n              " + "---+---+---  ---+---+---\n" +
                                   "               " + " " + " | " + " " + " | " + " " + "    " + "7" + " | " + "8" + " | " + "9";


            string actualBoard = this.boardBuilder.BuildGameBoard(board, boardSize);

            Assert.Equal(expectedBoard, actualBoard);
        }
        
        [Fact]
        public void Return4x4BoardWithMarkers() {
            string[] board = {" ", "X", " ", "O", " ", " ", "O", " ", "X", " ", " ", " ", " ", " ", " ", " "};
            int boardSize = (int) Math.Sqrt(board.Length);
            string expectedBoard = "               " + " " + " | " + "X" + " | " + " " + " | " + "O" + "    " + "1" + " | " + "2" + " | " + "3" + " | " + "4" +
                                   "\n              " + "---+---+---+---  ---+---+---+---\n" +
                                   "               " + " " + " | " + " " + " | " + "O" + " | " + " " + "    " + "5" + " | " + "6" + " | " + "7" + " | " + "8" +
                                   "\n              " + "---+---+---+---  ---+---+---+---\n" +
                                   "               " + "X" + " | " + " " + " | " + " " + " | " + " " + "    " + "9" + " |" + "10" + " |" + "11" + " |" + "12" +
                                   "\n              " + "---+---+---+---  ---+---+---+---\n" +
                                   "               " + " " + " | " + " " + " | " + " " + " | " + " " + "   " + "13" + " |" + "14" + " |" + "15" + " |" + "16";

            string actualBoard = this.boardBuilder.BuildGameBoard(board, boardSize);

            Assert.Equal(expectedBoard, actualBoard);
        }
    }
}