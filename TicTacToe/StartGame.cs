using System;

namespace TicTacToe {
    
    class StartGame {
        
        static void Main(string[] args) {
            IO io = new IO();
            Prompts prompts = new Prompts();
            Game game = new Game(io, prompts);
            game.StartGame();
        }
    }
}
