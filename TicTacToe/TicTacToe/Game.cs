using System;
using System.Linq;

namespace TicTacToe {

    public class Game {

        private Board board;
        private EndgameConditions endgameConditions;
        private UI ui;

        public Game(Board board, EndgameConditions endgameConditions, UI ui) {
            this.board = board;
            this.endgameConditions = endgameConditions;
            this.ui = ui;
        }

        public void StartGame() {
            this.ui.NewGameView(this.board.GameBoard);
            while (this.board.AvailableSpaces().Count() > 0) {
                this.ui.BoardView(this.board.GameBoard);
                this.ui.PrintTurnPrompt(this.board.CurrentMarker);
                int move = this.ui.GetMove(this.board.GameBoard);
                this.board.UpdateBoard(move);
                if (this.endgameConditions.IsWin(this.board.GameBoard)) { break; }
                this.board.SwitchMarker();
            }
            this.ui.BoardView(this.board.GameBoard);
            this.ui.PrintEndgamePrompt(this.endgameConditions.IsWin(this.board.GameBoard), this.board.CurrentMarker);
        }

    }
}