using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TicTacToe {

    public class ComputerLogic
    {
        private const int BoardIndexCorrection = 1;
        private const int MaximumScore = 1000;
        private const int MinimumScore = -1000;
        private const int TieScore = 0;
        private const int OptimalAIDepth = 10;

        private WinConditions winConditions;

        public ComputerLogic(WinConditions winConditions) {
            this.winConditions = winConditions;
        }

        public int GetMove(string[] gameBoard) {
            List<Moves> moves = new List<Moves>();
            List<int> availableSpaces = GetAvailableSpaces(gameBoard);
            
            for (int index = 0; index < availableSpaces.Count; index++) {
                Moves moveValues = new Moves();
                moveValues.Spot = availableSpaces.ElementAt(index);
                string[] gameBoardCopy = (string[]) gameBoard.Clone();
                gameBoardCopy[availableSpaces.ElementAt(index)] = Board.AiMarker;
                moveValues.Score = GetScore(gameBoardCopy, MinimumScore, MaximumScore, Board.PlayerMarker, 0);
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
                if (gameBoard[index] != Board.PlayerMarker && gameBoard[index] != Board.AiMarker) {
                    availableSpaces.Add(index);
                }
            }
            
            return availableSpaces;
        }

        private string AlternateMarker(string marker) {
            return marker == Board.AiMarker ? Board.PlayerMarker : Board.AiMarker;
        }

        private int GetGameScore(string[] gameBoard, string marker, int depth) {
            int score;
            if (marker == Board.AiMarker && this.winConditions.IsWinner(gameBoard)) {
                score = MaximumScore - depth;
            } else if (marker == Board.PlayerMarker && this.winConditions.IsWinner(gameBoard)) {
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

                if (marker == Board.AiMarker) {
                    alpha = Math.Max(alpha, score);
                } else {
                    beta = Math.Min(beta, score);
                }
                
                if (beta <= alpha || depth == OptimalAIDepth) {
                        break;
                }   
            }

            if (marker == Board.AiMarker) {
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
