using System;

namespace TicTacToe {

    public class UI {

        private const int BoardIndexCorrection = 1;
        private BoardBuilder boardBuilder;
        private IO io;
        private ValidateInput validateInput;

        public UI(BoardBuilder boardBuilder, IO io, ValidateInput validateInput) {
            this.boardBuilder = boardBuilder;
            this.io = io;
            this.validateInput = validateInput;
        } 

        public int GetMove(string[] board, int boardSize) {
            string input = this.io.GetInput();
            while (!this.validateInput.IsInputNumericString(input) || !this.validateInput.IsInputWithinBoardBounds(board, input) || 
                   !this.validateInput.IsInputAvailableOnTheBoard(board, input)) {
                IncorrectInputView(board, boardSize);
                input = this.io.GetInput();
            }
            int move = Int32.Parse(input) - BoardIndexCorrection;
            return move;
        }

        public string GetMarkerChoice(string[] board) {
            this.io.Print(ChooseHumanMarkerPrompt());
            string input = this.io.GetInput();
            while (!this.validateInput.IsInputASingleCharacter(input)) {
                IncorrectMarkerChoiceView();
                input = this.io.GetInput();
            }
            return input;
        }

        public string GetAIMarkerChoice(string playerMarker, string[] board) {
            this.io.Print(ChooseAIMarkerPrompt());
            string input = this.io.GetInput();
            while (!this.validateInput.IsInputASingleCharacter(input) || this.validateInput.IsTheSameMarkerAsPlayer(input, playerMarker)) {
                IncorrectAIMarkerChoiceView();
                input = this.io.GetInput();
            }
            return input;
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
        
        private void IncorrectMarkerChoiceView() {
            Console.Clear();
            this.io.Print(IncorrectMarkerChoicePrompt());
        }

        private void IncorrectAIMarkerChoiceView() {
            Console.Clear();
            this.io.Print(IncorrectAIMarkerChoicePrompt());
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

        public void NewGameView() {
            this.io.Print(Greeting());
            this.io.Print(Instructions());
            this.io.Print(ChooseBoardSizePrompt());
        }

        public void BoardView(string[] board, int boardSize) {
            string gameBoard = this.boardBuilder.BuildGameBoard(board, boardSize);
            this.io.Print(BoardBorder(gameBoard));
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
        
        private string ChooseHumanMarkerPrompt() {
            return
                "+-------------------------------------------------------+\n" +
                "|Please choose a single character as your marker and    |\n" +
                "|press enter.                                           |\n" +
                "+-------------------------------------------------------+";
        }
        
        private string ChooseAIMarkerPrompt() {
            return
                "+-------------------------------------------------------+\n" +
                "|Please choose a single character as the computer's     |\n" +
                "|marker that is different than yours and press enter.   |\n" +
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
                "|The entry used is not a valid entry. Make sure the move|\n" +
                "|is available on the board.                             |\n" +
                "+-------------------------------------------------------+";
        }

        private string IncorrectBoardSizePrompt() {
            return 
                "+-------------------------------------------------------+\n" +
                "|The entry used is not a valid entry. Be sure to input  |\n" +
                "|an entry of '3' for 3X3 or '4' for 4X4.                |\n" +
                "+-------------------------------------------------------+";
        }
        
        private string IncorrectMarkerChoicePrompt() {
            return 
                "+-------------------------------------------------------+\n" +
                "|The entry used is not a valid entry. Be sure to input  |\n" +
                "|a single character.                                    |\n" +
                "+-------------------------------------------------------+";
        }
        
        private string IncorrectAIMarkerChoicePrompt() {
            return 
                "+-------------------------------------------------------+\n" +
                "|The entry used is not a valid entry. Be sure to input  |\n" +
                "|a single character that is different than your marker. |\n" +
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