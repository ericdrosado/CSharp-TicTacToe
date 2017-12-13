using System;

namespace TicTacToe {

    public class EndgameConditions {

        public bool IsWin(string[] gameBoard) {
            return HorizontalWinTop(gameBoard) || HorizontalWinMiddle(gameBoard) || HorizontalWinBottom(gameBoard) ||
                VerticalWinLeft(gameBoard) || VerticalWinMiddle(gameBoard) || VerticalWinRight(gameBoard) ||
                DiagonalWinBackward(gameBoard) || DiagonalWinForward(gameBoard);
        }

        private bool HorizontalWinTop(string[] gameBoard) {
            return gameBoard[0] == gameBoard[1] && gameBoard[1] == gameBoard[2];
        }

        private bool HorizontalWinMiddle(string[] gameBoard) {
            return gameBoard[3] == gameBoard[4] && gameBoard[4]  == gameBoard[5];
        }

        private bool HorizontalWinBottom(string[] gameBoard) {
            return gameBoard[6] == gameBoard[7] && gameBoard[7] == gameBoard[8];
        }

        private bool VerticalWinLeft(string[] gameBoard) {
            return gameBoard[0] == gameBoard[3] && gameBoard[3] == gameBoard[6];
        }

        private bool VerticalWinMiddle(string[] gameBoard) {
            return gameBoard[1] == gameBoard[4] && gameBoard[4] == gameBoard[7];
        }

        private bool VerticalWinRight(string[] gameBoard) {
            return gameBoard[2] == gameBoard[5] && gameBoard[5] == gameBoard[8];
        }

        private bool DiagonalWinBackward(string[] gameBoard) {
            return gameBoard[0] == gameBoard[4] && gameBoard[4] == gameBoard[8];
        }

        private bool DiagonalWinForward(string[] gameBoard) {
            return gameBoard[2] == gameBoard[4] && gameBoard[4] == gameBoard[6];
        }
    }
}
