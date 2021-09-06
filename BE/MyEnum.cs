using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class MyEnum
    {
        
        public enum City { TelAviv, Netanya, Jerusalem, Eilat, Haifa, Safed, Tiberia, Netivot, Ashdod, Ashkelon, Raanana };
        public enum Neighborhood { Center, North, South, East, West };

    }
}
