using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Group_Project_Class_Library
{
    //createInitialPlace() adds the entity to the area, then uses createLocation() to set the location and coordinates
    //when moving, use assignCoordinates
    
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
            Boolean nonInfectedHumanFound = false; //default value
            Boolean converted;
            foreach (Human human in universe.getHumans()) {
                converted = human.getConvertedToZombie();
                if (converted == false) {
                    nonInfectedHumanFound = true;
                }
            }

            if (nonInfectedHumanFound == false || maxIterations == currentIteration) {
                return true; //end game
            }
            return false; //keep the game going
        }




 



        //finds the entity, assigns value to coordinate based on its place in area
        //assumes location class in already assigned to the entity use createLocation
        public Entity assignCoordinates(Entity e) {
            List<Entity> entityList;
            int[] coordinates;
            if (num_of_dimensions == 1)
            {
                for (int i = 0; i < area.Length; i++) {
                    entityList = (List<Entity>)area.GetValue(i);

                    foreach (Entity entity in entityList) {
                        if (entity.getId() == e.getId())
                        {
                            coordinates = new int[1];
                            coordinates[0] = i;
                            e.Location.coordinates = coordinates;
                        }
                    }
                }
            }

            else if (num_of_dimensions == 2) {
                for (int i = 0; i < area.GetLength(0);i++) {
                    for (int j = 0; j < area.GetLength(1); j++) {
                        entityList = (List<Entity>)area.GetValue(i, j);
                        foreach (Entity entity in entityList)
                        {
                            if (entity.getId() == e.getId())
                            {
                                coordinates = new int[2];
                                coordinates[0] = i;
                                coordinates[1] = j;
                                e.Location.coordinates = coordinates;
                            }
                        }
                    }
                }
            }

            else if (num_of_dimensions == 3) {
                for (int i = 0; i < area.GetLength(0); i++)
                {
                    for (int j = 0; j < area.GetLength(1); j++)
                    {
                        for (int k = 0; k < area.GetLength(2); k++) {
                            entityList = (List<Entity>)area.GetValue(i, j, k);
                            foreach (Entity entity in entityList)
                            {
                                if (entity.getId() == e.getId())
                                {
                                    coordinates = new int[3];
                                    coordinates[0] = i;
                                    coordinates[1] = j;
                                    coordinates[2] = k;
                                    e.Location.coordinates = coordinates;
                                }
                            }
                        }
                    }
                }
            }

            else if (num_of_dimensions == 4) {
                for (int i = 0; i < area.GetLength(0); i++)
                {
                    for (int j = 0; j < area.GetLength(1); j++)
                    {
                        for (int k = 0; k < area.GetLength(2); k++)
                        {
                            for (int l = 0; l < area.GetLength(3); l++) {
                                entityList = (List<Entity>)area.GetValue(i, j, k, l);
                                foreach (Entity entity in entityList)
                                {
                                    if (entity.getId() == e.getId())
                                    {
                                        coordinates = new int[3];
                                        coordinates[0] = i;
                                        coordinates[1] = j;
                                        coordinates[2] = k;
                                        coordinates[3] = l;
                                        e.Location.coordinates = coordinates;

                                    }
                                }
                            }
                        }
                    }
                }
            }

            else if (num_of_dimensions == 5) {
                for (int i = 0; i < area.GetLength(0); i++)
                {
                    for (int j = 0; j < area.GetLength(1); j++)
                    {
                        for (int k = 0; k < area.GetLength(2); k++)
                        {
                            for (int l = 0; l < area.GetLength(3); l++)
                            {
                                for (int m = 0; m < area.Length; m++) {
                                    entityList = (List<Entity>)area.GetValue(i, j, k, l);
                                    foreach (Entity entity in entityList)
                                    {
                                        if (entity.getId() == e.getId())
                                        {
                                            coordinates = new int[3];
                                            coordinates[0] = i;
                                            coordinates[1] = j;
                                            coordinates[2] = k;
                                            coordinates[3] = l;
                                            coordinates[4] = m;
                                            e.Location.coordinates = coordinates;
                                        }
                                    }
                                }


                            }
                        }
                    }
                }
            }

            return e;
        }


        //initializing entities location
        public Location createLocation(int[] entityDimensions) { 
            Location l = new Location();
            l.coordinates = entityDimensions;

            return l;
        }

        


        //Determines the starting position all entity, no overlap allowed
        //If the spot in the array is already taken (not null), runs the function again to find a different spot
        public int randomInitialPlace(Entity e) {
            int randomArrayDimension; //1d to 5d

            randomArrayDimension = rand.Next(num_of_dimensions);
            List<Entity> entityList;

            if (randomArrayDimension == 1) {
                int oneDimension = rand.Next(area.GetLength(0));
                entityList = (List<Entity>)area.GetValue(oneDimension);

                if (entityList.Count != 0) {
                    randomInitialPlace(e);
                    return 1;//ends current call of this method
                }
                else
                {
                    entityList.Add(e);
                    int[] coordinates = { oneDimension };
                    e.Location = createLocation(coordinates);
                    area.SetValue(entityList, oneDimension);
                }
            }

            else if (randomArrayDimension == 2) {
                int oneDimension = rand.Next(area.GetLength(0));
                int twoDimension = rand.Next(area.GetLength(1));
                entityList = (List<Entity>)area.GetValue(oneDimension, twoDimension);
                if (entityList.Count != 0) {
                    randomInitialPlace(e);
                    return 1;
                }
                else
                {
                    entityList.Add(e);
                    int[] coordinates = { oneDimension, twoDimension };
                    e.Location = createLocation(coordinates);
                    area.SetValue(entityList, oneDimension, twoDimension);
                }
            }

            else if (randomArrayDimension == 3) {
                int oneDimension = rand.Next(area.GetLength(0));
                int twoDimension = rand.Next(area.GetLength(1));
                int threeDimension = rand.Next(area.GetLength(2));
                entityList = (List<Entity>)area.GetValue(oneDimension, twoDimension, threeDimension);

                if (entityList.Count != 0) {
                    randomInitialPlace(e);
                    return 1;
                }
                else
                {
                    entityList.Add(e);
                    int[] coordinates = { oneDimension, twoDimension, threeDimension };
                    e.Location = createLocation(coordinates);
                    area.SetValue(entityList, oneDimension, twoDimension, threeDimension);
                }
            }

            else if (randomArrayDimension == 4) {
                int oneDimension = rand.Next(area.GetLength(0));
                int twoDimension = rand.Next(area.GetLength(1));
                int threeDimension = rand.Next(area.GetLength(2));
                int fourDimension = rand.Next(area.GetLength(3));

                entityList = (List<Entity>)area.GetValue(oneDimension, twoDimension, threeDimension, fourDimension);
                if (entityList.Count != 0) {
                    randomInitialPlace(e);
                    return 1;
                }
                else
                {
                    entityList.Add(e);
                    int[] coordinates = { oneDimension, twoDimension, threeDimension, fourDimension };
                    e.Location = createLocation(coordinates);
                    area.SetValue(entityList, oneDimension, twoDimension, threeDimension, fourDimension);
                }
            }

            else if (randomArrayDimension == 5) {
                int oneDimension = rand.Next(area.GetLength(0));
                int twoDimension = rand.Next(area.GetLength(1));
                int threeDimension = rand.Next(area.GetLength(2));
                int fourDimension = rand.Next(area.GetLength(3));
                int fiveDimension = rand.Next(area.GetLength(4));

                entityList = (List<Entity>)area.GetValue(oneDimension, twoDimension, threeDimension, fourDimension, fiveDimension);
                if (entityList.Count != 0) {
                    randomInitialPlace(e);
                    return 1;
                }
            else
            {
                    entityList.Add(e);
                    int[] coordinates = { oneDimension, twoDimension, threeDimension, fourDimension, fiveDimension };
                    e.Location = createLocation(coordinates);
                    area.SetValue(entityList, oneDimension, twoDimension, threeDimension, fourDimension, fiveDimension);
                }
            }
            return 0;


        }

        //Adds entity to area based on their coordinate
        public void coordinateToArea(Entity e, int dimension) {
            List<Entity> entityList;
            if (dimension == 1)
            {
                //adding this because I dont think GetLength works on 1d arrays
                int length = 0;
                if (num_of_dimensions > 1) length = area.GetLength(0);
                if (num_of_dimensions == 1) length = area.Length;

                for (int i = 0; i < length; i++)
                {
                    if (i == e.Location.coordinates[0])
                    {
                        entityList = (List<Entity>)area.GetValue(i);
                        entityList.Add(e);
                        area.SetValue(entityList, i);
                    }
                }
            }

            else if (dimension == 2)
            {
                for (int i = 0; i < area.GetLength(0); i++)
                {
                    for (int j = 0; j < area.GetLength(1); j++)
                    {
                        if (i == e.Location.coordinates[0] && j == e.Location.coordinates[1])
                        {
                            entityList = (List<Entity>)area.GetValue(i, j);
                            entityList.Add(e);
                            area.SetValue(entityList, i, j);
                        }
                    }
                }
            }

            else if (dimension == 3)
            {
                for (int i = 0; i < area.GetLength(0); i++)
                {
                    for (int j = 0; j < area.GetLength(1); j++)
                    {
                        for (int k = 0; k < area.GetLength(2); k++)
                        {
                            if (i == e.Location.coordinates[0] && j == e.Location.coordinates[1] && k == e.Location.coordinates[2])
                            {
                                entityList = (List<Entity>)area.GetValue(i, j, k);
                                entityList.Add(e);
                                area.SetValue(entityList, i, j, k);
                            }
                        }
                    }
                }
            }

            else if (dimension == 4)
            {
                for (int i = 0; i < area.GetLength(0); i++)
                {
                    for (int j = 0; j < area.GetLength(1); j++)
                    {
                        for (int k = 0; k < area.GetLength(2); k++)
                        {
                            for (int l = 0; l < area.GetLength(3); l++)
                            {
                                if (i == e.Location.coordinates[0] && j == e.Location.coordinates[1] && k == e.Location.coordinates[2] && l == e.Location.coordinates[3])
                                {
                                    entityList = (List<Entity>)area.GetValue(i, j, k, l);
                                    entityList.Add(e);
                                    area.SetValue(entityList, i, j, k, l);
                                }
                            }
                        }
                    }
                }
            }

            else if (dimension == 5)
            {
                for (int i = 0; i < area.GetLength(0); i++)
                {
                    for (int j = 0; j < area.GetLength(1); j++)
                    {
                        for (int k = 0; k < area.GetLength(2); k++)
                        {
                            for (int l = 0; l < area.GetLength(3); l++)
                            {
                                for (int m = 0; m < area.GetLength(3); m++)
                                {
                                    if (i == e.Location.coordinates[0] && j == e.Location.coordinates[1] && k == e.Location.coordinates[2] && l == e.Location.coordinates[3] && m == e.Location.coordinates[4])
                                    {
                                        entityList = (List<Entity>)area.GetValue(i, j, k, l, m);
                                        entityList.Add(e);
                                        area.SetValue(entityList, i, j, k, l, m);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        //Determines which direction to move iniside an array
        //Prevent index out of bounds
        // dimension refers to the dimension that the entity (e) is currently in, not to be confused with num_of_dimensions
        public Entity moveInArray(Entity e, int dimension) {
            //lines up array length with the appropriate index.   
            dimension--;

            //if the entity is at index zero, it can only move up one index
            if (e.Location.coordinates[dimension] == 0) 
            {
                e.Location.coordinates[dimension]++;
            }

            //if the entity is at the end of the index, it can only move down one index
            else if (e.Location.coordinates[dimension] == e.Location.coordinates.GetLength(dimension))
            {
                e.Location.coordinates[dimension]--;
            }

            //can go up or down one index
            else {
                //if 1, go up one index
                //if 0, go down one index
                int up = rand.Next(2);
                if (up == 1) {
                    e.Location.coordinates[dimension]++;
                }
                else {
                    e.Location.coordinates[dimension]--;
                }
            }

            //remove entity from current spot in the area
            // assign it to the spot in the area based on coordinate

            //correcting the dimensions now that we are not using it as an index anymore
            dimension++;
            foreach (List<Entity> list in area) {
                foreach (Entity entity in list) {
                    if (e.getId() == entity.getId()) { 
                        list.Remove(entity);
                    }
                }
            }

            coordinateToArea(e, dimension);


            return e;
        }



        //used when moving, use id from entity
        //traverse
        public void setIndexToNull(int id) {
            foreach (List<Entity> list in area) {
                foreach (Entity e in list) {
                    if (e.getId() == id)
                    {
                        if (e.Location.coordinates.Length == 1)
                        {
                            area.SetValue(null, e.Location.coordinates[0]);
                        }
                    }
                }
            }
        }


        //[5, 2, 6, 2] would become [5, 2, 6], no random needed
        public int[] goDownOneDimension(Entity e, int dimension) {
            int[] entityDimensions = new int[dimension - 1];  //one less number since we are going down a dimension
            for (int i = 0; i < dimension - 1; i++)
            {
                entityDimensions[i] = e.Location.coordinates[i];
            }
            return entityDimensions;
        }


        public int[] goUpOneDimension(Entity e, int dimension)
        {
            int[] entityDimensions = new int[++dimension];  //one more number since we are going down a dimension
            for (int i = 0; i < e.Location.coordinates.Length - 1; i++)
            {
                entityDimensions[i] = e.Location.coordinates[i];
            }
            

            //The last element of entityDimension will be a random number that is in the bounds of the respective array in area
            if (dimension == 2) {
                entityDimensions[entityDimensions.Length - 1] = rand.Next(area.GetLength(1));
            }

            else if (dimension == 3)
            {
                entityDimensions[entityDimensions.Length - 1] = rand.Next(area.GetLength(2));
            }

            else if (dimension == 4)
            {
                entityDimensions[entityDimensions.Length - 1] = rand.Next(area.GetLength(3));
            }

            else if (dimension == 5)
            {
                entityDimensions[entityDimensions.Length - 1] = rand.Next(area.GetLength(4));
            }
            return entityDimensions;
        }



        //jumping from one dimension to the other
        // if going down a dimension, an entity can go to any spot in that arry (random)
        //if going up an array, keep the same index for the array that the entity is going to, create new coordinates without the lower array
        //only possible if the user selects above 1d for the game area
        public Entity moveAcrossArrays(Entity e, int dimension) {
            foreach (List<Entity> list in area)
            {
                foreach (Entity entity in list)
                {
                    if (entity.getId() == e.getId())
                    {
                        list.Remove(entity);
                    }
                }
            }

            int[] entityDimensions;

            //Can only go up one dimension
            if (dimension == 1 && num_of_dimensions > 1)
            {
                entityDimensions = new int[2];
                entityDimensions[0] = e.Location.coordinates[0];
                entityDimensions[1] = rand.Next(area.GetLength(1));
                e.Location.coordinates = entityDimensions;
                dimension = 2;

            }

            //can only go down one
            else if (dimension == num_of_dimensions && dimension > 1)
            {
                entityDimensions = goDownOneDimension(e, dimension);
                dimension--;
                e.Location.coordinates = entityDimensions;
            }

            //up or down
            else {
                // 0 - go down
                // 1 - go up
                int direction = rand.Next(2);

                if (direction == 0) {
                    entityDimensions = goDownOneDimension(e, dimension);
                    dimension--;
                    e.Location.coordinates = entityDimensions;
                }

                else if (direction == 1)
                {
                    entityDimensions = goUpOneDimension(e, dimension);
                    dimension++;
                    e.Location.coordinates = entityDimensions;

                }
            }

            coordinateToArea(e, dimension);
            return e;
        }



        //move one spot in the array that the entity is already in, or move one array up or down
        public void move(Entity e)
        {
            Array coordinates = e.Location.coordinates;
            int dimension = coordinates.Length; //finds which dimension the entity is in.  [4, 2 , 1] would be the third dimension

            //either 0 or 1
            //if zero, move one space in the array that the entity is in
            //if one, move across the dimensions
            int moveDirection = rand.Next(2);


            if (moveDirection == 0) {
                e = moveInArray(e, dimension);
            }

            //moveAcrossArrays()
            else if (moveDirection == 1) { 
                e = moveAcrossArrays(e, dimension);
            }



        }
        public void start() {

            //for initial console app
            Display d = new Display();
            maxIterations = d.iterations();
            initialHumans = d.startingHumans();



            num_of_dimensions = d.num_of_dimensions();
            universe.setNum_of_dimensions(num_of_dimensions);

            dimensions = d.arraySizes(num_of_dimensions);


            universe.buildUniverse2(dimensions);


            area = universe.getArea();

            //for these two loops, create then appropriate amount of entities, add them to humans/zombies array, then add them randomly in the area
            for (int i = 0; i < initialHumans; i++)
            {
                Human h = universe.createRandomHuman();
                universe.addHuman(h);
                randomInitialPlace(h);
            }

            initialZombies = d.startingZombies();
            for (int i = 0; i < initialZombies; i++)
            {
                Zombie z = new Zombie();
                universe.addZombie(z);
                randomInitialPlace(z);

            }





            while (checkEndCondition() == false) { 
                //move method
                //increment iteraations
            }
        }


    }
}
