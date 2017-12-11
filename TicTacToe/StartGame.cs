using System;

namespace TicTacToe {
    
    class StartGame {
        
        static void Main(string[] args) {
            Board board = new Board();
            IO io = new IO();
            UI ui = new UI(board, io);
            Game game = new Game(ui);
            game.StartGame();
        }
    }
}
