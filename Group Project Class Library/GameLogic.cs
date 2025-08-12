using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_Class_Library
{
    internal class GameLogic
    {
        Universe universe = new Universe();
        int maxIterations;
        int currentIteration = 0;
        int num_of_dimensions;
        int[] dimensions;
        int initialHumans;
        int initialZombies;


        //private Array area;
        private Array area;

        private Random rand = new Random();



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

            if (nonZombieFound == false || maxIterations == currentIteration) {
                return true; //end game
            }
            return false;
        }




        //public void traverse() {
        //    foreach (Entity e in area) { 

        //    }
        //}


        public Location createLocation(int[] entityDimensions) { 
            Location l = new Location();
            l.coordinates = entityDimensions;

            return l;
        }

        


        //Determines the starting position all entity, no overlap allowed
        //If the spot in the array is already taken (not null), runs the function again to find a different spot
        public void randomInitialPlace(Entity e) {
            int randomArrayDimension; //1d to 5d

            randomArrayDimension = rand.Next(num_of_dimensions);


            if (randomArrayDimension == 1) {
                int oneDimension = rand.Next(area.GetLength(0));
                if (area.GetValue(oneDimension) != null) randomInitialPlace(e);
                else
                {
                    area.SetValue(e, oneDimension);
                    int[] coordinates = { oneDimension };
                    e.Location = createLocation(coordinates);
                }
            }

            else if (randomArrayDimension == 2) {
                int oneDimension = rand.Next(area.GetLength(0));
                int twoDimension = rand.Next(area.GetLength(1));
                if (area.GetValue(oneDimension, twoDimension) != null) randomInitialPlace(e);
                else
                {
                    area.SetValue(e, oneDimension, twoDimension);
                    int[] coordinates = { oneDimension, twoDimension };
                    e.Location = createLocation(coordinates);
                }
            }

            else if (randomArrayDimension == 3) {
                int oneDimension = rand.Next(area.GetLength(0));
                int twoDimension = rand.Next(area.GetLength(1));
                int threeDimension = rand.Next(area.GetLength(2));
                if (area.GetValue(oneDimension, twoDimension, threeDimension) != null) randomInitialPlace(e);
                else
                {
                    area.SetValue(e, oneDimension, twoDimension, threeDimension);
                    int[] coordinates = { oneDimension, twoDimension, threeDimension };
                    e.Location = createLocation(coordinates);
                }
            }

            else if (randomArrayDimension == 4) {
                int oneDimension = rand.Next(area.GetLength(0));
                int twoDimension = rand.Next(area.GetLength(1));
                int threeDimension = rand.Next(area.GetLength(2));
                int fourDimension = rand.Next(area.GetLength(3));
                if (area.GetValue(oneDimension, twoDimension, threeDimension, fourDimension) != null) randomInitialPlace(e);
                else
                {
                    area.SetValue(e, oneDimension, twoDimension, threeDimension, fourDimension);
                    int[] coordinates = { oneDimension, twoDimension, threeDimension, fourDimension };
                    e.Location = createLocation(coordinates);
                }
            }

            else if (randomArrayDimension == 5) {
                int oneDimension = rand.Next(area.GetLength(0));
                int twoDimension = rand.Next(area.GetLength(1));
                int threeDimension = rand.Next(area.GetLength(2));
                int fourDimension = rand.Next(area.GetLength(3));
                int fiveDimension = rand.Next(area.GetLength(4));
                if (area.GetValue(oneDimension, twoDimension, threeDimension, fourDimension, fiveDimension) != null) randomInitialPlace(e);
                else
                {
                    area.SetValue(e, oneDimension, twoDimension, threeDimension, fourDimension, fiveDimension);
                    int[] coordinates = { oneDimension, twoDimension, threeDimension, fourDimension, fiveDimension };
                    e.Location = createLocation(coordinates);
                }
            }


        }






        //move one spot in the array that the entity is already in, or move one array up or down
        public void move(Entity e)
        {
            Array coordinates = e.Location.coordinates;
            int dimension = coordinates.Length;
            //either 0 or 1
            //if zero, move one space in the array that the entity is in
            //if one, move across the dimensions
            int moveDirection = rand.Next(2);


            if (moveDirection == 0) {
                if (dimension == 1) {
                    area.SetValue(null, (int)coordinates.GetValue(0));
                }
            }

            else if (moveDirection == 1) { }



        }
        public void start() {

            //for initial console app
            Display d = new Display();
            maxIterations = d.iterations();
            initialHumans = d.startingHumans();

            for (int i = 0; i < initialHumans; i++) {
                universe.addHuman(universe.createRandomHuman());
            }

            initialZombies = d.startingZombies();
            for (int i = 0; i < initialZombies; i++) {
                universe.addZombie(new Zombie());

            }



            num_of_dimensions = d.num_of_dimensions();
            universe.setNum_of_dimensions(num_of_dimensions);

            dimensions = d.arraySizes(num_of_dimensions);


            universe.buildUniverse2(dimensions);


            area = universe.getArea();

            //do randomInitialSpace in for loops above

            











            while (checkEndCondition() == false) { 
                //move method
                //increment iteraations
            }
        }


    }
}
