using System;

namespace TicTacToe {
    
    class StartGame {
        
        static void Main(string[] args) {
            Board board = new Board();
            EndgameConditions endgameConditions = new EndgameConditions();
            ComputerLogic computerLogic = new ComputerLogic(endgameConditions);
            IO io = new IO();
            ValidateInput validateInput = new ValidateInput();
            UI ui = new UI(io, validateInput);
            Game game = new Game(board, computerLogic, endgameConditions, ui);
            game.StartGame();
        }
    }
}
