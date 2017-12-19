using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe {

    public class ComputerLogic {

        private WinConditions winConditions;

        public ComputerLogic(WinConditions winConditions) {
            this.winConditions = winConditions;
        }

        public int GetMove(string[] gameBoard) {
            return MiniMax(gameBoard, "O").spot;
        }

        private List<int> GetAvailableSpaces(string[] gameBoard) {
            List<int> availableSpaces = new List<int>();
            IEnumerable<string> availableSpacesStrings = gameBoard.Where(cell => Int32.TryParse(cell, out int number));
            foreach (string cell in availableSpacesStrings) {
                availableSpaces.Add(Int32.Parse(cell));
            }
            return availableSpaces;
        }

        private int GetScore(string[] gameBoard, string marker) {
            marker = marker == "O" ? "X" : "O";
            if (marker == "O" && this.winConditions.IsWinner(gameBoard)) {
                return 1000;
            } else if (marker == "X" && this.winConditions.IsWinner(gameBoard)) {
                return -1000;
            } else {
                return 0;
            }
        }

        private Moves MiniMax(string[] gameBoard, string marker) {
            List<int> availableSpaces = GetAvailableSpaces(gameBoard);

            if (this.winConditions.IsWinner(gameBoard) || availableSpaces.Count == 0) {
                Moves move = new Moves();
                move.score = GetScore(gameBoard, marker);
                return move;
            }

            List<Moves> moves = new List<Moves>();

            for (int i = 0; i < availableSpaces.Count; i++) {
                Moves moveValues = new Moves();
                moveValues.spot = availableSpaces.ElementAt(i);
                string[] gameBoardCopy = (string[]) gameBoard.Clone();
                gameBoardCopy[availableSpaces.ElementAt(i)] = marker;
                int score = MiniMax(gameBoardCopy, marker == "O" ? "X" : "O").score;
                moveValues.score = score;
                moves.Add(moveValues);
            }

            int bestMove = 0;
            if (marker == "O") {
                int max = -1000;
                for (int i = 0; i < moves.Count; i++) {
                    if (moves[i].score > max) {
                        max = moves[i].score;
                        bestMove = i;
                    }
                }
            } else {
                int min = 1000;
                for (int i = 0; i < moves.Count; i++) {
                    if (moves[i].score < min) {
                        min = moves[i].score;
                        bestMove = i;
                    }
                }
            }

            return moves[bestMove];
        }

    }

    public class Moves {
        public int spot;
        public int score;
    }
}
