using System;

namespace TicTacToe {
    
    class StartGame {
        
        static void Main(string[] args) {
            Board board = new Board();
            IO io = new IO();
            ValidateInput validateInput = new ValidateInput();
            UI ui = new UI(board, io, validateInput);
            Game game = new Game(ui);
            game.StartGame();
        }
    }
}
