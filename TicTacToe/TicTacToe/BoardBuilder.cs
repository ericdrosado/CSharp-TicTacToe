using System;
using System.Runtime.CompilerServices;

namespace TicTacToe {
    
    public class BoardBuilder {

        private const int MaximumSingleDigitNumber = 9;
        private const int CellCorrection = 2;
        private const int NumberOfBoardsDisplayed = 2;
        
        public string BuildGameBoard(string[] gameBoard, int boardSize) {
            string board = "";
            for (int index = 0; index <= boardSize * boardSize - boardSize; index += boardSize) {
                string row = BuildRow(gameBoard, boardSize, index);
                string displayRow = BuildDisplayRow(boardSize, index);
                board = string.Concat(board, row, displayRow);
                if (index < boardSize * boardSize - boardSize) {
                    string horizontalFrame = BuildHorizontalFrame(boardSize);
                    horizontalFrame = string.Concat(horizontalFrame, "\n");
                    board = string.Concat(board, horizontalFrame);
                }
            }
            return board;
        }
        
        private string BuildRow(string[] gameBoard, int boardSize, int index) {
            string row = "               " + gameBoard[index];
            for (int i = index + 1; i < index + boardSize; i++) {
                row = string.Concat(row, " | " + gameBoard[i]);
            }
            return row;
        }

        private string BuildDisplayRow(int boardSize, int index) {
            string row = index > MaximumSingleDigitNumber? "   " + index:
                "    " + index;
            for (int i = index + 1; i < index + boardSize; i++) {
                row = i > MaximumSingleDigitNumber? string.Concat(row, " |" + i):
                    string.Concat(row, " | " + i);
            }
            return row;
        }

        private string BuildHorizontalFrame(int boardSize) {
            string horizontalFrame = "\n              " + "---";
            for (int i = 0; i < boardSize * NumberOfBoardsDisplayed - CellCorrection; i++) {
                string cellFrame = "+---";
                horizontalFrame = string.Concat(horizontalFrame, cellFrame);
                if (i == boardSize - CellCorrection) {
                    string outerCellFrame = "  ---";
                    horizontalFrame = string.Concat(horizontalFrame, outerCellFrame);
                }
            }
            return horizontalFrame;
        }
    }
}