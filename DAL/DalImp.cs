using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using BE;
using DS;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DalImp 
    {
        public class InfoClient : DbContext
        {
            public virtual DbSet<Client> clientList { get; set; }
            
        }

        public class InfoDistribution : DbContext
        {
            public virtual DbSet<Distribution> distributionList { get; set; }
        }

        public class InfoDelivery : DbContext
        {
            public virtual DbSet<DeliveryMan> DManList { get; set; }
        }

        #region client

        //add a new client to the list
        public void AddClient(Client myclient)
        {
            InfoClient fc = new InfoClient();
            Client ifclient = fc.clientList.FirstOrDefault(client => client.IDClient == myclient.IDClient);
            if(ifclient!=null)
            {
                throw new ArgumentException("Already exist");
            }
            fc.clientList.Add(myclient);
            fc.SaveChanges();
        }

        //remove a client from the list
        public void RemoveClient(Client myclient)
        {
            InfoClient fc = new InfoClient();
            Client ifclient = fc.clientList.FirstOrDefault(client=> client.IDClient == myclient.IDClient);
            if(ifclient == null)
            {
                throw new ArgumentNullException("Doesn't exist");
            }

            fc.clientList.Remove(ifclient);
            fc.SaveChanges();


        }

        //update the mail of a client
        public void UpdateClientMail(Client myclient, String newmail)
        {

            InfoClient fc = new InfoClient();
            Client ifclient = fc.clientList.FirstOrDefault(client => client.IDClient == myclient.IDClient);
            if (ifclient == null)
            {
                throw new ArgumentNullException("Doesn't exist");
            }
            ifclient.Mail = newmail;
            fc.SaveChanges();

        }

        //update the phone of a client
        public void UpdateClientPhone(Client myclient, String newphone)
        {
            InfoClient fc = new InfoClient();
            Client ifclient = fc.clientList.FirstOrDefault(client => client.IDClient == myclient.IDClient);
            if (ifclient == null)
            {
                throw new ArgumentNullException("Doesn't exist");
            }
            ifclient.Phone = newphone;
            fc.SaveChanges();
        }

        //update the name of the client
        public void UpdateClientName(Client myclient, String newfirstname, String newlastname)
        {
            InfoClient fc = new InfoClient();
            Client ifclient = fc.clientList.FirstOrDefault(client => client.IDClient == myclient.IDClient);
            if (ifclient == null)
            {
                throw new ArgumentNullException("Doesn't exist");
            }
            ifclient.FirstName = newfirstname;
            ifclient.LastName = newlastname;
            fc.SaveChanges();
        }

        #endregion


        #region distribution
        //add a distribution to the list
        public void AddDistribution (Distribution mydis)
        {
            InfoDistribution fd = new InfoDistribution();
            Distribution ifdis = fd.distributionList.FirstOrDefault(distribution=> distribution.IDDis == mydis.IDDis);
            if (ifdis != null)
            {
                throw new ArgumentException("Already exist");
            }
            fd.distributionList.Add(mydis);
            fd.SaveChanges();
        }

        //cancel distribution but not remove it
        public void UpdateCancelDis(Distribution mydis) 
        {
            InfoDistribution fd = new InfoDistribution();
            Distribution ifdis = fd.distributionList.FirstOrDefault(distribution => distribution.IDDis == mydis.IDDis);
            if (ifdis == null)
            {
                throw new ArgumentNullException("Doesn't exist");
            }

            ifdis.Cancel = true;
            fd.SaveChanges();



        }

        //indicated that the distribution is done
        public void UpdateDoneDis(Distribution mydis) 
        {
            InfoDistribution fd = new InfoDistribution();
            Distribution ifdis = fd.distributionList.FirstOrDefault(distribution => distribution.IDDis == mydis.IDDis);
            if (ifdis == null)
            {
                throw new ArgumentNullException("Doesn't exist");
            }

            ifdis.Done = true;
            fd.SaveChanges();


        }

        //update de Distribution (surtout lorsque fix = true, on rajoute autant de jour qu'il faut pour la prochaine distribution, done = false)
        public void UpdateDis(Distribution mydis)
        {
            InfoDistribution fd = new InfoDistribution();
            Distribution ifdis = fd.distributionList.FirstOrDefault(distribution => distribution.IDDis == mydis.IDDis);
            if (ifdis == null)
            {
                throw new ArgumentNullException("Doesn't exist");
            }

            ifdis = mydis; //on a juste verifer son id, l'update a deja était faite dans BL
            fd.SaveChanges();

        }

        #endregion

        #region deliveryman

        //add a DeliveryMan to the list
        public void AddDMan(DeliveryMan mydman)
        {
            InfoDelivery fdman = new InfoDelivery();
            DeliveryMan ifdman = fdman.DManList.FirstOrDefault(deliverym => deliverym.IDDMan == mydman.IDDMan);
            if (ifdman != null)
            {
                throw new ArgumentException("Already exist");
            }
            fdman.DManList.Add(ifdman);
            fdman.SaveChanges();

        }

        //remove a DeliveryMan from the list
        public void RemoveDMan(DeliveryMan mydman)
        {
            InfoDelivery fdman = new InfoDelivery();
            DeliveryMan ifdman = fdman.DManList.FirstOrDefault(deliverym => deliverym.IDDMan == mydman.IDDMan);
            if (ifdman == null)
            {
                throw new ArgumentNullException("Doesn't exist");
            }

            fdman.DManList.Remove(ifdman);
            fdman.SaveChanges();



        }

        //update the mail of a DeliveryMan
        public void UpdateDManMail(DeliveryMan mydman, String newmail)
        {

            InfoDelivery fdman = new InfoDelivery();
            DeliveryMan ifdman = fdman.DManList.FirstOrDefault(deliverym => deliverym.IDDMan == mydman.IDDMan);
            if (ifdman == null)
            {
                throw new ArgumentNullException("Doesn't exist");
            }
            ifdman.Mail = newmail;
            fdman.SaveChanges();


        }

        //update the phone of a DeliveryMan
        public void UpdateDManPhone(DeliveryMan mydman, String newphone)
        {
            InfoDelivery fdman = new InfoDelivery();
            DeliveryMan ifdman = fdman.DManList.FirstOrDefault(deliverym => deliverym.IDDMan == mydman.IDDMan);
            if (ifdman == null)
            {
                throw new ArgumentNullException("Doesn't exist");
            }
            ifdman.Phone = newphone;
            fdman.SaveChanges();

        }

        //update the name of the DeliveryMan
        public void UpdateDManName(DeliveryMan mydman, String newfirstname, String newlastname)
        {
            InfoDelivery fdman = new InfoDelivery();
            DeliveryMan ifdman = fdman.DManList.FirstOrDefault(deliverym => deliverym.IDDMan == mydman.IDDMan);
            if (ifdman == null)
            {
                throw new ArgumentNullException("Doesn't exist");
            }
            ifdman.FirstName = newfirstname;
            ifdman.LastName = newlastname;
            fdman.SaveChanges();

        }

        #endregion


        //add a distribution to the list of the delivery man
        public void Assignation(Distribution mydis,DeliveryMan mydman)
        {
            InfoDistribution fd = new InfoDistribution();
            Distribution ifdis = fd.distributionList.FirstOrDefault(distribution => distribution.IDDis == mydis.IDDis);
            if (ifdis == null)
            {
                throw new ArgumentNullException("Doesn't exist");
            }

            InfoDelivery fdman = new InfoDelivery();
            DeliveryMan ifdman = fdman.DManList.FirstOrDefault(deliverym => deliverym.IDDMan == mydman.IDDMan);
            if (ifdman == null)
            {
                throw new ArgumentNullException("Doesn't exist");
            }

            ifdman.AllDistributions.Add(mydis);
            fdman.SaveChanges();

        }
    }
}
