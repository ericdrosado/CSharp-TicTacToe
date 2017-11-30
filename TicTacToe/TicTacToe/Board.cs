using System;

namespace TicTacToe {
    
    public class Board {

        private string[] gameBoard = {"0", "1", "2", "3", "4", "5", "6", "7", "8"};
        private string currentMarker = "X";

        public string[] GameBoard {
            get { return gameBoard; }
        }

        public void UpdateBoard(int move) {
            gameBoard[move] = currentMarker;
        }

    }
}
