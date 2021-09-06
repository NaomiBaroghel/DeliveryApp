using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE
{
    public class Configuration
    {
        [Key]
        public int idconfig { get; set; }

        public int ClientID { get; set; }
        public int DistributionID { get; set; }
        public int DeliveryManID { get; set; }
        public int AddressID { get; set; }

        public Configuration()

        {
            ClientID = 100000000;
            DistributionID = 200000000;
            DeliveryManID = 300000000;
            AddressID = 400000000;

        }
    }
}
