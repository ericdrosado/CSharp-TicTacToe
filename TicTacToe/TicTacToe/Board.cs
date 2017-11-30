using System;

namespace TicTacToe {
    
    public class Board {

        private string[] gameBoard = {"0", "1", "2", "3", "4", "5", "6", "7", "8"};
        private string currentMarker = "X";
        private UI ui;

        public Board(UI ui) {
            this.ui = ui;
        }

        public string[] GameBoard {
            get { return gameBoard; }
        }

        public string CurrentMarker {
            get { return currentMarker; }
        }

    }
}
