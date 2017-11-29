using System;

namespace TicTacToe {
    
    public class UI {

        private IO io;

        public UI(IO io) {
            this.io = io;
        }

        public void NewGameView() {
            this.io.Print(Greeting());
            this.io.Print(Instructions());
        }

        public string Greeting() {
            return 
            "+-------------------------------------------------------+\n" +
            "|                  Welcome to TicTacToe                 |\n" +
            "+-------------------------------------------------------+";
        }

        public string Instructions() {
            return
            "+-------------------------------------------------------+\n" +
            "|The object of TicTacToe is to get three of your markers|\n" +
            "|in a row before your opponent can. If all the spaces   |\n" +
            "|are occupied with no winner, the game is a draw.       |\n" +
            "+-------------------------------------------------------+\n";
        }

    }
}
