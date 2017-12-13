using System;
using System.Linq;

namespace TicTacToe {

    public class Game {

        private Board board;
        private UI ui;

        public Game(Board board, UI ui) {
            this.board = board;
            this.ui = ui;
        }

        public void StartGame() {
            this.board.CreateNewBoard();
            this.ui.NewGameView(this.board.GameBoard);
            while (this.board.AvailableSpaces().Count() > 0) {
                this.ui.PrintTurnPrompt();
                int move = this.ui.GetMove(this.board.GameBoard);
                PlaceMarker(move);
                this.ui.BoardView(this.board.GameBoard);
            }
            this.ui.PrintEndPrompt();
        }

        public void PlaceMarker(int move) {
            this.board.UpdateBoard(move);
        }

    }
}