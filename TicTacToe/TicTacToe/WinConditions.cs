using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe {

    public class WinConditions {

        public bool IsWinner(string[] gameBoard) {
            int boardDimension = (int) Math.Sqrt(gameBoard.Length);
            return IsWin(GetRows(boardDimension, gameBoard)) || 
                IsWin(GetColumns(boardDimension, gameBoard)) ||
                IsWin(GetDiagonals(boardDimension, gameBoard));
        }

        private bool IsWin(List<List<string>> collections) {
            foreach (var collection in collections) {
                if (collection.All(cell => cell == collection.First())) {
                    return true;
                }
            }
            return false;
        }

        private List<List<string>> GetRows(int boardDimension, string[] gameBoard) {
            List<List<string>> rows = new List<List<string>>();
            for (int i = 0; i <= (gameBoard.Length - boardDimension); i += boardDimension) {
                List<string> row = new List<string>();
                row.Add(gameBoard[i]);
                for (int j = (i + 1); j <= (i + (boardDimension - 1)); j++) {
                    row.Add(gameBoard[j]);
                }
                rows.Add(row);
            }
            return rows;

        }

        private List<List<string>> GetColumns(int boardDimension, string[] gameBoard) {
            List<List<string>> columns = new List<List<string>>();
            for (int i = 0; i < boardDimension; i++) {
                List<string> column = new List<string>();
                column.Add(gameBoard[i]);
                for (int j = (i + boardDimension); j <= (i + (boardDimension * 2)); j += boardDimension) {
                    column.Add(gameBoard[j]);
                }
                columns.Add(column);
            }
            return columns;
        }

        private List<List<string>> GetDiagonals(int boardDimension, string[] gameBoard) {
            List<List<string>> diagonals = new List<List<string>>();
            diagonals.Add(GetForwardDiagonal(boardDimension, gameBoard));
            diagonals.Add(GetBackwardDiagonal(boardDimension, gameBoard));
            return diagonals;
        }

        private List<string> GetForwardDiagonal(int boardDimension, string[] gameBoard) {
            List<string> diagonal = new List<string>();
            for (int i = boardDimension - 1; i <= (boardDimension - 1) * boardDimension; i += (boardDimension - 1) ) {
                diagonal.Add(gameBoard[i]);
            }
            return diagonal;
        }

        private List<string> GetBackwardDiagonal(int boardDimension, string[] gameBoard) {
            List<string> diagonal = new List<string>();
            for (int i = (gameBoard.Length - 1); i >= 0; i -= (boardDimension + 1)) {
                diagonal.Add(gameBoard[i]);
            }
            return diagonal;
        }

    }
}
