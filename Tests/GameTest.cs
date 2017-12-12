using System;
using TicTacToe;
using Xunit;

namespace Tests.TicTacToe {
    
    public class GameTest {
        
        private Board board;
        private Game game;

        public GameTest() {
            this.board = new Board();
            IO io = new IO();
            ValidateInput validateInput = new ValidateInput();
            UI ui = new UI(io, validateInput);
            this.game = new Game(this.board, ui);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ExpectMarkerToBePlaced(int move) {
            string[] gameBoard = this.board.GameBoard;

            this.game.PlaceMarker(move);

            gameBoard[move] = "X";

            Assert.Equal(gameBoard, this.board.GameBoard);
        }


    }
}
