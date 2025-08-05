using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_Class_Library
{
    internal class Display
    {

        public int iterations() {
            Console.WriteLine("Enter the max number of iterations: ");
            int maxIterations = Convert.ToInt32(Console.ReadLine());
            return maxIterations;
            
        }

        public int startingHumans() {
            Console.WriteLine("Enter the initial number of humans: ");
            int initialHumans = Convert.ToInt32(Console.ReadLine());
            return initialHumans;
        }

        public int startingZombies()
        {
            Console.WriteLine("Enter the initial number of zombies: ");
            int initialZombies = Convert.ToInt32(Console.ReadLine());
            return initialZombies;
        }
    }
}
