using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BE 
{
    [Table("Address")]
    public class Address
    {
       
        private int idAddress;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDAddress { get; set; }

        private int nbAppart;
        public int NbAppart
        {
            get { return nbAppart; }
            set { nbAppart = value; }
        }
        private String streetName;

        public String StreeName
        {
            get { return streetName; }
            set { streetName = value; }
        }
        private MyEnum.City aCity;

        public MyEnum.City ACity
        {
            get { return aCity; }
            set { aCity = value; }
        }


        //~we don't use it
        private MyEnum.Neighborhood aNeighborhood;
        public MyEnum.Neighborhood ANeighborhood
        {
            get { return aNeighborhood; }
            set { aNeighborhood = value; }
        }

        


        public virtual ICollection<Distribution> AllDis { get; set; }


        
        public Address(int nbAppart, string streeName, MyEnum.City aCity)
        {
            NbAppart = nbAppart;
            StreeName = streeName;
            ACity = aCity;
            AllDis = new HashSet<Distribution>();

        }

        public Address()
        {
            AllDis = new HashSet<Distribution>();

        }

        public string StringAddress()
        {
            return NbAppart.ToString() + " " + StreeName.ToString() + " " + ACity.ToString();
        }

       
    }
}
