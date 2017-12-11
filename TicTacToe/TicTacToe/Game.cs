using System;

namespace TicTacToe {

    public class Game {

        private Board board;
        private UI ui;

        public Game(Board board, UI ui) {
            this.board = board;
            this.ui = ui;
        }

        public void StartGame() {
            this.ui.NewGameView(this.board.GameBoard);
        }

    }
}