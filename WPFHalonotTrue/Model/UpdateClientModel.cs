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
    class UpdateClientModel
    {
        private UpdateClientVM updateClientVM;
        BLImp blimp { get; set; }

        public UpdateClientModel(UpdateClientVM updateclientVM)
        {
            this.updateClientVM = updateclientVM;
            blimp = new BLImp();
        }


        //return a specific client available
        public Client getClient(int index)
        {
            try
            {
                List<Client> mylist = blimp.GetDispoClient();
                return mylist.ElementAt(index);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        //search the location of a given address
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


        //update the name of the client
        public void UpdateClientName(Client cl, string fN, string lN)
        {
            try
            {
                blimp.UpdateClientName(cl, fN, lN);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //update the client's mail
        public void UpdateClientMail(Client cl, string dMMail)
        {
            try
            {

                blimp.UpdateClientMail(cl, dMMail);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //update the client's phone
        public void UpdateClientPhone(Client cl, string dMPhone)
        {
            try
            {
                blimp.UpdateClientPhone(cl, dMPhone);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //remove the client of the list
        public void removeClient(Client myclient)
        {
            try
            {
                blimp.RemoveClient(myclient);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //remove the address of the client
        public void removeAddress(Address address)
        {
            try
            {
                blimp.RemoveAddress(address);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

     


        //get the address of the client
        public Address getAddress(Client myclient)
        {
            try
            {
                return blimp.getAddressFromClient(myclient);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //update the client's address
        public void UpdateAddress(Client myclient, Address newaddress)
        {
            try
            {
                 blimp.UpdateAddress(myclient,newaddress);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //update food or drug
        internal void UpdateFoodDrug(Client myclient, bool food, bool drug)
        {
            try
            {
                blimp.UpdateFoodDrug(myclient, food,drug);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
