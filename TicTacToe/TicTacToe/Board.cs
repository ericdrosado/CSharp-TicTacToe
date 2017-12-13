using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe {
    
    public class Board {

        private string[] gameBoard = {"0", "1", "2", "3", "4", "5", "6", "7", "8"};
        private string currentMarker = "X";

        public string[] GameBoard {
            get { return gameBoard; }
        }

        public void CreateNewBoard() {
            AvailableSpaces();
        }

        public void UpdateBoard(int move) {
            gameBoard[move] = currentMarker;
            AvailableSpaces();
        }

        public IEnumerable<string> AvailableSpaces() {
            return gameBoard.Where(cell => Int32.TryParse(cell, out int number));
        }

    }
}
