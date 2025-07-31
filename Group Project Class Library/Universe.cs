using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;

namespace Group_Project_Class_Library
{
    internal class Universe
    {
        private List<Human> humans { get; }
        private List<Zombie> zombies { get; }
        private Array area;
        private int numIterations { get; set; }
        private int numDimensions { get; set; }

        // Might need a function to find a human or a zombie. Returns the coordinates.
        // What is iterations?

        public void addHuman(Human human)
        {
            this.humans.Add(human);
        }

        public void removeHuman(Human human)
        {
            this.humans.Remove(human);
        }

        public void addZombie(Zombie zombie)
        {
            this.zombies.Add(zombie);
        }

        public void removeZombie(Zombie zombie)
        {
            this.zombies.Remove(zombie);
        }

        // For size, I am assuming length and height will always be the same: x by x. Ex: 2x2, 4x4, 5x5x5x5, etc.
        public void buildUniverse(int dimensions, int size)
        {
            // Manual: since it is up to 5, just do 5 checks
            // Automated: ???

            switch (dimensions)
            {
                case 1:
                    this.area = new Entity[size];
                    break;
                case 2:
                    this.area = new Entity[size, size];
                    break;
                case 3:
                    this.area = new Entity[size, size, size];
                    break;
                case 4:
                    this.area = new Entity[size, size, size, size];
                    break;
                case 5:
                    this.area = new Entity[size, size, size, size, size];
                    break;
            }
        }
    }
}
