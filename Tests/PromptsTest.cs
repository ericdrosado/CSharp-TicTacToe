using System;
using TicTacToe;
using Xunit;

namespace Tests.TicTacToe {

    public class Prompts_GreetingShould {

        private Prompts prompts;

        public Prompts_GreetingShould() {
            this.prompts = new Prompts();
        }

        [Fact]
        public void ReturnGreetingString() {
            var expectedGreeting = "+--------------------+\n" +
                                   "|Welcome to TicTacToe|\n" +
                                   "+--------------------+";
            var greeting = this.prompts.Greeting();

            Assert.Equal(expectedGreeting, greeting);
        }

    }

}
