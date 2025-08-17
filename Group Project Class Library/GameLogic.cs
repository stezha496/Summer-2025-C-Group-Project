using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Group_Project_Class_Library
{
    //createInitialPlace() adds the entity to the area, then uses createLocation() to set the location and coordinates
    //when moving, use assignCoordinates
    
    public class GameLogic
    {
        public GameLogic() { }
        Universe universe = new Universe();
        int maxIterations;
        int currentIteration = 0;
        int num_of_dimensions;
        int[] dimensions;
        int initialHumans;
        int initialZombies;

        Human[] humans;
        Zombie[] zombies;
        public int getIterations() { return currentIteration; }

        //non zombies only
        public int getNumOfHumans() {
            int num = 0;

            foreach (Human h in humans) {
                if (h.getConvertedToZombie() == false) num++;
            }
            return num;
        }


        public int getNumOfZombies() {
            int num = 0;

            foreach (Human h in humans)
            {
                if (h.getConvertedToZombie() == true) num++;
            }

            foreach (Zombie z in zombies)
            {
                num++;
            }
            return num;
        }
        //private Array area;
        private Array area;

        private Random rand = new Random();



        //check end condition
        //Only 1 human (not converted) has to exist for the game to keep going
        public Boolean checkEndCondition() {
            Boolean nonInfectedHumanFound = false; //default value
            Boolean converted;
            foreach (Human human in humans) {
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
        public Entity assignCoordinates(Entity e)
        {
            List<Entity> entityList;
            int[] coordinates;
            if (num_of_dimensions == 1)
            {
                for (int i = 0; i < area.Length; i++)
                {
                    entityList = (List<Entity>)area.GetValue(i);

                    foreach (Entity entity in entityList)
                    {
                        if (entity.getId() == e.getId())
                        {
                            coordinates = new int[1];
                            coordinates[0] = i;
                            e.Location.coordinates = coordinates;
                        }
                    }
                }
            }

            else if (num_of_dimensions == 2)
            {
                for (int i = 0; i < area.GetLength(0); i++)
                {
                    for (int j = 0; j < area.GetLength(1); j++)
                    {
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
                    }}
            }

            else if (num_of_dimensions == 3)
            {
                for (int i = 0; i < area.GetLength(0); i++)
                {
                    for (int j = 0; j < area.GetLength(1); j++)
                    {
                        for (int k = 0; k < area.GetLength(2); k++)
                        {
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
                        }}}
            }

            else if (num_of_dimensions == 4)
            {
                for (int i = 0; i < area.GetLength(0); i++)
                {
                    for (int j = 0; j < area.GetLength(1); j++)
                    {
                        for (int k = 0; k < area.GetLength(2); k++)
                        {
                            for (int l = 0; l < area.GetLength(3); l++)
                            {
                                entityList = (List<Entity>)area.GetValue(i, j, k, l);
                                foreach (Entity entity in entityList)
                                {
                                    if (entity.getId() == e.getId())
                                    {
                                        coordinates = new int[4];
                                        coordinates[0] = i;
                                        coordinates[1] = j;
                                        coordinates[2] = k;
                                        coordinates[3] = l;
                                        e.Location.coordinates = coordinates;

                                    }
                                }
                            }}}}
            }

            else if (num_of_dimensions == 5)
            {
                for (int i = 0; i < area.GetLength(0); i++)
                {
                    for (int j = 0; j < area.GetLength(1); j++)
                    {
                        for (int k = 0; k < area.GetLength(2); k++)
                        {
                            for (int l = 0; l < area.GetLength(3); l++)
                            {
                                for (int m = 0; m < area.GetLength(4); m++)
                                {
                                    entityList = (List<Entity>)area.GetValue(i, j, k, l, m);
                                    foreach (Entity entity in entityList)
                                    {
                                        if (entity.getId() == e.getId())
                                        {
                                            coordinates = new int[5];
                                            coordinates[0] = i;
                                            coordinates[1] = j;
                                            coordinates[2] = k;
                                            coordinates[3] = l;
                                            coordinates[4] = m;
                                            e.Location.coordinates = coordinates;
                                        }
                                    }
                                }}}}}
            }
            return e;
        }

        //initializing entities location
        public Location createLocation(int[] entityDimensions) { 
            Location l = new Location();
            l.coordinates = entityDimensions;

            return l;
        }

        //only call if the list<entity> has more than one entity to avoid unnecessary calls
        public List<Entity> convertToZombie(List<Entity> list) {
            Boolean hasZombie = false;
            List<Entity> zombiesInList = new List<Entity>();
            //check if theres a zombie
            for (int i = 0; i< list.Count;i++) {
                if (list[i] is Zombie) {
                    zombiesInList.Add((Zombie)list[i]);
                    hasZombie = true;
                }

                if (list[i] is Human)
                {
                    Human h = (Human)list[i];
                    if (h.getConvertedToZombie() == true) {
                        zombiesInList.Add(h);
                        hasZombie = true;
                    }
                }
            }

            //If there is a human and zombie/infected human in the same spot(represented as a list)
            //and that human has not been converted to a zombie, chance of converting that human  to a zombie
            for (int i = 0; i < list.Count; i++) {
                if (list[i] is Human) { 
                    Human h = (Human)list[i];
                    if (h.getConvertedToZombie() ==false && hasZombie==true) {
                        int randChance;
                        h.SetEncounteredZombie(true);
                        if (h.getHealingFactor() == HealingFactor.NONE)
                        {
                            h.SetConvertedToZombie(true);
                        }

                        else {
                            int num = 0;
                            if (h.getHealingFactor() == HealingFactor.LV1) num = 2; //50% chance to turn to zombie
                            if (h.getHealingFactor() == HealingFactor.LV2) num = 3; //33% chance to turn to zombie
                            if (h.getHealingFactor() == HealingFactor.LV3) num = 4; //25% chance to turn to zombie
                            if (h.getHealingFactor() == HealingFactor.LV4) num = 5; //20% chance to turn to zombie
                            if (h.getHealingFactor() == HealingFactor.LV5) num = 6;
                            randChance = rand.Next(num); 
                            if (randChance == 0) {
                                h.SetConvertedToZombie(true);
                                int randZombie = rand.Next(zombiesInList.Count);
                                list.Remove(zombiesInList[randZombie]);

                                h.setInfectedBy(zombiesInList[randZombie]);
                                zombiesInList[randZombie].addHumanInfected(h);
                                zombiesInList[randZombie].IncrementHumansConverted();
                                list.Add(zombiesInList[randZombie]);
                            }
                        }

                        list[i] = h;
                    }
                }
            }
            return list;
        }


        //used when moving, use id from entity
        public void removeHumanFromArea(int id)
        {
            List<Entity> entityList= new List<Entity>();//default value
            if (num_of_dimensions == 1)
            {
                for (int i = 0; i < area.Length; i++)
                {
                    entityList = (List<Entity>)area.GetValue(i);
                    for (int indx = 0; indx < entityList.Count; indx++) {
                        if (entityList[indx].getId() == id)
                        {
                            entityList.Remove(entityList[indx]);
                            area.SetValue(entityList, i);
                        }
                    }}
            }

            else if (num_of_dimensions == 2)
            {
                for (int i = 0; i < area.GetLength(0); i++)
                {
                    for (int j = 0; j < area.GetLength(1); j++)
                    {
                        entityList = (List<Entity>)area.GetValue(i, j);
                        for (int indx = 0; indx < entityList.Count; indx++)
                        {
                            if (entityList[indx].getId() == id)
                            {
                                entityList.Remove(entityList[indx]);
                                area.SetValue(entityList, i, j);
                            }
                        }}}
            }

            else if (num_of_dimensions == 3)
            {
                for (int i = 0; i < area.GetLength(0); i++)
                {
                    for (int j = 0; j < area.GetLength(1); j++)
                    {
                        for (int k = 0; k < area.GetLength(2); k++)
                        {
                            entityList = (List<Entity>)area.GetValue(i, j, k);
                            for (int indx = 0; indx < entityList.Count; indx++)
                            {
                                if (entityList[indx].getId() == id)
                                {
                                    entityList.Remove(entityList[indx]);
                                    area.SetValue(entityList, i, j, k);
                                }
                            }}}}
            }

            else if (num_of_dimensions == 4)
            {
                for (int i = 0; i < area.GetLength(0); i++)
                {
                    for (int j = 0; j < area.GetLength(1); j++)
                    {
                        for (int k = 0; k < area.GetLength(2); k++)
                        {
                            for (int l = 0; l < area.GetLength(3); l++)
                            {
                                entityList = (List<Entity>)area.GetValue(i, j, k, l);
                                for (int indx = 0; indx < entityList.Count; indx++)
                                {
                                    if (entityList[indx].getId() == id)
                                    {
                                        entityList.Remove(entityList[indx]);
                                        area.SetValue(entityList, i, j, k ,l);
                                    }
                                }}}}}
            }

            else if (num_of_dimensions == 5)
            {
                for (int i = 0; i < area.GetLength(0); i++)
                {
                    for (int j = 0; j < area.GetLength(1); j++)
                    {
                        for (int k = 0; k < area.GetLength(2); k++)
                        {
                            for (int l = 0; l < area.GetLength(3); l++)
                            {
                                for (int m = 0; m < area.GetLength(4); m++)
                                {
                                    entityList = (List<Entity>)area.GetValue(i, j, k, l, m);
                                    for (int indx = 0; indx < entityList.Count; indx++)
                                    {
                                        if (entityList[indx].getId() == id)
                                        {
                                            entityList.Remove(entityList[indx]);
                                            area.SetValue(entityList, i, j, k, l, m);
                                        }
                                    }}}}}}
            }
        }

        public void move(Entity e)
        {
            removeHumanFromArea(e.getId());

            // 1 = hop arrays, 0= move in the same array
            int direction = rand.Next(2);

            // 1 = index+1, 0= index-1
            int indexUpOrDown = rand.Next(2);

            // 1D array can only move in its index
            if (num_of_dimensions == 1)
            {
                // If it's at the max index it has to go down
                if (e.Location.coordinates[0] == area.Length - 1)
                {
                    e.Location.coordinates[0]--;
                }
                // If it's at the lowest index it can only go up
                else if (e.Location.coordinates[0] == 0)
                {
                    e.Location.coordinates[0]++;
                }
                // Can go up or down an index
                else
                {
                    if (indexUpOrDown == 0) e.Location.coordinates[0]--;
                    else e.Location.coordinates[0]++;
                }
            }

            //When num_of_dimensions is >1
            else
            {
                // going up/down an array (justmodify second last coordinate)
                if (direction == 1)
                {
                    int targetDimension = num_of_dimensions - 2; // second last coordinate

                    if (indexUpOrDown == 1)
                    {
                        // increment second last coordinate
                        e.Location.coordinates[targetDimension]++;

                        // handle wrapping if it exceeds max index
                        if (e.Location.coordinates[targetDimension] >= area.GetLength(targetDimension))
                        {
                            e.Location.coordinates[targetDimension] = 0; // wrap to 0

                            // go to previous dimensions if needed
                            for (int i = targetDimension - 1; i >= 0; i--)
                            {
                                e.Location.coordinates[i]++;
                                if (e.Location.coordinates[i] < area.GetLength(i))
                                {
                                    break; // no more cascading needed
                                }
                                e.Location.coordinates[i] = 0; // wrap this dimension too
                            }
                        }
                    }
                    else
                    {
                        // decrement secondlast coordinate
                        e.Location.coordinates[targetDimension]--;

                        //handle wrapping if it goes below 0
                        if (e.Location.coordinates[targetDimension] < 0)
                        {
                            e.Location.coordinates[targetDimension] = area.GetLength(targetDimension) - 1; // wrap to max

                            //go to previous dimensions if needed
                            for (int i = targetDimension - 1; i >= 0; i--)
                            {
                                e.Location.coordinates[i]--;
                                if (e.Location.coordinates[i] >= 0)
                                {
                                    break; // no more cascading needed
                                }
                                e.Location.coordinates[i] = area.GetLength(i) - 1; // wrap this dimension too
                            }
                        }
                    }
                }
                else
                {
                    //Move within same array (justmodify last coordinate only)
                    int lastDimension = num_of_dimensions - 1;

                    // Can only go up an index if the last coordinate is zero
                    if (e.Location.coordinates[lastDimension] == 0)
                    {
                        e.Location.coordinates[lastDimension]++;
                    }
                    // Can only go down an index if it is already at the highest index
                    else if (e.Location.coordinates[lastDimension] == area.GetLength(lastDimension) - 1)
                    {
                        e.Location.coordinates[lastDimension]--;
                    }
                    // Can move one index up or down
                    else
                    {
                        if (indexUpOrDown == 1)
                            e.Location.coordinates[lastDimension]++;
                        else
                            e.Location.coordinates[lastDimension]--;
                    }
                }
            }

            List<Entity> list = (List<Entity>)area.GetValue(e.Location.coordinates);
            list.Add(e);
            area.SetValue(list, e.Location.coordinates);


        }



        public int randomInitialPlace(Entity e)
        {
            if (num_of_dimensions == 1)
            {
                int oneDimension = rand.Next(area.Length);
                List<Entity> list = (List<Entity>)area.GetValue(oneDimension);

                if (list.Count > 0)
                {
                    randomInitialPlace(e);
                    return 0;
                }
                else
                {
                    list.Add(e);
                    area.SetValue(list, oneDimension);
                    int[] coordinates = { oneDimension };
                    e.Location = createLocation(coordinates);
                }
            }
            else {
                int[] indexes = new int[num_of_dimensions];
                if (num_of_dimensions > 1) indexes[0] = rand.Next(area.GetLength(0));
                if (num_of_dimensions >= 2) indexes[1] = rand.Next(area.GetLength(1));
                if (num_of_dimensions >= 3) indexes[2] = rand.Next(area.GetLength(2));
                if (num_of_dimensions >= 4) indexes[3] = rand.Next(area.GetLength(3));
                if (num_of_dimensions == 5) indexes[4] = rand.Next(area.GetLength(4));

                List<Entity> list = (List<Entity>)area.GetValue(indexes);
                if (list.Count > 0)
                {
                    randomInitialPlace(e);
                    return 0;
                }
                else
                {
                    list.Add(e);
                    area.SetValue(list, indexes);
                    int[] coordinates = indexes;
                    e.Location = createLocation(coordinates);
                }
            }
            
            e = assignCoordinates(e);
            //add method for saving intital coordinates
            return 1;
        }


        //returns true is the game ends
        //iterate through all lists, if there is a list with more than 1 entity, call convertToZombie
        public Boolean moveAllEntities() {
            humans = universe.getHumans().ToArray();
            zombies = universe.getZombies().ToArray();

                currentIteration++;
                for (int i = 0; i < humans.Length; i++)
                {
                move(humans[i]);
                }

                for (int i = 0; i < zombies.Length; i++)
                {
                move(zombies[i]);
                }

                for (int i = 0; i < humans.Length; i++)
                {
                    List<Entity> eList = (List<Entity>)area.GetValue(humans[i].Location.coordinates);
                    if (eList.Count > 1) {
                        eList = convertToZombie(eList);
                        area.SetValue(eList, humans[i].Location.coordinates);
                    }
                }

                for (int i = 0; i < zombies.Length; i++)
                {
                    List<Entity> eList = (List<Entity>)area.GetValue(zombies[i].Location.coordinates);
                    if (eList.Count > 1)
                    {
                        eList = convertToZombie(eList);
                        area.SetValue(eList, zombies[i].Location.coordinates);
                    }
                }
            return checkEndCondition();
        }

        public void start() {

            //for initial console app
            Display d = new Display();
            maxIterations = d.iterations();
            initialHumans = d.startingHumans();
            initialZombies = d.startingZombies();

            num_of_dimensions = d.num_of_dimensions();
            universe.setNum_of_dimensions(num_of_dimensions);

            dimensions = d.arraySizes(num_of_dimensions);

            universe.buildUniverse2(dimensions);

            area = universe.getArea();

            for (int i = 0; i < initialHumans; i++)
            {
                Human h = universe.createRandomHuman();
                universe.addHuman(h);
                randomInitialPlace(h);
            }

            for (int i = 0; i < initialZombies; i++)
            {
                Zombie z = new Zombie();
                universe.addZombie(z);
                randomInitialPlace(z);
            }
            humans = universe.getHumans().ToArray();
            zombies = universe.getZombies().ToArray();
        }

        public int[] GetDimensions() { return dimensions; }
        public Array GetArea() { return area; }
        public int GetMaxIterations() { return maxIterations; }
        public void SetMaxIterations(int max) { maxIterations = max; }
        public void ResetIteration() { currentIteration = 0; }

        public void InitializeFromUI(int maxIter, int initHumans, int initZombies, int[] dims)
        {
            maxIterations = maxIter;
            initialHumans = initHumans;
            initialZombies = initZombies;

            num_of_dimensions = dims.Length;
            universe.setNum_of_dimensions(num_of_dimensions);
            dimensions = dims;

            universe.buildUniverse2(dimensions);
            area = universe.getArea();

            // place humans
            for (int i = 0; i < initialHumans; i++)
            {
                Human h = universe.createRandomHuman();
                universe.addHuman(h);
                randomInitialPlace(h);
            }
            // place zombies
            for (int i = 0; i < initialZombies; i++)
            {
                Zombie z = new Zombie();
                universe.addZombie(z);
                randomInitialPlace(z);
            }

            humans = universe.getHumans().ToArray();
            zombies = universe.getZombies().ToArray();
            currentIteration = 0;
        }

        // run exactly one iteration; return true when the simulation should end
        public bool StepOnce()
        {
            return moveAllEntities();
        }

        public void ClearAll()
        {
            universe = new Universe();
            area = null;
            humans = null;
            zombies = null;
            currentIteration = 0;
        }

    }
}
