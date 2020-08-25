using System;
using DAL;
using BE;
using System.Runtime.InteropServices;

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
                Configuration.ClientID += 1;
                myclient.IDClient = Configuration.ClientID;
                dalimp.AddClient(myclient);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //remove client from the list
        public void RemoveClient(Client myclient)
        {
            try
            {
                dalimp.RemoveClient(myclient);
            }
            catch(Exception e)
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
                        if (myclient.MyAddress != null)
                            if (myclient.Phone != null)
                               
                                    if (myclient.Food == true && myclient.Drug == false || myclient.Food == false && myclient.Drug == true || myclient.Drug == true && myclient.Food == true)
                                        return;
                                    else
                                        throw new ArgumentException("You must choose Food or/and Drug");
                                 else
                                throw new ArgumentException("You must enter your phone number");
                        else
                            throw new ArgumentException("You must enter your address");
                    else
                        throw new ArgumentException("You must enter your mail address");
                else
                    throw new ArgumentException("You must enter your last name");
            else
                throw new ArgumentException("You must enter your first name");



        }
        #endregion


        #region distribution
        //add a distribution to the list
        public void AddDistribution(Distribution mydis)
        {
            try
            {
                CheckAddD(mydis);
                Configuration.DistributionID += 1;
                mydis.IDDis = Configuration.DistributionID;
            }
            catch(Exception e)
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
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }


        }

        //update distribution
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
                //update de Distribution (surtout lorsque fix = true, on rajoute autant de jour qu'il faut pour la prochaine distribution, done = false)
                mydis.TimeDistribution.Add(mydis.TimeDistribution[mydis.TimeDistribution.Count - 1].AddDays(mydis.Interval));
                try
                {
                    UpdateDis(mydis);
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
                   
                    dalimp.UpdateDoneDis(mydis);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }


        //check if the properties are not null
        public void CheckAddD(Distribution mydis)
        {

            if (mydis.AllAddress != null)
                if (mydis.Food == true || mydis.Drug == true)
                    if (mydis.Fix == true && mydis.Interval != 0)
                        return;
                    else
                        throw new ArgumentException("You must indicate delivery interval");
                else
                    throw new ArgumentException("Must be for Food or Drug");
            else
                throw new ArgumentException("You must enter at least one address");
           


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
                Configuration.DeliveryManID += 1;
                mydman.IDDMan = Configuration.DeliveryManID;
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





    }

}
