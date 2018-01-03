using System;

namespace TicTacToe {

    public class UI {
        
        private IO io;
        private ValidateInput validateInput;

        private const int FourByFourBoard = 4;
        private const int MaximumSingleDigitNumber = 9;

        public UI(IO io, ValidateInput validateInput) {
            this.io = io;
            this.validateInput = validateInput;
        }

        public int GetMove(string[] board, int boardSize) {
            string input = this.io.GetInput();
            while (!this.validateInput.IsInputOnBoard(input, board) || !this.validateInput.IsInputNumericString(input)) {
                IncorrectInputView(board, boardSize);
                input = this.io.GetInput();
            }
            int move = Int32.Parse(input);
            return move;
        }

        public int GetBoardSize() {
            string input = this.io.GetInput();
            while (!this.validateInput.IsInputNumericString(input) || !this.validateInput.IsCorrectBoardSize(input)) {
                IncorrectBoardSizeView();
                input = this.io.GetInput();
            }
            int boardSize = Int32.Parse(input);
            return boardSize;
        }

        private void IncorrectInputView(string[] board, int boardSize) {
            Console.Clear();
            BoardView(board, boardSize);
            this.io.Print(InvalidEntryPrompt());
        }

        private void IncorrectBoardSizeView() {
            Console.Clear();
            this.io.Print(IncorrectBoardSizePrompt());
        }

        public void PrintTurnPrompt(string marker) {
            this.io.Print(BoardHeader(TurnPrompt(marker)));
        }

        public void PrintEndgamePrompt(bool isWin, string marker) {
            if (isWin) {
                this.io.Print(BoardHeader(WinPrompt(marker)));
            } else {
                this.io.Print(BoardHeader(TiePrompt()));
            }
        }

        public void NewGameView(string[] board) {
            this.io.Print(Greeting());
            this.io.Print(Instructions());
            this.io.Print(ChooseBoardSizePrompt());
        }

        public void BoardView(string[] board, int boardSize) {
            string gameBoard = BuildBoard(board, boardSize);
            this.io.Print(BoardBorder(gameBoard));
        }

        public string BuildBoard(string[] gameBoard, int boardSize) {
            string board = "";
            for (int index = 0; index <= boardSize * boardSize - boardSize; index += boardSize) {
                string row = BuildRow(gameBoard, boardSize, index);
                board = string.Concat(board, row);
                if (index < boardSize * boardSize - boardSize) {
                    board = boardSize == FourByFourBoard? string.Concat(board, "\n                      " + "---+---+---+---\n"): 
                        string.Concat(board, "\n                      " + "---+---+---\n");
                }
            }
            return board;
        }

        private string BuildRow(string[] gameBoard, int boardSize, int index) {
            string row = index > 9? "                      " + gameBoard[index]:
                "                       " + gameBoard[index];
            for (int i = index + 1; i < index + boardSize; i++) {
                row = i > MaximumSingleDigitNumber? string.Concat(row, " |" + gameBoard[i]):
                    string.Concat(row, " | " + gameBoard[i]);
            }
            return row;
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

        private string ChooseBoardSizePrompt() {
            return
            "+-------------------------------------------------------+\n" +
            "|Please choose the size of the board you would like to  |\n" +
            "|play on. Enter '3' for 3X3 or '4' for 4X4 board.       |\n" +
            "+-------------------------------------------------------+";
        }

        private string BoardHeader(string headerText) {
            return
            headerText + "\n" +
            "+-------------------------------------------------------+\n";
        }

        private string BoardBorder(string board) {
            return
            "+-------------------------------------------------------+\n" +
            board + "\n" +
            "+-------------------------------------------------------+\n";
        }

        private string TurnPrompt(string marker) {
            return String.Format("  {0}'s turn", marker);
        }

        private string InvalidEntryPrompt() {
            return 
            "+-------------------------------------------------------+\n" +
            "|The entry used is not a valid entry. Be sure to choose |\n" +
            "|a value on the board that has not been chosen.         |\n" +
            "+-------------------------------------------------------+";
        }

        private string IncorrectBoardSizePrompt() {
            return 
            "+-------------------------------------------------------+\n" +
            "|The entry used is not a valid entry. Be sure to input  |\n" +
            "|an entry of '3' for 3X3 or '4' for 4X4.                |\n" +
            "+-------------------------------------------------------+";
        }

        private string WinPrompt(string marker) {
            return String.Format("  {0} Wins!", marker);
        }

        private string TiePrompt() {
            return "Tie Game!";
        }

    }
}