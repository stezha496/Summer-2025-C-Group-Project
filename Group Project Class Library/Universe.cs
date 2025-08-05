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
        Random random = new Random();

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

        public List<Human> getHumans() {
            
            return humans; 
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

        //dimensions array has all the dimensions, 
        //index 0 = 1d
        //index 1 = 2d
        //index 2 = 3d
        //index 3 = 4d
        //index 4 = 5d

        //4x2x3x5 would mean an array of 4x1, each element is an array of 2x1, each element of 2x1 is 3x1 and every element of 3x1 is a 5x1 array
        public void buildUniverse2(int[] dimensions) {
            int num_of_dimensions = dimensions.Length;

            if (num_of_dimensions == 1) {

                this.area = new Entity[dimensions[0], dimensions[1]];
            }

            if (num_of_dimensions == 2)
            {

                this.area = new Entity[dimensions[0], dimensions[1], dimensions[2]];
            }

            if (num_of_dimensions == 3)
            {

                this.area = new Entity[dimensions[0], dimensions[1], dimensions[2], dimensions[3]];
            }

            if (num_of_dimensions == 4)
            {

                this.area = new Entity[dimensions[0], dimensions[1], dimensions[2], dimensions[3], dimensions[4]];

            }
            
        }

        //to do: create occupations for humans
        public Human createRandomHuman() {
            int randomAge = random.Next(17, 80);

            int randomHealingFactor = random.Next(0, 6);
            HealingFactor hf = HealingFactor.NONE; //None by default (gives me a syntax error if I dont put it)
            if (randomHealingFactor == 0) hf = HealingFactor.NONE;
            else if (randomHealingFactor == 1) hf = HealingFactor.LV1;
            else if (randomHealingFactor == 2) hf = HealingFactor.LV2;
            else if (randomHealingFactor == 3) hf = HealingFactor.LV3;
            else if (randomHealingFactor == 4) hf = HealingFactor.LV4;
            else if (randomHealingFactor == 5) hf = HealingFactor.LV5;


            Human human = new Human(randomAge, null, hf);

            return human;
        }

        //I do not think we need createRandomZombie

    }
}
