using System;

namespace TicTacToe {

    public class Game {

        private IO io; Prompts prompts;

        public Game(IO io, Prompts prompts) {
            this.io = io;
            this.prompts = prompts;
        }

        public void StartGame() {
            this.io.Print(this.prompts.Greeting());
        }

    }
}