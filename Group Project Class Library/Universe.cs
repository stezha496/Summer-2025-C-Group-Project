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

        private List<Human> humans = new List<Human>(); // Fixed: Initialize the lists
        private List<Zombie> zombies = new List<Zombie>(); // Fixed: Initialize the lists

        private Array area;
        private int num_of_iterations { get; set; }
        private int num_of_dimensions { get; set; }

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

        public List<Human> getHumans()
        {
            return humans;
        }

        public List<Zombie> getZombies() { return zombies; }

        public int getNum_of_dimensions() { return num_of_dimensions; }
        public void setNum_of_dimensions(int num) { this.num_of_dimensions = num; }

        // Fixed buildUniverse2 - now properly initializes all List<Entity> positions
        public void buildUniverse2(int[] dimensions)
        {
            num_of_dimensions = dimensions.Length;

            if (num_of_dimensions == 1)
            {
                this.area = new List<Entity>[dimensions[0]];

                // Initialize all positions with empty lists
                for (int i = 0; i < dimensions[0]; i++)
                {
                    area.SetValue(new List<Entity>(), i);
                }
            }
            else if (num_of_dimensions == 2)
            {
                this.area = new List<Entity>[dimensions[0], dimensions[1]];

                // Initialize all positions with empty lists
                for (int i = 0; i < dimensions[0]; i++)
                {
                    for (int j = 0; j < dimensions[1]; j++)
                    {
                        area.SetValue(new List<Entity>(), i, j);
                    }
                }
            }
            else if (num_of_dimensions == 3)
            {
                this.area = new List<Entity>[dimensions[0], dimensions[1], dimensions[2]];

                // Initialize all positions with empty lists
                for (int i = 0; i < dimensions[0]; i++)
                {
                    for (int j = 0; j < dimensions[1]; j++)
                    {
                        for (int k = 0; k < dimensions[2]; k++)
                        {
                            area.SetValue(new List<Entity>(), i, j, k);
                        }
                    }
                }
            }
            else if (num_of_dimensions == 4)
            {
                this.area = new List<Entity>[dimensions[0], dimensions[1], dimensions[2], dimensions[3]];

                // Initialize all positions with empty lists
                for (int i = 0; i < dimensions[0]; i++)
                {
                    for (int j = 0; j < dimensions[1]; j++)
                    {
                        for (int k = 0; k < dimensions[2]; k++)
                        {
                            for (int l = 0; l < dimensions[3]; l++)
                            {
                                area.SetValue(new List<Entity>(), i, j, k, l);
                            }
                        }
                    }
                }
            }
            else if (num_of_dimensions == 5)
            {
                this.area = new List<Entity>[dimensions[0], dimensions[1], dimensions[2], dimensions[3], dimensions[4]];

                // Initialize all positions with empty lists
                for (int i = 0; i < dimensions[0]; i++)
                {
                    for (int j = 0; j < dimensions[1]; j++)
                    {
                        for (int k = 0; k < dimensions[2]; k++)
                        {
                            for (int l = 0; l < dimensions[3]; l++)
                            {
                                for (int m = 0; m < dimensions[4]; m++)
                                {
                                    area.SetValue(new List<Entity>(), i, j, k, l, m);
                                }
                            }
                        }
                    }
                }
            }
        }

        public Array getArea()
        {
            return area;
        }

        public Human createRandomHuman()
        {
            int randomAge = random.Next(17, 80);

            int randomHealingFactor = random.Next(0, 6);
            HealingFactor hf = HealingFactor.NONE; // None by default
            if (randomHealingFactor == 0) hf = HealingFactor.NONE;
            else if (randomHealingFactor == 1) hf = HealingFactor.LV1;
            else if (randomHealingFactor == 2) hf = HealingFactor.LV2;
            else if (randomHealingFactor == 3) hf = HealingFactor.LV3;
            else if (randomHealingFactor == 4) hf = HealingFactor.LV4;
            else if (randomHealingFactor == 5) hf = HealingFactor.LV5;

            Human human = new Human(randomAge, null, hf);
            return human;
        }

        // I do not think we need createRandomZombie
    }
}