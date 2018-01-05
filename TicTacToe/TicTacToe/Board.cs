using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe {
    
    public class Board {
    
        private const int BoardCorrection = 1;
        private string currentMarker;
        private static string playerMarker;
        private static string aiMarker;
        private string[] gameBoard;

        public string[] GameBoard {
            get { return gameBoard; }
        }

        public void SetMarkers(string player, string ai) {
            playerMarker = player;
            aiMarker = ai;
            currentMarker = playerMarker;
        }
        
        public static string PlayerMarker {
            get { return playerMarker; }
        }
        
        public static string AiMarker {
            get { return aiMarker; }
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
                gameBoard[i] = " ";
            }
        }
        
        public void UpdateBoard(int move) {
            int index = move;
            gameBoard[index] = currentMarker;
            SwitchMarker();
        }

        public IEnumerable<string> GetAvailableSpaces() {
            return gameBoard.Where(cell => cell == " ");
        }

        public void SwitchMarker() {
            currentMarker = currentMarker == PlayerMarker ? AiMarker : PlayerMarker;
        }

    }
}
