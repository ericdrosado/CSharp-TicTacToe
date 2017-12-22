using System;

namespace TicTacToe {
    
    class StartGame {
        
        static void Main(string[] args) {
            Board board = new Board();
            WinConditions winConditions = new WinConditions();
            ComputerLogic computerLogic = new ComputerLogic(winConditions);
            IO io = new IO();
            ValidateInput validateInput = new ValidateInput();
            UI ui = new UI(io, validateInput);
            Game game = new Game(board, computerLogic, winConditions, ui);
            game.StartGame();
        }
    }
}
