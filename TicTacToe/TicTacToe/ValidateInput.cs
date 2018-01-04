using System;

namespace TicTacToe {
    
    public class ValidateInput {

        public bool IsInputNumericString(string input) {
            return Int32.TryParse(input, out int number);
        }

        public bool IsCorrectBoardSize(string input) {
            int selection = Int32.Parse(input);
            return selection >= 3 && selection <= 4;
        }
    }
}
