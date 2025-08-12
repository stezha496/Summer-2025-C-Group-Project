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
        private int num_of_iterations { get; set; }
        private int num_of_dimensions { get; set; }

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

        public int getNum_of_dimensions() { return num_of_dimensions; }
        public void setNum_of_dimensions(int num) { this.num_of_dimensions = num; }


        

        //dimensions array has all the dimensions, 
        //index 0 = 1d
        //index 1 = 2d
        //index 2 = 3d
        //index 3 = 4d
        //index 4 = 5d

        //4x2x3x5 would mean an array of 4x1, each element is an array of 2x1, each element of 2x1 is 3x1 and every element of 3x1 is a 5x1 array

        //Had to make an array for each dimension
        //Only creates one area for the num of dimensions we are working with
        public void buildUniverse2(int[] dimensions) {
            num_of_dimensions = dimensions.Length;

            if (num_of_dimensions == 1) {

                this.area = new Entity[dimensions[0]];
            }

            else if (num_of_dimensions == 2)
            {

                this.area = new Entity[dimensions[0], dimensions[1]];
                
            }

            else if (num_of_dimensions == 3)
            {

                this.area = new Entity[dimensions[0], dimensions[1], dimensions[2]];
            }

            else if (num_of_dimensions == 4)
            {

                this.area = new Entity[dimensions[0], dimensions[1], dimensions[2], dimensions[3]];
                
            }
            else if (num_of_dimensions == 5)
            {

                this.area = new Entity[dimensions[0], dimensions[1], dimensions[2], dimensions[3], dimensions[4]];

            }

        }



        public Array getArea() {
            return area;
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
