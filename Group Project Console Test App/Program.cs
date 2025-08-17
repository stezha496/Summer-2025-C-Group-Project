using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Group_Project_Class_Library;
namespace Group_Project_Console_Test_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameLogic g = new Group_Project_Class_Library.GameLogic();
            g.start();
            Boolean gameEnd = false;//default value
            while (gameEnd==false) {

                Console.WriteLine("Turn {0}", g.getIterations());
                if (g.getIterations() > 1)
                {
                    Console.WriteLine("Number of humans: {0}", g.getNumOfHumans());
                    Console.WriteLine("Number of zombies: {0}", g.getNumOfZombies());
                }
                Console.WriteLine("Enter m to move");
                string m = Console.ReadLine();
                if (m == "m") {
                    gameEnd = g.moveAllEntities();
                    
                }
                Console.WriteLine("_________________");
            }

            Console.WriteLine("Game ended after {0} iterations", g.getIterations());
            Console.WriteLine("Number of humans: {0}", g.getNumOfHumans());
            Console.WriteLine("Number of zombies: {0}", g.getNumOfZombies());
        }
    }
}
