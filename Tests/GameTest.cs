using System;
using System.Linq;
using TicTacToe;
using Xunit;

namespace Tests.TicTacToe {
    
    public class GameTest {
        
        private Board board;
        private Game game;

        public GameTest() {
            this.board = new Board();
            EndgameConditions endgameConditions = new EndgameConditions();
            ComputerLogic computerLogic = new ComputerLogic(endgameConditions);
            IO io = new IO();
            ValidateInput validateInput = new ValidateInput();
            UI ui = new UI(io, validateInput);
            this.game = new Game(this.board, computerLogic, endgameConditions, ui);
        }

        [Theory]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 })]
        [InlineData(new int[] { 0, 1, 2, 3 })]
        [InlineData(new int[] { 0, 2, 3, 5, 6, 8 })]
        [InlineData(new int[] { 6, 7, 8 })]
        public void ExpectMarkerToBePlaced(int[] moves) {
            int spacesAvailableBefore = this.board.GetAvailableSpaces().Count();

            foreach (int move in moves) {
                this.board.UpdateBoard(move);
            }
            int spacesAvailableAfter = this.board.GetAvailableSpaces().Count();

            Assert.NotEqual(spacesAvailableBefore, spacesAvailableAfter);
        }

    }
}
