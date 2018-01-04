using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe {
    
    public class Board {

        private string currentMarker;
        private static string playerMarker;
        private static string aiMarker;
        private string[] gameBoard = {"1", "2", "3", "4", "5", "6", "7", "8", "9"};

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

        public void UpdateBoard(int move) {
            int index = Array.IndexOf(gameBoard, move.ToString());
            gameBoard[index] = currentMarker;
            SwitchMarker();
        }

        public IEnumerable<string> GetAvailableSpaces() {
            return gameBoard.Where(cell => Int32.TryParse(cell, out int number));
        }

        public void SwitchMarker() {
            currentMarker = currentMarker == playerMarker ? aiMarker : playerMarker;
        }

    }
}
