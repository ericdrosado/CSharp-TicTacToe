using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TicTacToe {

    public class ComputerLogic {

        private WinConditions winConditions;

        public ComputerLogic(WinConditions winConditions) {
            this.winConditions = winConditions;
        }

        public int GetMove(string[] gameBoard) {
            List<Moves> moves = new List<Moves>();
            List<int> availableSpaces = GetAvailableSpaces(gameBoard);
            
            for (int i = 0; i < availableSpaces.Count; i++) {
                Moves moveValues = new Moves();
                moveValues.Spot = availableSpaces.ElementAt(i);
                string[] gameBoardCopy = (string[]) gameBoard.Clone();
                gameBoardCopy[availableSpaces.ElementAt(i)] = "O";
                moveValues.Score = GetBestMove(gameBoardCopy, -10000, 10000, "X", 0);
                moves.Add(moveValues);
            }
           
            int bestMove = 0;
            int bestMoveScore = -1000;
            for (int i = 0; i < moves.Count; i++) {
                if (moves[i].Score > bestMoveScore) {
                    bestMoveScore = moves[i].Score;
                    bestMove = i;
                }
            }

            return moves[bestMove].Spot;
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

        private int GetScore(string[] gameBoard, string marker, int depth) {
            int score;
            if (marker == "O" && this.winConditions.IsWinner(gameBoard)) {
                score = 1000 - depth;
            } else if (marker == "X" && this.winConditions.IsWinner(gameBoard)) {
                score = depth - 1000;
            } else {
                score = 0;
            }
            return score;
        }

        private int GetBestMove(string[] gameBoard, int alpha, int beta, string marker, int depth) {
            List<int> availableSpaces = GetAvailableSpaces(gameBoard);
            
            if (this.winConditions.IsWinner(gameBoard) || availableSpaces.Count == 0) {
                return GetScore(gameBoard, AlternateMarker(marker), depth);
            } 
            
            if (marker == "O") {
                for (int i = 0; i < availableSpaces.Count; i++) {
                    string[] gameBoardCopy = (string[]) gameBoard.Clone();
                    gameBoardCopy[availableSpaces.ElementAt(i)] = marker;
                    int score = GetBestMove(gameBoardCopy, alpha, beta, AlternateMarker(marker), depth++);
                    alpha = Math.Max(alpha, score );
                    if (beta <= alpha) {
                        break;
                    }  
                }
                return alpha;
            } else {
                for (int i = 0; i < availableSpaces.Count; i++) {
                    string[] gameBoardCopy = (string[]) gameBoard.Clone();
                    gameBoardCopy[availableSpaces.ElementAt(i)] = marker;
                    int score = GetBestMove(gameBoardCopy, alpha, beta, AlternateMarker(marker), depth++);
                    beta = Math.Min(beta, score);
                    if (beta <= alpha) {
                        break;
                    }  
                }
                return beta;
            }

        }

    }

    public class Moves {
        public int Spot;
        public int Score;
    }
}
