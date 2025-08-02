using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_Class_Library
{
    public class Zombie : Entity
    {
        private bool isBloodSucker;
        private bool isBrainSucker;
        private int humansConverted;

        private static int zombieIdCounter = 0;

        public Zombie()
        {
            SetZombieId();
        }

        private void SetZombieId()
        {
            zombieIdCounter++;
            this.id = zombieIdCounter;
        }

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
