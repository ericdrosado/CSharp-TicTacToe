using System;

namespace TicTacToe {
    
    public class ValidateInput {
        
        public bool IsInputOnBoard(string input, string[] gameBoard) {
            bool hasValue = Array.Exists(gameBoard, entry => entry.Equals(input));
            return hasValue;
        }

        public bool IsInputNumericString(string input) {
            int number;
            return Int32.TryParse(input, out number);
        }
    }
}
