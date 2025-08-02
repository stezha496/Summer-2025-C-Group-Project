using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_Class_Library
{
    internal class Location
    {
        private Array coordinates { get; set; }

        // This is auto generated from Visual Studio. idk if it works 100% correctly
        public override bool Equals(object obj)
        {
            return obj is Location location &&
                   EqualityComparer<Array>.Default.Equals(coordinates, location.coordinates);
        }
    }
}
