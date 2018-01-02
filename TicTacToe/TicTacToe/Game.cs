using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe {

    public class Game {

        private Board board;
        private ComputerLogic computerLogic;
        private WinConditions winConditions;
        private UI ui;

        public Game(Board board, ComputerLogic computerLogic, WinConditions winConditions, UI ui) {
            this.board = board;
            this.computerLogic = computerLogic;
            this.winConditions = winConditions;
            this.ui = ui;
        }

        public void StartGame() {
            this.ui.NewGameView(this.board.GameBoard);
            string playerMarker = this.ui.GetMarkerChoice(this.board.GameBoard);
            string aiMarker = this.ui.GetAIMarkerChoice(playerMarker, this.board.GameBoard);
            this.board.SetMarkers(playerMarker, aiMarker);
            while (this.board.GetAvailableSpaces().Count() > 0) {
                this.ui.BoardView(this.board.GameBoard);
                this.ui.PrintTurnPrompt(this.board.CurrentMarker);
                int move = this.board.CurrentMarker == Board.AiMarker ? this.computerLogic.GetMove(this.board.GameBoard, Board.AiMarker) : 
                    this.ui.GetMove(this.board.GameBoard);
                this.board.UpdateBoard(move);
                if (this.winConditions.IsWinner(this.board.GameBoard) || this.board.GetAvailableSpaces().Count() == 0) { 
                    this.board.SwitchMarker();
                    break; 
                }
                Console.Clear();
            }
            this.ui.BoardView(this.board.GameBoard);
            this.ui.PrintEndgamePrompt(this.winConditions.IsWinner(this.board.GameBoard), this.board.CurrentMarker);
        }

    }
}