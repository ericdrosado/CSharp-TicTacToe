using System;

namespace TicTacToe {
    
    public class ValidateInput {
        
        public bool IsInputOnBoard(string input, string[] gameBoard) {
            return Array.Exists(gameBoard, entry => entry.Equals(input));
        }

        public bool IsInputNumericString(string input) {
            return Int32.TryParse(input, out int number);
        }

        public bool IsInputASingleCharacter(string input) {
            return input.Length == 1;
        }

        public bool IsTheSameMarkerAsPlayer(string input, string playerMarker) {
            return input == playerMarker;
        }
    }
}
