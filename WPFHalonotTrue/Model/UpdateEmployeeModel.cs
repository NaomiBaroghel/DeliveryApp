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
    class UpdateEmployeeModel
    {
        private UpdateEmployeeVM updateEmployeeVM;
        BLImp blimp { get; set; }

        public UpdateEmployeeModel(UpdateEmployeeVM updateEmployeeVM)
        {
            this.updateEmployeeVM = updateEmployeeVM;
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

     
        //update the delivery man's name
        public void UpdateDManName(DeliveryMan dMan, string fN, string lN)
        {
            try
            { 
            blimp.UpdateDManName(dMan, fN, lN);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        //update the delivery man's man
        public void UpdateDManMail(DeliveryMan dMan, string dMMail)
        {
            try
            { 
            blimp.UpdateDManMail(dMan, dMMail);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //update the delivery man's phone
        public void UpdateDManPhone(DeliveryMan dMan, string dMPhone)
        {
            try
            { 

            blimp.UpdateDManPhone(dMan, dMPhone);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //remove the delivery man from the list
        public void removeEmployee(DeliveryMan dMan)
        {
            try
            { 
            blimp.RemoveDMan(dMan);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
