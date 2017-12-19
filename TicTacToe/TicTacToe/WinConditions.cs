using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe {

    public class WinConditions {

        public bool IsWin(string[] gameBoard) {
            return IsHorizontalWin(gameBoard) || IsVerticalWin(gameBoard) || 
                IsForwardDiagonalWin(gameBoard) || IsBackwardDiagonalWin(gameBoard);
        }

        private bool IsHorizontalWin(string[] gameBoard) {
            int rowLength = (int)Math.Sqrt(gameBoard.Length);
            List<string> row = new List<string>();
            for (int i = 0; i <= (gameBoard.Length - rowLength); i += rowLength) {
                row.Add(gameBoard[i]);
                for (int j = (i + 1); j <= (i + (rowLength - 1)); j++) {
                    row.Add(gameBoard[j]);
                }
                if (row.All(cell => cell == row.First())) {
                    return true;
                } else {
                    row.Clear();
                }
            }
            return false;
        }

        private bool IsVerticalWin(string[] gameBoard) {
            int columnLength = (int) Math.Sqrt(gameBoard.Length);
            List<string> column = new List<string>();
            for (int i = 0; i < columnLength; i++) {
                column.Add(gameBoard[i]);
                for (int j = (i + columnLength); j <= (i + (columnLength * 2)); j += columnLength) {
                    column.Add(gameBoard[j]);
                }
                if (column.All(cell => cell == column.First())) {
                    return true;
                } else {
                    column.Clear();
                }
            }
            return false;
        }

        private bool IsForwardDiagonalWin(string[] gameBoard) {
            int diagonalLength = (int)Math.Sqrt(gameBoard.Length);
            List<string> diagonal = new List<string>();
            for (int i = diagonalLength - 1; i <= (diagonalLength - 1) * diagonalLength; i += (diagonalLength - 1) ) {
                diagonal.Add(gameBoard[i]);
            }
            if (diagonal.All(cell => cell == diagonal.First())) {
                return true;
            }
            return false;
        }

        private bool IsBackwardDiagonalWin(string[] gameBoard) {
            int diagonalLength = (int)Math.Sqrt(gameBoard.Length);
            List<string> diagonal = new List<string>();
            for (int i = (gameBoard.Length - 1); i >= 0; i -= (diagonalLength + 1)) {
                diagonal.Add(gameBoard[i]);
            }
            if (diagonal.All(cell => cell == diagonal.First())) {
                return true;
            }
            return false;
        }

    }
}
