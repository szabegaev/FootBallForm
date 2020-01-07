using Domain;
using System;
using System.Collections.Generic;

namespace football
{
    class Program
    {       

        static void Main(string[] args)
        {
            Console.WriteLine("Start Game!");

            Game game = new Game(); 

            Console.WriteLine($"колличество голов = {game.KollGoal()}");
        }

        
    }
}
