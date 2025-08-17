using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_WindowsFormsApp
{
    public class Simulation
    {
        public int MaxIterations { get; set; }
        public int InitialHumans { get; set; }
        public int InitialZombies { get; set; }
        public int NumDimensions { get; set; }
        public int[] Dimensions { get; set; }    
    }

}
