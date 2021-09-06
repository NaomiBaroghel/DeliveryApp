using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class KMeansHelp
    {
        public double[][] means { get; set; }
        public double sumVariation { get; set; }

       

        public KMeansHelp(double[][] means, double sumVariation)
        {
            this.means = means;
            this.sumVariation = sumVariation;
        }

    }
}
