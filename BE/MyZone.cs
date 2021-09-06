using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class MyZone
    {
        public Double LatMin { get;  }
        public Double LatMax { get;  }
        public Double LonMin { get;  }
        public Double LonMax { get;  }

        public MyZone()
        {
            LatMin = 29.443765;
            LatMax = 33.461798;
            LonMin = 34.557085;
            LonMax = 35.968828;
        }


    }
}
