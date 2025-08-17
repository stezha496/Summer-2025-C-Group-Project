using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_Class_Library
{
    public class Entity
    {
        //might be easier if we give each entity a globalID for location tracking
        private static int globalId = 0;
        protected int id;
        // Also each entity will have a location object instead of an Array 
        //can change later if any issues arise
        public Location Location { get; set; }

        public Entity() 
        {
            id = ++globalId;
        }

        public int getId() { return id; }



        //if zombie or infected human
        //use if infected
        private List<Human> humansInfected = new List<Human>();
        public void addHumanInfected(Human h)
        {
            humansInfected.Add(h);
        }

        public List<Human> getHumansInfected() { return humansInfected; }

        private int humansConverted;
        private bool isBloodSucker;
        private bool isBrainSucker;
        public void IncrementHumansConverted()
        {
            humansConverted++;
            if (humansConverted == 100)
            {
                SetIsBrainSucker(true);
            }
        }

        public bool GetIsBloodSucker()
        {
            return isBloodSucker;
        }
        public void SetIsBloodSucker(bool isBloodSucker)
        {
            this.isBloodSucker = isBloodSucker;
        }

        public bool GetIsBrainSucker()
        {
            return isBrainSucker;
        }

        public void SetIsBrainSucker(bool isBrainSucker)
        {
            this.isBrainSucker = isBrainSucker;
        }

        public int GetHumansConverted()
        {
            return humansConverted;
        }
    }
}
