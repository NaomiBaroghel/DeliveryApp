using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFHalonotTrue.ViewModel;

namespace WPFHalonotTrue.Model
{
    class DistributionModel
    {
        private DistributionVM distributionVM;
        BLImp blimp { get; set; }

        public DistributionModel(DistributionVM distributionVM)
        {

            this.distributionVM = distributionVM;
            blimp = new BLImp();
        }


        //add distribution to the list
        public void addDis(Distribution distribution, List<Address> myaddress)
        {
            try
            {
                blimp.AddDistribution(distribution, myaddress);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        //return list of the name of each deliveryman
        public List<string> GetName()
        {
            try
            {
                List<string> mylist = new List<string>();
                foreach (DeliveryMan dm in blimp.GetDManList())
                {
                    string temp = dm.FirstName + " " + dm.LastName;
                    mylist.Add(temp);
                }

                return mylist;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //return addresses available
        public List<Address> AddressDispo(bool food, bool drug)
        {
            try
            {
                return blimp.AddressDispo(food, drug);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //return the deliveryman selected
        public DeliveryMan getDman(int index)
        {
            try
            {
                List<DeliveryMan> mylist = blimp.GetDManList();
                return mylist.ElementAt(index);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        //assign a distribution to a deliveryman
        public void Assign(Distribution mydis, DeliveryMan mydman)
        {
            try
            {
                blimp.Assignation(mydis, mydman);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
