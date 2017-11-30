using System;

namespace TicTacToe {
    
    class StartGame {
        
        static void Main(string[] args) {
            IO io = new IO();
            UI ui = new UI(io);
            Board board = new Board(ui);
            Game game = new Game(board, ui);
            game.StartGame();
        }
    }
}
