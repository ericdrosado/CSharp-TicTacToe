using System;
using TicTacToe;
using Xunit;

namespace Tests.TicTacToe {

    public class Prompts_GreetingShould {

        public Prompts _prompts;

        public Prompts_GreetingShould() {
            _prompts = new Prompts();
        }

        [Fact]
        public void ReturnGreetingString() {
            var expectedGreeting = "+--------------------+\n" +
                                   "|Welcome to TicTacToe|\n" +
                                   "+--------------------+";
            var greeting = _prompts.Greeting();

            Assert.Equal(expectedGreeting, greeting);
        }

    }

}
