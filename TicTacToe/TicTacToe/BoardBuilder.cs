namespace TicTacToe {
    
    public class BoardBuilder {
        private const int FourByFourBoard = 4;
        private const int MaximumSingleDigitNumber = 9;
        
        public string BuildGameBoard(string[] gameBoard, int boardSize) {
            string board = "";
            for (int index = 0; index <= boardSize * boardSize - boardSize; index += boardSize)
            {
                string row = BuildRow(gameBoard, boardSize, index);
                string displayRow = BuildDisplayRow(boardSize, index);
                board = string.Concat(board, row, displayRow);
                if (index < boardSize * boardSize - boardSize) {
                    board = boardSize == FourByFourBoard? string.Concat(board, "\n              " + "---+---+---+---  ---+---+---+---\n"): 
                        string.Concat(board, "\n              " + "---+---+---  ---+---+---\n");
                }
            }
            return board;
        }
        
        private string BuildRow(string[] gameBoard, int boardSize, int index) {
            string row = "               " + gameBoard[index];
            for (int i = index + 1; i < index + boardSize; i++) {
                row = string.Concat(row, " | " + gameBoard[i]);
            }
            return row;
        }

        private string BuildDisplayRow(int boardSize, int index) {
            string row = index > MaximumSingleDigitNumber? "   " + index:
                "    " + index;
            for (int i = index + 1; i < index + boardSize; i++) {
                row = i > MaximumSingleDigitNumber? string.Concat(row, " |" + i):
                    string.Concat(row, " | " + i);
            }
            return row;
        }    
    }
}