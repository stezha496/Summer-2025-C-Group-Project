using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_Class_Library
{
    internal class GameLogic
    {
        Universe universe = new Universe();
        int maxIterations;
        int currentIteration = 0;



        //check end condition
        //Only 1 human (not converted) has to exist for the game to keep going
        public Boolean checkEndCondition() {
            Boolean nonZombieFound = false; //default value
            Boolean converted;
            foreach (Human human in universe.getHumans()) {
                converted = human.getConvertedToZombie();
                if (converted == false) {
                    nonZombieFound = true;
                }
            }

            if (nonZombieFound == false || maxIterations == currentIteration)
            {

                return true; //end game
            }

            return false;
      
        }

        //move - use random


        public void start() {

            //for initial console app
            Display d = new Display();
            maxIterations = d.iterations();
            int initialHumans = d.startingHumans();

            for (int i = 0; i < initialHumans; i++) {
                universe.addHuman(universe.createRandomHuman());
            }
            
            int initialZombies = d.startingZombies();
            for (int i = 0; i < initialZombies; i++) { 
                universe.addZombie(new Zombie());

            }
            while (checkEndCondition() == false) { 
                //move method
            }
        }


    }
}
