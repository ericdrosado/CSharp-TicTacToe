using System;

namespace TicTacToe {

    public class UI {

        private Board board;
        private IO io;
        private ValidateInput validateInput;

        public UI(Board board, IO io, ValidateInput validateInput) {
            this.board = board; 
            this.io = io;
            this.validateInput = validateInput;
        }

        public int GetMove() {
            string input = this.io.GetInput();
            while (!this.validateInput.IsInputOnBoard(input, this.board.GameBoard) || !this.validateInput.IsInputNumericString(input)) {
                this.io.Print(InvalidEntryPrompt());
                input = this.io.GetInput();
            }
            int move = Int32.Parse(input);
            return move;
        }

        public void PlaceMarker(int move) {
            this.board.UpdateBoard(move);
        }

        public void NewGameView() {
            string[] gameBoard = this.board.GameBoard; 
            this.io.Print(Greeting());
            this.io.Print(Instructions());
            string board = GameBoard(gameBoard);
            this.io.Print(BoardHeader(TurnPrompt("X")));
            this.io.Print(BoardBorder(board));
        }

        public void BoardView() {
            string[] gameBoard = this.board.GameBoard;
            string board = GameBoard(gameBoard);
            this.io.Print(BoardBorder(board));
        }

        public string GameBoard(string[] gameBoard) {
            return
            "                       " + gameBoard[0] + " | " + gameBoard[1] + " | " + gameBoard[2] +
            "\n                      " + "---+---+---\n" +
            "                       " + gameBoard[3] + " | " + gameBoard[4] + " | " + gameBoard[5] +
            "\n                      " + "---+---+---\n" +
            "                       " + gameBoard[6] + " | " + gameBoard[7] + " | " + gameBoard[8] + "\n";
        }

        private string Greeting() {
            return
            "+-------------------------------------------------------+\n" +
            "|                  Welcome to TicTacToe                 |\n" +
            "+-------------------------------------------------------+";
        }

        private string Instructions() {
            return
            "+-------------------------------------------------------+\n" +
            "|Instuctions: The object of TicTacToe is to get three   |\n" +
            "|of your markers in a row before your opponent can. If  |\n" +
            "|all the spaces are occupied with no winner, the game   |\n" +
            "|ends in a draw. You can choose a space by typing the   |\n" +
            "|number that corresponds to an open space and then press|\n" +
            "|enter.                                                 |\n" +
            "+-------------------------------------------------------+";
        }

        private string BoardHeader(string headerText) {
            return
           "+-------------------------------------------------------+\n" +
           headerText;
        }

        private string BoardBorder(string board) {
            return
            "+-------------------------------------------------------+\n" +
            board +
            "+-------------------------------------------------------+\n";
        }

        private string TurnPrompt(string marker) {
            return String.Format("  {0}'s turn", marker);
        }

        private string InvalidEntryPrompt() {
            return 
            "+-------------------------------------------------------+\n" +
            "|The entry used is not a valid entry. Be sure to choose |\n" +
            "|a value from 0 - 8.                                    |\n" +
            "+-------------------------------------------------------+";
        }
    }
}