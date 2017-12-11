using System;

namespace TicTacToe {

    public class Game {
        
        private UI ui;

        public Game(UI ui) {
            this.ui = ui;
        }

        public void StartGame() {
            this.ui.NewGameView();
            this.ui.PlaceMarker();
        }

    }
}