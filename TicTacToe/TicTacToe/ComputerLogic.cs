using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe {

    public class ComputerLogic {

        private WinConditions winConditions;

        public ComputerLogic(WinConditions winConditions) {
            this.winConditions = winConditions;
        }

        public int GetMove(string[] gameBoard, string marker) {
            return GetBestMove(gameBoard, marker).Spot;
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
            return marker == Board.AiMarker ? Board.PlayerMarker : Board.AiMarker;
        }

        private Moves GetScore(string[] gameBoard, string marker, Moves move) {
            marker = AlternateMarker(marker);
            if (marker == Board.AiMarker && this.winConditions.IsWinner(gameBoard)) {
                move.Score = 1000;
            } else if (marker == Board.PlayerMarker && this.winConditions.IsWinner(gameBoard)) {
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
                int index = Array.IndexOf(gameBoardCopy, moveValues.Spot.ToString());
                gameBoardCopy[index] = marker;
                int score = GetBestMove(gameBoardCopy, AlternateMarker(marker)).Score;
                moveValues.Score = score;
                moves.Add(moveValues);
            }

            int bestMove = 0;
            if (marker == Board.AiMarker) {
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
