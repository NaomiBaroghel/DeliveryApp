using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFHalonotTrue.Model
{

    class ClientModel
    {
        BLImp blimp { get; set; }

        public ClientModel()
        {
            this.blimp = new BLImp();
        }


        //add a client to the list
        internal void AddClient(Client client)
        {
            try
            {
                blimp.AddClient(client);
            }
            catch(Exception e)
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
    }
}
