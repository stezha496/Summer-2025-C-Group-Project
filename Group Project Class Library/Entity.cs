using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_Class_Library
{
    internal class Entity
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
    }
}
