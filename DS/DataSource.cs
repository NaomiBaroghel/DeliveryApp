using System;
using System.Collections.Generic;
using System.Dynamic;
using BE;
using System.Data.Entity;


namespace DS
{
    public class DataSource
    {

      


        private List<Client> clientList = new List<Client>();
        private List<Distribution> distributionList = new List<Distribution>();
        private List<Address> addresseList = new List<Address>(); // a voir


        public List<Client> getClientList()
        {
            return clientList;
        }
        public void setClientList(List<Client> newClientList)
        {
            clientList = newClientList;
        }

        public List<Distribution> getDistributionList()
        {
            return distributionList;
        }

        public void setDistributionList(List<Distribution> newDistributionList)
        {
            distributionList = newDistributionList;
        }

        public DataSource()
        {
        }
    }
}
