using System;
using System.Collections.Generic;

namespace TicTacToe {
    
    public class Board {

        private List<string> availableSpaces = new List<string>();
        private string[] gameBoard = {"0", "1", "2", "3", "4", "5", "6", "7", "8"};
        private string currentMarker = "X";

        public string[] GameBoard {
            get { return gameBoard; }
        }

        public List<string> GetAvailableSpaces {
            get { return availableSpaces; }
        }

        public void CreateNewBoard() {
            AvailableSpaces();
        }

        public void UpdateBoard(int move) {
            gameBoard[move] = currentMarker;
            AvailableSpaces();
        }

        private void AvailableSpaces() {
            availableSpaces.Clear();
            foreach (string cell in gameBoard) {
                if (Int32.TryParse(cell, out int number)) {
                    availableSpaces.Add(cell);
                }
            }
        }

    }
}
