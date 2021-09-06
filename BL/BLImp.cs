using DAL;
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Net.Http;
using System.Windows;

namespace BL
{
    public class BLImp
    {
        DalImp dalimp = new DalImp();


        #region client
        //add a client to the list, check if the properties are not null and if the mail, phone and name are with the right form
        public void AddClient(Client myclient)
        {
            try
            {
                CheckAddC(myclient);
                CheckMail(myclient.Mail);
                CheckName(myclient.FirstName, myclient.LastName);
                CheckPhoneNumber(myclient.Phone);
                dalimp.AddClient(myclient);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }





        //get the address of the client
        public Address getAddressFromClient(Client myclient)
        {
            try
            {
                return dalimp.getAddressFromClient(myclient);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //remove client from the list
        public void RemoveClient(Client myclient)
        {
            try
            {
                dalimp.RemoveClient(myclient);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }

        //update the mail of the client
        public void UpdateClientMail(Client myclient, String newmail)
        {

            try
            {
                CheckMail(newmail);
                dalimp.UpdateClientMail(myclient, newmail);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        //update the phone of the client
        public void UpdateClientPhone(Client myclient, String newphone)
        {
            try
            {
                CheckPhoneNumber(newphone);
                dalimp.UpdateClientPhone(myclient, newphone);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }

        //update the name of the client
        public void UpdateClientName(Client myclient, String newfirstname, String newlastname)
        {
            try
            {
                CheckName(newfirstname, newlastname);
                dalimp.UpdateClientName(myclient, newfirstname, newlastname);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //check if the properties of the client are not null
        public void CheckAddC(Client myclient)
        {
            if (myclient.FirstName != null)
                if (myclient.LastName != null)
                    if (myclient.Mail != null)
                        if (myclient.MyAddress != null)// && myclient.MyAddress.NbAppart.ToString().Length != 0 && myclient.MyAddress.ACity.ToString().Length != 0 && myclient.MyAddress.StreeName != null)
                            if (myclient.Phone != null)
                                if (myclient.Food == true && myclient.Drug == false || myclient.Food == false && myclient.Drug == true || myclient.Drug == true && myclient.Food == true)
                                    return;
                                else
                                    throw new ArgumentException("You must choose Food or/and Drug");
                            else
                                throw new ArgumentException("You must enter your phone number");
                        else
                            throw new ArgumentException("You must enter a valid address");
                    else
                        throw new ArgumentException("You must enter your mail address");
                else
                    throw new ArgumentException("You must enter your last name");
            else
                throw new ArgumentException("You must enter your first name");



        }

        public void UpdateFoodDrug(Client myclient, bool food, bool drug)
        {
            try
            {
                dalimp.UpdateFoodDrug(myclient, food, drug);


            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //update the client's address
        public void UpdateAddress(Client myclient, Address newaddress)
        {
            try
            {
                dalimp.UpdateAddress(myclient, newaddress);


            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //get the client dispo
        public List<Client> GetDispoClient()
        {
            try
            {
                return dalimp.GetDispoClient();


            }
            catch (Exception e)
            {
                throw e;
            }

        }
        #endregion


        #region distribution
        //add a distribution to the list and give AssignF or Assign D = true
        public void AddDistribution(Distribution mydis, List<Address> myaddress)
        {
            try
            {
                mydis.AllAddress = new List<Address>();

                CheckAddD(mydis, myaddress);

                dalimp.AddDistribution(mydis, myaddress);
                ClientAssign(myaddress, mydis.Food, mydis.Drug);


            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //remove distribution ~ we don't really use it
        public void RemoveDistribution(Distribution mydis)
        {
            try
            {

                dalimp.RemoveDistribution(mydis);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //cancel distribution but not remove it
        public void UpdateCancelDis(Distribution mydis)
        {
            try
            {
                dalimp.UpdateCancelDis(mydis);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }

        ////if fix = true, we need to create a new distribution with the new date
        public void UpdateDis(Distribution mydis)
        {
            try
            {
                dalimp.UpdateDis(mydis);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //indicate that the distribution is done
        public void UpdateDoneDis(Distribution mydis)
        {
            if (mydis.Fix == true)
            {
                mydis.DisTime = mydis.DisTime.AddDays(mydis.Interval);
                try
                {
                    UpdateDis(mydis); //if fix = true, we need to create a new distribution with the new date
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
            {
                try
                {

                    dalimp.UpdateDoneDis(mydis);//otherwise we just need to make done = true
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }


        //check if the properties are not null
        public void CheckAddD(Distribution mydis, List<Address> address)
        {
           

                if (address.Count > 0)
                    if (mydis.Food == true || mydis.Drug == true)
                        if (mydis.Fix == true && mydis.Interval > 0 || mydis.Fix == false)
                            return;
                        else
                            throw new ArgumentException("You must indicate a delivery interval");
                    else
                        throw new ArgumentException("Must be for Food or/and Drug");
                else
                    throw new ArgumentException("You must enter at least one address");
            


        }

        //return the distribution not done or not cancel
        public List<Distribution> DisNotDone(DeliveryMan dman)
        {
            try
            {
                return dalimp.DisNotDone(dman);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //return the addresses of the distribution
        public List<Address> getAddressFromDis(Distribution dis)
        {
            try
            {
                return dalimp.getAddressFromDis(dis);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion



        #region dman

        //add dman to the list
        public void AddDMan(DeliveryMan mydman)
        {
            try
            {
                CheckAddDM(mydman);
                CheckMail(mydman.Mail);
                CheckName(mydman.FirstName, mydman.LastName);
                CheckPhoneNumber(mydman.Phone);
                dalimp.AddDMan(mydman);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //remove client from the list
        public void RemoveDMan(DeliveryMan mydman)
        {
            try
            {
                dalimp.RemoveDMan(mydman);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }

        //update the mail of the client
        public void UpdateDManMail(DeliveryMan mydman, String newmail)
        {

            try
            {
                CheckMail(newmail);
                dalimp.UpdateDManMail(mydman, newmail);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        //update the phone of the client
        public void UpdateDManPhone(DeliveryMan mydman, String newphone)
        {
            try
            {
                CheckPhoneNumber(newphone);
                dalimp.UpdateDManPhone(mydman, newphone);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }

        //update the name of the client
        public void UpdateDManName(DeliveryMan mydman, String newfirstname, String newlastname)
        {
            try
            {
                CheckName(newfirstname, newlastname);
                dalimp.UpdateDManName(mydman, newfirstname, newlastname);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



        //check the properties are not null
        public void CheckAddDM(DeliveryMan mydman)
        {

            if (mydman.FirstName != null)
                if (mydman.LastName != null)
                    if (mydman.Mail != null)
                        if (mydman.Phone != null)
                            return;
                        else
                            throw new ArgumentException("You must enter a phone number");
                    else
                        throw new ArgumentException("You must enter a mail address");
                else
                    throw new ArgumentException("You must enter a last name");
            else
                throw new ArgumentException("You must enter a first name");



        }



        #endregion

        #region address
        //add address in the list
        public void AddAddress(Address myaddress)
        {

            try
            {
                dalimp.AddAddress(myaddress);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        //remove an address from the list
        public void RemoveAddress(Address myaddress)
        {

            try
            {
                dalimp.RemoveAddress(myaddress);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion

        #region config

        //add a config and create database if doesn't exist
        public void AddConfig(Configuration config)
        {
            try
            {
                dalimp.AddConfig(config);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region check
        //check the form of the phone number
        public void CheckPhoneNumber(String newphone)
        {
            if (newphone.Length != 10)
                throw new ArgumentException("You need to enter 10 numbers for you Phone Number");
        }
        public void CheckMail(string mail)
        {


            if (mail.Length == 0 || mail.Contains(" ") || !mail.Contains("@") || !mail.Contains(".") || mail == null || mail == "someone@exemple.com")
                throw new ArgumentException("You need to enter a mail address");

        }

        //check the form of the name
        public void CheckName(string first, string last)
        {
            if (last.Length == 0)
                throw new ArgumentException("You need to enter your name");
            else if (first.Length == 0)
                throw new ArgumentException("You need to enter you family name");

        }

        #endregion

        #region getlist
        public List<Client> GetClientList()
        {
            try
            {
                return dalimp.GetClientList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<Distribution> GetDisList()
        {
            try
            {
                return dalimp.GetDisList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<DeliveryMan> GetDManList()
        {
            try
            {
                return dalimp.GetDManList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<Address> GetAddressList()
        {
            try
            {
                return dalimp.GetAddressList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion
        //assigne a new distribution to the delivery man
        public void Assignation(Distribution mydis, DeliveryMan mydman)
        {
            try
            {
                dalimp.Assignation(mydis, mydman);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //give AssignsF or AssignsD true

        public void ClientAssign(List<Address> myaddress, bool food, bool drug)
        {
            try
            {
                dalimp.ClientAssign(myaddress, food, drug);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        //add address to distribution
        public void AddAddressToDis(Distribution mydis, Address myaddress)
        {
            try
            {
                dalimp.AddAddressToDis(mydis, myaddress);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



        //return address dispo specific distribution
        public List<Address> AddressDispo(Boolean food, Boolean drug)
        {
            try
            {
                return dalimp.AddressDispo(food, drug);
            }
            catch(Exception e)
            {
                throw e;
            }
        }




        #region location
        //return location of an address
        public async Task<object> SearchLocation(String myaddress, object jsonObject)
        {
            try
            { 
            return await dalimp.SearchLocation(myaddress, jsonObject);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region chart
        #region day

       //return distribution planned of a certain day and a certain city
        public List<Distribution> DisPlanned(DateTime myday, String mycity)
        {
            try
            { 
            Boolean flag = false;
            List<Distribution> mylistdis = dalimp.GetDisList();
            List<Distribution> displanned = new List<Distribution>();

            foreach (Distribution dis in mylistdis)
            {
                flag = false;
                if (dis.DisTime == myday)
                {
                    List<Address> mylistaddress = dalimp.getAddressFromDis(dis);
                    foreach (Address address in mylistaddress)
                    {
                        if (address.ACity.ToString() == mycity)
                            flag = true;
                    }
                }
                if (flag)
                    displanned.Add(dis);

            }

            return displanned;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //return distribution done of a certain day and a certain city
        public List<Distribution> DisDone(DateTime myday, String mycity)
        {
            try
            {
                bool flag = false;
                List<Distribution> mylistdis = dalimp.GetDisList();
                List<Distribution> disdone = new List<Distribution>();

                foreach (Distribution dis in mylistdis)
                {


                    flag = false;
                    if (dis.DisTime.ToShortDateString() == myday.ToShortDateString() && dis.DoneTime.ToShortDateString() == myday.ToShortDateString() && dis.Done == true)
                    {

                        List<Address> mylistaddress = dalimp.getAddressFromDis(dis);
                        foreach (Address address in mylistaddress)
                        {
                            if (address.ACity.ToString() == mycity)
                                flag = true;
                        }
                    }
                    if (flag)
                        disdone.Add(dis);


                }


                return disdone;
            
            }
            catch(Exception e)
            {
                throw e;
            }
}

        //return distribution done of a certain city on the day choosen but not planned
        public List<Distribution> DisNotPlannedButDone(DateTime myday, String mycity)
        {
            try
            { 
            Boolean flag = false;
            List<Distribution> mylistdis = dalimp.GetDisList();
            List<Distribution> disNotPlannedButDone = new List<Distribution>();

            foreach (Distribution dis in mylistdis)
            {
                flag = false;
                if (dis.DisTime < myday && dis.DoneTime.ToShortDateString() == myday.ToShortDateString() && dis.Done == true)
                {

                    List<Address> mylistaddress = dalimp.getAddressFromDis(dis);
                    foreach (Address address in mylistaddress)
                    {
                        if (address.ACity.ToString() == mycity)
                            flag = true;
                    }
                }
                if (flag)
                    disNotPlannedButDone.Add(dis);
            }

            return disNotPlannedButDone;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //return distribution canceled of a certain day and a certain city
        public List<Distribution> DisCanceled(DateTime myday, string mycity)
        {
            try
            { 
            Boolean flag = false;
            List<Distribution> mylistdis = dalimp.GetDisList();
            List<Distribution> disCanceled = new List<Distribution>();

            foreach (Distribution dis in mylistdis)
            {
                flag = false;
                List<Address> mylistaddress = dalimp.getAddressFromDis(dis);
                foreach (Address address in mylistaddress)
                {
                    if (address.ACity.ToString() == mycity)
                        flag = true;
                }

                if (dis.DisTime <= myday && dis.DoneTime.ToShortDateString() == myday.ToShortDateString() && dis.Cancel == true && flag)
                    disCanceled.Add(dis);
            }

            return disCanceled;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        #region week

        //return distribution planned of a certain week and a certain city
        public List<Distribution> DisPlannedWeek(DateTime myday, String mycity)
        {
            try
            { 
            Boolean flag = false;
            List<Distribution> mylistdis = dalimp.GetDisList();
            List<Distribution> displanned = new List<Distribution>();
            DateTime dayweek = myday.AddDays(7);

            foreach (Distribution dis in mylistdis)
            {
                flag = false;
                if (dis.DisTime >= myday || dis.DisTime <= dayweek)
                {
                    List<Address> mylistaddress = dalimp.getAddressFromDis(dis);
                    foreach (Address address in mylistaddress)
                    {
                        if (address.ACity.ToString() == mycity)
                            flag = true;
                    }
                }
                if (flag)
                    displanned.Add(dis);

            }

            return displanned;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //return distribution done of a certain week and a certain city

        public List<Distribution> DisDoneWeek(DateTime myday, String mycity)
        {
            try
            { 
            bool flag = false;
            List<Distribution> mylistdis = dalimp.GetDisList();
            List<Distribution> disdone = new List<Distribution>();
            DateTime dayweek = myday.AddDays(7);


            foreach (Distribution dis in mylistdis)
            {

                flag = false;
                if ((dis.DisTime >= myday || dis.DisTime <= dayweek) && (dis.DoneTime.ToShortDateString() == myday.ToShortDateString() || dis.DoneTime >= myday || dis.DoneTime <= dayweek || dis.DoneTime.ToShortDateString() == dayweek.ToShortDateString()) && dis.Done == true)
                {

                    List<Address> mylistaddress = dalimp.getAddressFromDis(dis);
                    foreach (Address address in mylistaddress)
                    {
                        if (address.ACity.ToString() == mycity)
                            flag = true;
                    }
                }
                if (flag)
                    disdone.Add(dis);


            }


            return disdone;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //return distribution done of a certain city on the week choosen but not planned
        public List<Distribution> DisNotPlannedButDoneWeek(DateTime myday, String mycity)
        {
            try
            { 
            Boolean flag = false;
            List<Distribution> mylistdis = dalimp.GetDisList();
            List<Distribution> disNotPlannedButDone = new List<Distribution>();
            DateTime dayweek = myday.AddDays(7);


            foreach (Distribution dis in mylistdis)
            {
                flag = false;
                if (dis.DisTime < myday && (dis.DoneTime.ToShortDateString() == myday.ToShortDateString() || dis.DoneTime >= myday || dis.DoneTime <= dayweek || dis.DoneTime.ToShortDateString() == dayweek.ToShortDateString()) && dis.Done == true)
                {

                    List<Address> mylistaddress = dalimp.getAddressFromDis(dis);
                    foreach (Address address in mylistaddress)
                    {
                        if (address.ACity.ToString() == mycity)
                            flag = true;
                    }
                }
                if (flag)
                    disNotPlannedButDone.Add(dis);
            }

            return disNotPlannedButDone;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //return distribution canceled of a certain week and a certain city
        public List<Distribution> DisCanceledWeek(DateTime myday, string mycity)
        {
            try
            { 
            Boolean flag = false;
            List<Distribution> mylistdis = dalimp.GetDisList();
            List<Distribution> disCanceled = new List<Distribution>();
            DateTime dayweek = myday.AddDays(7);


            foreach (Distribution dis in mylistdis)
            {
                flag = false;
                List<Address> mylistaddress = dalimp.getAddressFromDis(dis);
                foreach (Address address in mylistaddress)
                {
                    if (address.ACity.ToString() == mycity)
                        flag = true;
                }

                if (dis.DisTime <= myday && (dis.DoneTime.ToShortDateString() == myday.ToShortDateString() || dis.DoneTime >= myday || dis.DoneTime <= dayweek || dis.DoneTime.ToShortDateString() == dayweek.ToShortDateString()) && dis.Cancel == true && flag)
                    disCanceled.Add(dis);
            }

            return disCanceled;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion


        #region month

        //return distribution planned of a certain month and a certain city
        public List<Distribution> DisPlannedMonth(DateTime myday, String mycity)
        {
            try
            { 
            Boolean flag = false;
            List<Distribution> mylistdis = dalimp.GetDisList();
            List<Distribution> displanned = new List<Distribution>();

            foreach (Distribution dis in mylistdis)
            {
                flag = false;
                if (dis.DisTime.Month == myday.Month)
                {
                    List<Address> mylistaddress = dalimp.getAddressFromDis(dis);
                    foreach (Address address in mylistaddress)
                    {
                        if (address.ACity.ToString() == mycity)
                            flag = true;
                    }
                   

                }
                if (flag)
                    displanned.Add(dis);



            }

            return displanned;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //return distribution done of a certain month and a certain city

        public List<Distribution> DisDoneMonth(DateTime myday, String mycity)
        {
            try
            { 
            bool flag = false;
            List<Distribution> mylistdis = dalimp.GetDisList();
            List<Distribution> disdone = new List<Distribution>();

            foreach (Distribution dis in mylistdis)
            {


                flag = false;
                if (dis.DisTime.Month == myday.Month && dis.DoneTime.Month == myday.Month && dis.Done == true)
                {

                    List<Address> mylistaddress = dalimp.getAddressFromDis(dis);
                    foreach (Address address in mylistaddress)
                    {
                        if (address.ACity.ToString() == mycity)
                            flag = true;
                    }
                }
                if (flag)
                    disdone.Add(dis);


            }


            return disdone;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //return distribution done of a certain city in the month choosen but not planned 
        public List<Distribution> DisNotPlannedButDoneMonth(DateTime myday, String mycity)
        {
            try
            { 
            Boolean flag = false;
            List<Distribution> mylistdis = dalimp.GetDisList();
            List<Distribution> disNotPlannedButDone = new List<Distribution>();

            foreach (Distribution dis in mylistdis)
            {
                flag = false;
                if (dis.DisTime.Month != myday.Month && dis.DoneTime.Month == myday.Month && dis.Done == true)
                {

                    List<Address> mylistaddress = dalimp.getAddressFromDis(dis);
                    foreach (Address address in mylistaddress)
                    {
                        if (address.ACity.ToString() == mycity)
                            flag = true;
                    }
                }
                if (flag)
                    disNotPlannedButDone.Add(dis);
            }

            return disNotPlannedButDone;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //return distribution canceled of a certain month and a certain city
        public List<Distribution> DisCanceledMonth(DateTime myday, string mycity)
        {
            try
            { 
            Boolean flag = false;
            List<Distribution> mylistdis = dalimp.GetDisList();
            List<Distribution> disCanceled = new List<Distribution>();

            foreach (Distribution dis in mylistdis)
            {
                flag = false;
                List<Address> mylistaddress = dalimp.getAddressFromDis(dis);
                foreach (Address address in mylistaddress)
                {
                    if (address.ACity.ToString() == mycity)
                        flag = true;
                }

                if (dis.DoneTime.Month == myday.Month && dis.Cancel == true && flag)
                    disCanceled.Add(dis);
            }

            return disCanceled;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        #endregion

        #region kmeans
        //create the clusters
        public async Task<Address[][]> KMeans(bool food, bool drug)
        {
            try
            {
                return await dalimp.Kmeans(food, drug);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        #endregion



        #region PDF
        //get pdf of the deliveryman selected
        public void printPDF(int index)
        {
            try
            {
                dalimp.PrintPDF(index);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
