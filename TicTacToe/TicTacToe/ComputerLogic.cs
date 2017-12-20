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
            return GetBestMove(gameBoard, "O").Spot;
        }

        private List<int> GetAvailableSpaces(string[] gameBoard) {
            List<int> availableSpaces = new List<int>();
            IEnumerable<string> availableSpacesStrings = gameBoard.Where(cell => Int32.TryParse(cell, out int number));
            foreach (string cell in availableSpacesStrings) {
                availableSpaces.Add(Int32.Parse(cell));
            }
            return availableSpaces;
        }

        private string AlternateMarker(string marker) {
            return marker == "O" ? "X" : "O";
        }

        private Moves GetScore(string[] gameBoard, string marker, Moves move) {
            marker = AlternateMarker(marker);
            if (marker == "O" && this.winConditions.IsWinner(gameBoard)) {
                move.Score = 1000;
            } else if (marker == "X" && this.winConditions.IsWinner(gameBoard)) {
                move.Score = -1000;
            } else {
                move.Score = 0;
            }
            return move;
        }

        private Moves GetBestMove(string[] gameBoard, string marker) {
            List<int> availableSpaces = GetAvailableSpaces(gameBoard);

            if (this.winConditions.IsWinner(gameBoard) || availableSpaces.Count == 0) {
                Moves move = new Moves();
                move = GetScore(gameBoard, marker, move);
                return move;
            }

            List<Moves> moves = new List<Moves>();

            for (int i = 0; i < availableSpaces.Count; i++) {
                Moves moveValues = new Moves();
                moveValues.Spot = availableSpaces.ElementAt(i);
                string[] gameBoardCopy = (string[]) gameBoard.Clone();
                gameBoardCopy[availableSpaces.ElementAt(i)] = marker;
                int score = GetBestMove(gameBoardCopy, AlternateMarker(marker)).Score;
                moveValues.Score = score;
                moves.Add(moveValues);
            }

            int bestMove = 0;
            if (marker == "O") {
                int bestMoveScore = -1000;
                for (int i = 0; i < moves.Count; i++) {
                    if (moves[i].Score > bestMoveScore) {
                        bestMoveScore = moves[i].Score;
                        bestMove = i;
                    }
                }
            } else {
                int bestMoveScore = 1000;
                for (int i = 0; i < moves.Count; i++) {
                    if (moves[i].Score < bestMoveScore) {
                        bestMoveScore = moves[i].Score;
                        bestMove = i;
                    }
                }
            }

            return moves[bestMove];
        }

    }

    public class Moves {
        public int Spot;
        public int Score;
    }
}
