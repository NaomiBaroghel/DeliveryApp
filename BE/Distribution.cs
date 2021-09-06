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
    [Table("Distribution")]

    public class Distribution
    {
       
        private int idDis;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDDis { get; set; }


        private Boolean food;
        public Boolean Food
        {
            get { return food; }
            set { food = value; }
        }
        private Boolean drug;
        public Boolean Drug
        {
            get { return drug; }
            set { drug = value; }
        }
        private Boolean fix; //distribution regulière
        public Boolean Fix
        {
            get { return fix; }
            set { fix = value; }
        }

        private int interval;
        public int Interval
        {
            get { return interval; }
            set { interval = value; }
        }
        private Boolean done;
        public Boolean Done
        {
            get { return done; }
            set { done = value; }
        }

        private Boolean cancel;
        public Boolean Cancel
        {
            get { return cancel; }
            set { cancel = value; }
        }
        private   ICollection<Address> allAddress;
         public virtual ICollection<Address> AllAddress
        {
            get { return allAddress; }
            set { allAddress = value; }
        }


        private DateTime disTime;
        public DateTime DisTime
        { get { return disTime; }
          set { disTime = value; }
        }

        private DateTime doneTime;
        public DateTime DoneTime
        {
            get { return doneTime; }
            set { doneTime = value; }
        }


        public Distribution()
        {
            AllAddress = new HashSet<Address>();

            DisTime = DateTime.Today;
            Food = false;
            Drug = false;
            Fix = true; //on considère que la distribution est regulière
            Interval = 1;
            Done = false;
            Cancel = false;
            DoneTime = new DateTime(2000, 01, 01);




        }

        public Distribution(bool food, bool drug, bool fix, int interval)
        {
            DisTime = DateTime.Today;
            Food = food;
            Drug = drug;
            Fix = fix;
            Interval = interval;

            AllAddress = new HashSet<Address>();

            Done = false;
            Cancel = false;
            DoneTime = new DateTime(2000,01,01);



        }

        public Distribution(Distribution olddis)
        {
            Food = olddis.Food;
            Drug = olddis.Drug;
            Fix = olddis.Fix;
            Interval = olddis.Interval;
            Done = false;
            Cancel = false;
            DisTime = olddis.DisTime;
            DoneTime = new DateTime(2000, 01, 01);
            AllAddress = new HashSet<Address>();

        }
    }
}
