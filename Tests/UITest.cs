using System;
using TicTacToe;
using Xunit;

namespace Tests.TicTacToe {

    public class UITest {

        public UI _ui;

        public UITest() {
            IO io = new IO();
            _ui = new UI(io);
        }

        [Fact]
        public void ReturnGreeting() {
            var expectedGreeting = "+-------------------------------------------------------+\n" +
                                   "|                  Welcome to TicTacToe                 |\n" +
                                   "+-------------------------------------------------------+";
            var greeting = _ui.Greeting();

            Assert.Equal(expectedGreeting, greeting);
        }

        [Fact]
        public void ReturnInstructions()
        {
            var expectedInstructions = "+-------------------------------------------------------+\n" +
                                       "|The object of TicTacToe is to get three of your markers|\n" +
                                       "|in a row before your opponent can. If all the spaces   |\n" +
                                       "|are occupied with no winner, the game is a draw.       |\n" +
                                       "+-------------------------------------------------------+\n";
            var instructions = _ui.Instructions();

            Assert.Equal(expectedInstructions, instructions);
        }
    }
}
