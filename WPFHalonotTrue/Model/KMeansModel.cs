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
    public class KMeansModel
    {
        private KMeansVM KmeansVM;
        BLImp blimp { get; set; }


        public KMeansModel(ViewModel.KMeansVM kmeansVM)
        {
            this.KmeansVM = kmeansVM;
            blimp = new BLImp();
        }


        //get a specific delivery man
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


        //get the list of address from a specific distribution
        internal List<Address> getAddressFromDis(Distribution dis)
        {
            try
            {
                return blimp.getAddressFromDis(dis);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //do the kmeans
        internal async Task<Address[][]> KMeans(bool food, bool drug)
        {
           try
            { 
                return await blimp.KMeans(food, drug);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        

        //search the location of a specific address
        public async Task<object> SearchAddress(String myaddress)
        {
            try
            { 
            Object o = new object();

            return await blimp.SearchLocation(myaddress, o);
            }
            catch (Exception e)
            {
                throw e;
            }


        }


        //add a distribution to the list
        public void addDis(Distribution mydis, List<Address> address)
        {
            try
            {
                blimp.AddDistribution(mydis, address);
            }
            catch(Exception e)
            {
                throw e;
            }

        }


        //assign a distribution to a delivery man
        public void Assign(Distribution mydis, DeliveryMan dman)
        {
            try
            {
                blimp.Assignation(mydis, dman);
            
            }
            catch(Exception e)
            {
                throw e;
            }

}
    }
}
