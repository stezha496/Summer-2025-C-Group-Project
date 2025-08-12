using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_Class_Library
{
    internal class Location
    {
        //Assign location from GameLogic class
        public int[] coordinates { get; set; }

        // This is auto generated from Visual Studio. idk if it works 100% correctly
        public bool Equals(Array coordinates)
        {
            //the moment a dimension is not the same, isEqual will be false
            bool isEqual = true;
            for (int i = 0; i<this.coordinates.Length; i++) {
                isEqual = this.coordinates.GetValue(i) == coordinates.GetValue(i);
            }

            return isEqual;
        }
    }
}
