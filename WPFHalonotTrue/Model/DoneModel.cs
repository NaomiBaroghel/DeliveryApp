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
    class DoneModel
    {
        private DoneVM doneVM;
        BLImp blimp { get; set; }


        public DoneModel(DoneVM doneVM)
        {
            this.doneVM = doneVM;
            blimp = new BLImp();
        }


        //return a specific deliveryman
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


        //make a distribution done
        public void Done(Distribution mydis)
        {
            try
            {
                blimp.UpdateDoneDis(mydis);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //make a distribution canceled
        public void CancdelDis(Distribution mydis)
        {
            try
            {
                blimp.UpdateCancelDis(mydis);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        //get all the address of a specific distribution
        public List<Address> getAddressFromDis(Distribution dis)
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
    }
}
