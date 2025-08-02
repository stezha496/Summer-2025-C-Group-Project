using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_Class_Library
{
    public class Human : Entity
    {
        private int age;
        private string occupation;
        private HealingFactor healingFactor;
        private bool encounteredZombie;
        private bool convertedToZombie;

        public Human(int age, string occupation, HealingFactor healingFactor)
        {
            this.age = age;
            this.occupation = occupation;
            this.healingFactor = healingFactor;
            this.encounteredZombie = false;
            this.convertedToZombie = false;
        }

        public bool GetEncounteredZombie()
        {
            return encounteredZombie;
        }

        public void SetEncounteredZombie(bool encounteredZombie)
        {
            this.encounteredZombie = encounteredZombie;
        }

        public bool GetConvertedToZombie()
        {
            return convertedToZombie;
        }

        public void SetConvertedToZombie(bool convertedToZombie)
        {
            this.convertedToZombie = convertedToZombie;
        }
    }

}
