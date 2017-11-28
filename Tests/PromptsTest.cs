using System;
using TicTacToe;
using Xunit;

namespace Tests.TicTacToe {

    public class PromptsTest {

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
                var greetingString = _prompts.Greeting();

                Assert.Equal(expectedGreeting, greetingString);
            }

        }
    }
}
