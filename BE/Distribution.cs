using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Distribution
    {
        private int idDis;
        public int IDDis
        {
            get { return idDis; }
            set { idDis = value; }
        }
       

        private Boolean food;
        public Boolean Food 
        {
            get { return done; }
            set { done = value; }
        }
        private Boolean drug;
        public Boolean Drug 
        {
            get { return done; }
            set { done = value; }
        }
        private Boolean fix; //distribution regulière
        public Boolean Fix 
        {
            get { return done; }
            set { done = value; }
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
        private List<Address> allAddress;
        public List<Address> AllAddress
        {
            get { return allAddress; }
            set { allAddress = value; }
        }
        private List<DateTime> timeDistribution { get; set; }
        public List<DateTime> TimeDistribution
        {
            get { return timeDistribution; }
            set { timeDistribution = value; }
        }


        public Distribution()
            {
                timeDistribution[0] = DateTime.Now;
                Done = false;
                Food = false;
                Drug = false;
                Fix = true; //on considère que la distribution est regulière
                Cancel = false;



            }
        
}
