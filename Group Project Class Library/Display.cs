using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_Class_Library
{
    //Console app
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

        public int num_of_dimensions() {
            Console.WriteLine("How many dimensions: ");
            int num_of_dimensions = Convert.ToInt32(Console.ReadLine());
            return num_of_dimensions;

        }



        public int[] arraySizes(int num_of_dimensions) {
            int[] dimensions = new int[num_of_dimensions];
            for (int i = 0; i < num_of_dimensions; i++) {
                Console.WriteLine("Enter size of dimension number {0}:",i+1);
                dimensions[i] = Convert.ToInt32(Console.ReadLine());
            }

            return dimensions;
        }
    }
}
