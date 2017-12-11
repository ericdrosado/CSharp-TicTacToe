using System;

namespace TicTacToe {
    
    public class IO {

        public void Print(string printableItem) => Console.WriteLine(printableItem);

        public string GetInput() {
            return Console.ReadLine();
        } 

    }
}
