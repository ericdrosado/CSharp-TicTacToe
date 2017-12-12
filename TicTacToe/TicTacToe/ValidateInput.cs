using System;

namespace TicTacToe {
    
    public class ValidateInput {

        private Board board;

        public ValidateInput(Board board) {
            this.board = board; 
        }
        
        public bool IsInputOnBoard(string input) {
            bool hasValue = Array.Exists(this.board.GameBoard, entry => entry.Equals(input));
            return hasValue;
        }

        public bool IsInputNumericString(string input) {
            int number;
            return Int32.TryParse(input, out number);
        }
    }
}
