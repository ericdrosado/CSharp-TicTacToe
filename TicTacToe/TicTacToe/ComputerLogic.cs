using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TicTacToe {

    public class ComputerLogic
    {

        private const int MaximumScore = 1000;
        private const int MinimumScore = -1000;
        private const int TieScore = 0;
        private const int OptimalAIDepth = 15;

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
                moveValues.Score = GetScore(gameBoardCopy, MinimumScore, MaximumScore, "X", 0);
                moves.Add(moveValues);
            }
           
            int bestMove = 0;
            int bestMoveScore = MinimumScore;
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
            for (int index = 0; index < gameBoard.Length; index++) {
                if (gameBoard[index] != "X" && gameBoard[index] != "O") {
                    availableSpaces.Add(index);
                }
            }
            
            return availableSpaces;
        }

        private string AlternateMarker(string marker) {
            return marker == "O" ? "X" : "O";
        }

        private int GetGameScore(string[] gameBoard, string marker, int depth) {
            int score;
            if (marker == "O" && this.winConditions.IsWinner(gameBoard)) {
                score = MaximumScore - depth;
            } else if (marker == "X" && this.winConditions.IsWinner(gameBoard)) {
                score = MinimumScore + depth;
            } else {
                score = TieScore;
            }
            return score;
        }

        private int GetScore(string[] gameBoard, int alpha, int beta, string marker, int depth) {
            List<int> availableSpaces = GetAvailableSpaces(gameBoard);
            
            if (this.winConditions.IsWinner(gameBoard) || availableSpaces.Count == 0) {
                return GetGameScore(gameBoard, AlternateMarker(marker), depth);
            }

            for (int i = 0; i < availableSpaces.Count; i++) {
                string[] gameBoardCopy = (string[]) gameBoard.Clone();
                gameBoardCopy[availableSpaces.ElementAt(i)] = marker;
                int score = GetScore(gameBoardCopy, alpha, beta, AlternateMarker(marker), depth++);

                if (marker == "O") {
                    alpha = Math.Max(alpha, score);
                } else {
                    beta = Math.Min(beta, score);
                }
                
                if (beta <= alpha || depth == OptimalAIDepth) {
                        break;
                }   
            }

            if (marker == "O") {
                return alpha;
            } else {
                return beta;
            }

        }

    }

    public class Moves {
        public int Spot;
        public int Score;
    }
}
