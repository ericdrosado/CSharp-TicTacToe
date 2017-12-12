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
            int move = this.ui.GetMove(this.board.GameBoard);
            PlaceMarker(move);
            this.ui.BoardView(this.board.GameBoard);
        }

        public void PlaceMarker(int move) {
            this.board.UpdateBoard(move);
        }

    }
}