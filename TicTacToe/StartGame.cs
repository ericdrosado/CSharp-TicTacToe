using System;

namespace TicTacToe {
    
    class StartGame {
        
        static void Main(string[] args) {
            IO io = new IO();
            UI ui = new UI(io);
            Game game = new Game(ui);
            game.StartGame();
        }
    }
}
