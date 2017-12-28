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

        public string CurrentMarker {
            get { return currentMarker; }
        }

        public void CreateBoard(int boardDimension) {
            BuildBoard(boardDimension);
            AssignSpaces();
        }

        private void BuildBoard(int boardDimension) {
            int totalSpaces = (int) Math.Pow(boardDimension, 2);
            gameBoard = new string[totalSpaces];
        }

        private void AssignSpaces() {
            for (int i = 0; i < gameBoard.Length; i++) {
                gameBoard[i] = (i).ToString();
            }
        }
        
        public void UpdateBoard(int move) {
            gameBoard[move] = currentMarker;
            SwitchMarker();
        }

        public IEnumerable<string> GetAvailableSpaces() {
            return gameBoard.Where(cell => Int32.TryParse(cell, out int number));
        }

        public void SwitchMarker() {
            currentMarker = currentMarker == "X" ? "O" : "X";
        }

    }
}
