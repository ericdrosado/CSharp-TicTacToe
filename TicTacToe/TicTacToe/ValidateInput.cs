using System;
using System.Text.RegularExpressions;

namespace TicTacToe {
    
    public class ValidateInput {

        public bool IsInputNumericString(string input) {
            return Int32.TryParse(input, out int number);
        }

        public bool IsInputWithinBoardBounds(string[] board, string input) {
            int move = Int32.Parse(input);
            return move <= board.Length && move > 0;
        }

        public bool IsInputAvailableOnTheBoard(string[] board, string input) {
            int index = Int32.Parse(input) - 1;
            return board[index] == " ";
        }

        public bool IsInputASingleCharacter(string input) {
            return input.Length == 1 && Regex.IsMatch(input, @"[^\s]+");
        }

        public bool IsTheSameMarkerAsPlayer(string input, string playerMarker) {
            return input == playerMarker;
        }

        public bool IsCorrectBoardSize(string input) {
            int selection = Int32.Parse(input);
            return selection >= 3 && selection <= 4;
        }
    }
}
