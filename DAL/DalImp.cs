using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BE;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace DAL
{
    public class DalImp
    {
        public DS2 myds2 = new DS2();


        #region client

        //add a new client to the list
        public void AddClient(Client myclient)
        {
            using (var db = new DS2())
            {

                Configuration myconfig = db.ConfigList.FirstOrDefault(config => config.idconfig == 1);

                if (myconfig == null)
                {
                    throw new ArgumentException("Problem : there is no config");

                }
                myconfig.ClientID += 1;
                myclient.IDClient = myconfig.ClientID;
                myconfig.AddressID += 1;
                myclient.MyAddress.IDAddress = myconfig.AddressID;

                Client ifclient = db.clientList.FirstOrDefault(client => client.IDClient == myclient.IDClient);
                if (ifclient != null)
                {
                    throw new ArgumentException("Client Already exist");
                }
                Address address = db.AddressList.FirstOrDefault(myaddress => myaddress.IDAddress == myclient.MyAddress.IDAddress);
                if (address != null)
                {
                    throw new ArgumentException("Address Already exist");
                }

                db.clientList.Add(myclient);
                db.AddressList.Add(myclient.MyAddress);
                db.SaveChanges();
            }



        }

        //get the address of the client
        public Address getAddressFromClient(Client myclient)
        {
            Address address = new Address();
            using (var db = new DS2())
            {
                Client ifclient = db.clientList.FirstOrDefault(client => client.IDClient == myclient.IDClient);
                if (ifclient == null)
                {
                    throw new ArgumentException("Client doesn't exist");
                }

                address = db.AddressList.FirstOrDefault(myaddress => myaddress.IDAddress == ifclient.MyAddress.IDAddress);
                if (address == null)
                {
                    throw new ArgumentException("Doesn't Exist");

                }
                return address;
            }
           
        }



        //remove a client from the list
        public void RemoveClient(Client myclient)
        {
            using (var db = new DS2())
            {
                Client ifclient = db.clientList.FirstOrDefault(client => client.IDClient == myclient.IDClient);
                if (ifclient == null)
                {
                    throw new ArgumentNullException("Doesn't exist");
                }
                // Address addtemp = db.AddressList.FirstOrDefault(add => add.IDAddress == myclient.MyAddress.IDAddress);

                /* db.AddressList.Remove(addtemp);
                 db.SaveChanges();*/
                //on peut pas supp address ici...
                db.clientList.Remove(ifclient);
                db.SaveChanges();


            }


        }

        //update the mail of a client
        public void UpdateClientMail(Client myclient, String newmail)
        {
            using (var db = new DS2())
            {
                Client ifclient = db.clientList.FirstOrDefault(client => client.IDClient == myclient.IDClient);
                if (ifclient == null)
                {
                    throw new ArgumentNullException("Doesn't exist");
                }
                ifclient.Mail = newmail;
                db.SaveChanges();
            }

        }

        //update the phone of a client
        public void UpdateClientPhone(Client myclient, String newphone)
        {
            using (var db = new DS2())
            {
                Client ifclient = db.clientList.FirstOrDefault(client => client.IDClient == myclient.IDClient);
                if (ifclient == null)
                {
                    throw new ArgumentNullException("Doesn't exist");
                }
                ifclient.Phone = newphone;
                db.SaveChanges();
            }
        }

        public void UpdateFoodDrug(Client myclient, bool food, bool drug)
        {
            using (var db = new DS2())
            {
                Client ifclient = db.clientList.FirstOrDefault(client => client.IDClient == myclient.IDClient);
                if (ifclient == null)
                {
                    throw new ArgumentNullException("Doesn't exist");
                }
                ifclient.Food = food;
                ifclient.Drug = drug;

                db.SaveChanges();
            }
        }

        //update client's address
        public void UpdateAddress(Client myclient, Address newaddress)
        {
            using (var db = new DS2())
            {
                

                Configuration myconfig = db.ConfigList.FirstOrDefault(config => config.idconfig == 1);

                if (myconfig == null)
                {
                    throw new ArgumentException("Problem : there is no config");

                }

                myconfig.AddressID += 1;
                newaddress.IDAddress = myconfig.AddressID;


               /* Address ifaddress = db.AddressList.FirstOrDefault(myaddress => myaddress.IDAddress == myclient.MyAddress.IDAddress);
                if (ifaddress != null)
                {
                    throw new ArgumentException("Address Already exist");
                }*/

                


                Client ifclient = db.clientList.FirstOrDefault(client => client.IDClient == myclient.IDClient);
                if (ifclient == null)
                {
                    throw new ArgumentNullException("Doesn't exist");
                }

                ifclient.MyAddress = newaddress;
                db.AddressList.Add(newaddress);
                db.SaveChanges();
            }
        }

        //update the name of the client
        public void UpdateClientName(Client myclient, String newfirstname, String newlastname)
        {
            using (var db = new DS2())
            {
                Client ifclient = db.clientList.FirstOrDefault(client => client.IDClient == myclient.IDClient);
                if (ifclient == null)
                {
                    throw new ArgumentNullException("Doesn't exist");
                }
                ifclient.FirstName = newfirstname;
                ifclient.LastName = newlastname;
                db.SaveChanges();
            }
        }

        public List<Client> GetDispoClient()
        {
            List<Client> mylist = new List<Client>();
            using (var db = new DS2())
            {
                foreach(Client myclient in db.clientList)
                {
                    if (myclient.AssignsF == false && myclient.AssignsD == false)
                        mylist.Add(myclient);
                }
            }
            return mylist;
        }
        #endregion


        #region distribution
        //add a distribution to the list
        public void AddDistribution(Distribution mydis, List<Address> listaddress)
        {
            using (var db = new DS2())
            {

                Configuration myconfig = db.ConfigList.FirstOrDefault(config => config.idconfig == 1);

                if (myconfig == null)
                {
                    throw new ArgumentException("Problem : there is no config");

                }

                myconfig.DistributionID += 1;
                mydis.IDDis = myconfig.DistributionID;

                Distribution ifdis = db.distributionList.FirstOrDefault(distribution => distribution.IDDis == mydis.IDDis);
                if (ifdis != null)
                {
                    throw new ArgumentException("Already exist");
                }
                // mydis.AllAddress = null;
                db.distributionList.Add(mydis);
                db.SaveChanges();

                foreach (Address myaddress in listaddress)
                {
                    AddAddressToDis(db.distributionList.ToList().ElementAt(db.distributionList.Count() - 1), myaddress);
                }

                // db.SaveChanges();

            }

        }
       

        //remove distribution ~we don't use it
        public void RemoveDistribution(Distribution mydis)
        {
            using (var db = new DS2())
            {


                Distribution ifdis = db.distributionList.FirstOrDefault(distribution => distribution.IDDis == mydis.IDDis);
                if (ifdis != null)
                {
                    throw new ArgumentException("Already exist");
                }
                db.distributionList.Remove(mydis);
                db.SaveChanges();
            }

        }

        //cancel distribution but not remove it
        public void UpdateCancelDis(Distribution mydis)
        {
            using (var db = new DS2())
            {
                Distribution ifdis = db.distributionList.FirstOrDefault(distribution => distribution.IDDis == mydis.IDDis);
                if (ifdis == null)
                {
                    throw new ArgumentNullException("Doesn't exist");
                }


                ifdis.Cancel = true;
                ifdis.DoneTime = DateTime.Today;
                db.SaveChanges();
            }




        }

        //indicated that the distribution is done
        public void UpdateDoneDis(Distribution mydis)
        {
            using (var db = new DS2())
            {
                Distribution ifdis = db.distributionList.FirstOrDefault(distribution => distribution.IDDis == mydis.IDDis);
                if (ifdis == null)
                {
                    throw new ArgumentNullException("Doesn't exist");
                }

                ifdis.Done = true;
                ifdis.DoneTime = DateTime.Now;
                db.SaveChanges();
            }


        }

        //update de Distribution (surtout lorsque fix = true, on rajoute autant de jour qu'il faut pour la prochaine distribution, done = false)
        public void UpdateDis(Distribution mydis)
        {
            using (var db = new DS2())
            {
                Distribution ifdis = db.distributionList.FirstOrDefault(distribution => distribution.IDDis == mydis.IDDis);
                if (ifdis == null)
                {
                    throw new ArgumentNullException("Doesn't exist");
                }


                Distribution newdis = new Distribution(ifdis);

                DeliveryMan mydman = new DeliveryMan();
                foreach (DeliveryMan dm in db.DManList.ToList())
                {
                    foreach (Distribution dis in dm.AllDistributions)
                        if (dis.IDDis == ifdis.IDDis)
                            mydman = db.DManList.FirstOrDefault(dman => dman.IDDMan == dm.IDDMan);

                }
                List<Address> myaddresslist = getAddressFromDis(ifdis);

                ifdis.DoneTime = DateTime.Now;
                ifdis.Done = true;


                db.SaveChanges();


                newdis.DisTime = newdis.DisTime.AddDays(ifdis.Interval);

                AddDistribution(newdis, myaddresslist);

                Assignation(newdis, mydman);
            }

        }

        //test pour voir si on peut rajouter un temps dans la list
        public void UpdateTimeinDis(Distribution mydis)
        {
            using (var db = new DS2())
            {
                Distribution ifdis = db.distributionList.FirstOrDefault(distribution => distribution.IDDis == mydis.IDDis);
                if (ifdis == null)
                {
                    throw new ArgumentNullException("Doesn't exist");
                }

                ifdis.DisTime = DateTime.Parse("09/05/2014");


                db.SaveChanges();
            }
        }


        //return distribution not done or not cancel by DMan
        public List<Distribution> DisNotDone(DeliveryMan dman)
        {
            List<Distribution> disnotdone = new List<Distribution>();

            using (var db = new DS2())
            {
                DeliveryMan mydman = db.DManList.FirstOrDefault(dm => dm.IDDMan == dman.IDDMan);
                if (mydman == null)
                {
                    throw new Exception("Doesn't exist");
                }
                foreach (Distribution dis in mydman.AllDistributions)
                {
                    if (dis.Done != true && dis.Cancel != true)
                        disnotdone.Add(dis);
                }

                return disnotdone;
            }
        }

        #endregion

        #region deliveryman

        //add a DeliveryMan to the list
        public void AddDMan(DeliveryMan mydman)
        {


            using (var db = new DS2())
            {


                Configuration myconfig = db.ConfigList.FirstOrDefault(config => config.idconfig == 1);

                if (myconfig == null)
                {
                    throw new ArgumentException("Problem : there is no config");

                }

                myconfig.DeliveryManID += 1;
                mydman.IDDMan = myconfig.DeliveryManID;

                DeliveryMan ifdman = db.DManList.FirstOrDefault(dman => dman.IDDMan == mydman.IDDMan);
                if (ifdman != null)
                {
                    throw new ArgumentException("Already exist");
                }

                db.DManList.Add(mydman);
                db.SaveChanges();
            }

        }

        //remove a DeliveryMan from the list
        public void RemoveDMan(DeliveryMan mydman)
        {
            using (var db = new DS2())
            {
                DeliveryMan ifdman = db.DManList.FirstOrDefault(deliverym => deliverym.IDDMan == mydman.IDDMan);
                if (ifdman == null)
                {
                    throw new ArgumentNullException("Doesn't exist");
                }

                db.DManList.Remove(ifdman);
                db.SaveChanges();
            }

        }

        //update the mail of a DeliveryMan
        public void UpdateDManMail(DeliveryMan mydman, String newmail)
        {

            using (var db = new DS2())
            {
                DeliveryMan ifdman = db.DManList.FirstOrDefault(deliverym => deliverym.IDDMan == mydman.IDDMan);
                if (ifdman == null)
                {
                    throw new ArgumentNullException("Doesn't exist");
                }
                ifdman.Mail = newmail;
                db.SaveChanges();
            }




        }

        //update the phone of a DeliveryMan
        public void UpdateDManPhone(DeliveryMan mydman, String newphone)
        {
            using (var db = new DS2())
            {
                DeliveryMan ifdman = db.DManList.FirstOrDefault(deliverym => deliverym.IDDMan == mydman.IDDMan);
                if (ifdman == null)
                {
                    throw new ArgumentNullException("Doesn't exist");
                }
                ifdman.Phone = newphone;
                db.SaveChanges();

            }



        }

        //update the name of the DeliveryMan
        public void UpdateDManName(DeliveryMan mydman, String newfirstname, String newlastname)
        {
            using (var db = new DS2())
            {
                DeliveryMan ifdman = db.DManList.FirstOrDefault(deliverym => deliverym.IDDMan == mydman.IDDMan);
                if (ifdman == null)
                {
                    throw new ArgumentNullException("Doesn't exist");
                }

                ifdman.FirstName = newfirstname;
                ifdman.LastName = newlastname;
                db.SaveChanges();


            }


        }







        #endregion

        #region config
        public void AddConfig(Configuration myconfig)
        {


            using (var db = new DS2())
            {


                if (db.ConfigList.Count() > 0)
                {
                    throw new Exception("You can't have more than one config");
                }

                db.ConfigList.Add(myconfig);
                db.SaveChanges();
            }

        }
        #endregion

        #region address
        //add address in the list
        public void AddAddress(Address myaddress)
        {


            using (var db = new DS2())
            {


                Configuration myconfig = db.ConfigList.FirstOrDefault(config => config.idconfig == 1);

                if (myconfig == null)
                {
                    throw new ArgumentException("Problem : there is no config");

                }

                myconfig.AddressID += 1;
                myaddress.IDAddress = myconfig.AddressID;

                Address ifadd = db.AddressList.FirstOrDefault(add => add.IDAddress == myaddress.IDAddress);
                if (ifadd != null)
                {
                    throw new ArgumentException("Already exist");
                }

                db.AddressList.Add(myaddress);
                db.SaveChanges();
            }

        }

        //remove an address from the list
        public void RemoveAddress(Address myaddress)
        {
            using (var db = new DS2())
            {

                Address ifadd = db.AddressList.FirstOrDefault(add => add.IDAddress == myaddress.IDAddress);
                if (ifadd == null)
                {
                    throw new ArgumentException("Doesn't exist");
                }

                db.AddressList.Remove(ifadd);
                db.SaveChanges();
            }

        }

        #endregion

        #region getlist
        public List<Client> GetClientList()
        {
            List<Client> mylist = new List<Client>();
            using (var db = new DS2())
            {
                mylist = db.clientList.ToList();
            }
            return mylist;
        }
        public List<Distribution> GetDisList()
        {
            List<Distribution> mylist = new List<Distribution>();
            using (var db = new DS2())
            {
                mylist = db.distributionList.ToList();
            }
            return mylist;
        }
        public List<DeliveryMan> GetDManList()
        {
            List<DeliveryMan> mylist = new List<DeliveryMan>();
            using (var db = new DS2())
            {
                mylist = db.DManList.ToList();
            }
            return mylist;
        }
        public List<Address> GetAddressList()
        {
            List<Address> mylist = new List<Address>();
            using (var db = new DS2())
            {
                mylist = db.AddressList.ToList();

            }
            return mylist;

        }
        #endregion


        #region other
        //add a distribution to the list of the delivery man
        public void Assignation(Distribution mydis, DeliveryMan mydman)
        {
            using (var db = new DS2())
            {
                Distribution ifdis = db.distributionList.FirstOrDefault(distribution => distribution.IDDis == mydis.IDDis);
                if (ifdis == null)
                {
                    throw new ArgumentNullException("Doesn't exist");
                }

                DeliveryMan ifdman = db.DManList.FirstOrDefault(deliverym => deliverym.IDDMan == mydman.IDDMan);
                if (ifdman == null)
                {
                    throw new ArgumentNullException("Doesn't exist");
                }

                ifdman.AllDistributions.Add(ifdis);

                db.SaveChanges();
            }

        }


        //add address to distribution
        public void AddAddressToDis(Distribution mydis, Address myaddress)
        {
            using (var db = new DS2())
            {
                Distribution ifdis = db.distributionList.FirstOrDefault(distribution => distribution.IDDis == mydis.IDDis);
                if (ifdis == null)
                {
                    throw new ArgumentNullException("Doesn't exist");
                }

                Address ifadd = db.AddressList.FirstOrDefault(address => address.IDAddress == myaddress.IDAddress);
                if (ifadd == null)
                {
                    throw new ArgumentNullException("Doesn't exist");
                }

                ifdis.AllAddress.Add(ifadd);

                db.SaveChanges();
            }
        }
        //get the list address from the distribution
        public List<Address> getAddressFromDis(Distribution dis)
        {
            List<Address> mylist = new List<Address>();
            using (var db = new DS2())
            {
                Distribution ifdis = db.distributionList.FirstOrDefault(mdis => mdis.IDDis == dis.IDDis);
                if (ifdis == null)
                {
                    throw new Exception("Doesn't exist");
                }

                foreach (Address add in ifdis.AllAddress)
                {
                    Address ifadd = db.AddressList.FirstOrDefault(myadd => myadd.IDAddress == add.IDAddress);

                    mylist.Add(ifadd);
                }

                return mylist;
            }
        }


        //return the address available
        public List<Address> AddressDispo(Boolean food, Boolean drug)
        {
            List<Address> addressdispo = new List<Address>();

            using (var db = new DS2())
            {

                foreach (Client myclient in db.clientList)
                {
                    Boolean flag = false;

                    if (food == true)
                    {


                        if (myclient.Food == true && myclient.AssignsF == false)
                        {
                            flag = true;

                        }
                    }
                    if (drug == true)
                    {


                        if (myclient.Drug == true && myclient.AssignsD == false)
                        {
                            flag = true;

                        }
                    }

                    if (flag == true)
                    {
                        Address address = db.AddressList.FirstOrDefault(add => add.IDAddress == myclient.MyAddress.IDAddress);

                        addressdispo.Add(address);
                    }

                }


                return addressdispo;

            }

        }

      

        //give AssignsF or AssignsD true
        public void ClientAssign(List<Address> myaddress, bool food, bool drug)
        {
            using (var db = new DS2())
            {
                foreach (Address address in myaddress)
                {
                    Address existaddress = db.AddressList.FirstOrDefault(add => add.IDAddress == address.IDAddress);
                    if (existaddress == null)
                    {
                        throw new Exception("Doesn't exist");
                    }

                    foreach (Client myclient in db.clientList)
                    {
                        if (myclient.MyAddress.IDAddress == existaddress.IDAddress)
                        {
                            if (food == true && myclient.Food == true)
                            {
                                myclient.AssignsF = true;
                                //db.SaveChanges();

                            }

                            if (drug == true && myclient.Drug == true)
                            {
                                myclient.AssignsD = true;
                                //db.SaveChanges();
                            }
                        }
                    }
                }

                db.SaveChanges();
            }


        }

        #endregion



        #region location
        //search for localisation
        public async Task<object> SearchLocation(String myaddress, object jsonObject)
        {
            string token = "735f8e90cb196c";
            string url = "https://eu1.locationiq.com/v1/search.php?key=" + token + "&q=" + myaddress + "&format=json";
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, content);
                    if (response != null)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<object>(jsonString);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        #endregion

        #region PDF
        //create a pdf for the deliveryman selected with all the distribution he has and will done
        public void PrintPDF(int index)
        {
            using (var db = new DS2())
            {
                int comp = 0;
                int compdis = 1;
                DeliveryMan tempdman = db.DManList.ToList().ElementAt(index);


                PdfDocument pdfdocument = new PdfDocument();
                PdfPage pdfPage = pdfdocument.AddPage();
                XGraphics graph = XGraphics.FromPdfPage(pdfPage);
                XFont font = new XFont("Verdana", 9, XFontStyle.Regular);
                XFont fontchiffre = new XFont("Verdana", 10, XFontStyle.Bold);
                XFont fonttitle = new XFont("Verdana", 12, XFontStyle.Underline);
                graph.DrawString("Summary for Delivery Man " + tempdman.FirstName + " " + tempdman.LastName + " " + tempdman.IDDMan.ToString()
                    , fonttitle, XBrushes.DarkRed, new XRect(200, comp, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                comp += 40;
                foreach (Distribution dis in tempdman.AllDistributions)
                {
                    graph.DrawString(compdis.ToString() + ") "
                          , fontchiffre, XBrushes.Black, new XRect(20, comp, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    if (dis.Done)
                    {
                        graph.DrawString("Distribution " + dis.IDDis.ToString() + " : Done"
                           , font, XBrushes.Black, new XRect(50, comp, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    }
                    else if (dis.Cancel)
                    {
                        graph.DrawString("Distribution " + dis.IDDis.ToString() + " : Cancel"
                           , font, XBrushes.Black, new XRect(50, comp, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    }
                    else
                    {
                        graph.DrawString("Distribution " + dis.IDDis.ToString() + " : Not finish"
                          , font, XBrushes.Black, new XRect(50, comp, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    }

                    comp += 15;
                    graph.DrawString("Date of Delivery : " + dis.DisTime.ToShortDateString() 
                          , font, XBrushes.Black, new XRect(50, comp, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    comp += 15;
                    graph.DrawString("Food : " + dis.Food.ToString() + " | Drug : " + dis.Drug.ToString() + " | Fix : " + dis.Fix.ToString() + " |  Interval : " + dis.Interval.ToString()
                          , font, XBrushes.Black, new XRect(50, comp, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    comp += 15;
                    graph.DrawString("Addresses : "
                         , fontchiffre, XBrushes.Black, new XRect(50, comp, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    comp += 15;

                    foreach (Address myadress in dis.AllAddress)
                    {
                        string temp = myadress.StringAddress();

                        graph.DrawString(temp
                             , font, XBrushes.Black, new XRect(60, comp, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        comp += 15;
                    }

                    comp += 20;
                    compdis += 1;

                }
                string date = DateTime.Now.ToString();
                string datetrue = "";
                for (int i = 0; i < date.Length; i++)
                {
                    if (date[i].ToString() == " " || date[i].ToString() == "/" || date[i].ToString() == ":")
                        datetrue += ".";
                    else
                        datetrue += date[i];
                }
                string filename = "C:/Users/Baroghel/Downloads/Summary" + tempdman.IDDMan.ToString() + datetrue + ".pdf";
                pdfdocument.Save(filename);
                Process.Start(filename);

            }
        }

        #endregion

       

        #region kmeans
        //create automatic distribution by the number of deliveryman
        [HandleProcessCorruptedStateExceptions]
        public async Task<Address[][]> Kmeans(Boolean food, Boolean drug)
        {
            List<Address> myaddresslist = AddressDispo(food, drug);
            int numClusters = GetDManList().Count;
            if (myaddresslist.Count == 0 || myaddresslist.Count < numClusters)
                return null;

            double[][] rawData = new double[myaddresslist.Count()][];
            int i = 0;
            Boolean flag ;

            foreach (Address address in myaddresslist)
            {

                //  Console.WriteLine(address.StringAddress());
                Object o = new object();
                flag = false;
                while (!flag)
                {
                    try
                    {
                        string streetname = address.StringAddress();
                        if (streetname.Contains("TelAviv"))
                            streetname = streetname.Replace("TelAviv", "Tel Aviv");


                        var x = await SearchLocation(streetname, o);
                        var jo1 = JArray.Parse(x.ToString());
                        //var jo = JObject.Parse(x.ToString());
                        //var joke = jo["value"][0]["joke"].ToString();

                       
                        rawData[i] = new double[] { Double.Parse(jo1[0]["lat"].ToString().Replace(".", ",")), Double.Parse(jo1[0]["lon"].ToString().Replace(".", ",")) };
                        flag = true;
                    }
                    catch (Newtonsoft.Json.JsonReaderException e)
                    {
                        continue;
                    }
                }
                i++;


            }




            int[] clustering = Cluster(rawData, numClusters);


            Address[][] listAddressdis = GetAddressFromCluster(rawData, clustering, numClusters, 1, myaddresslist);

            return listAddressdis;
        }


        #region helpKmeans
        //call to create the clusters
        //return an array of int, where the index is the same index from the raw data, and the value is the key of the cluster
        public int[] Cluster(double[][] rawData,
         int numClusters)
        {

            int[] clustering = InitClustering2(rawData, numClusters);
            return clustering;
        }



        //init means randomly
        public double[][] InitMeans(int DataLength, int numClusters)
        {
            MyZone myzone = new MyZone();
            Random random = new Random();
            double[][] newmeans = Allocate(numClusters, DataLength);
            for (int k = 0; k < numClusters; ++k)
            {
                newmeans[k][0] = random.NextDouble() * (myzone.LatMax - myzone.LatMin) + myzone.LatMin;
                newmeans[k][1] = random.NextDouble() * (myzone.LonMax - myzone.LonMin) + myzone.LonMin;
            }

            return newmeans;
        }

        //calculate new means form existing clusters by doing a moyenne of the lat and lon of each cluster
        public double[][] NewMeans(double[][] data, int numClusters, int[] clustering)
        {

            double[][] newmeans = Allocate(numClusters, data.Length);


            int[] clusterCounts = new int[numClusters];
            for (int i = 0; i < data.Length; ++i)
            {
               // int cluster = clustering[i]; //i->index data, -->key du cluster
                ++clusterCounts[clustering[i]];//cluster -> index du cluseter , -->nb qui augmente de 1 quand la data a sa key
            }


            for (int i = 0; i < data.Length; ++i)
            {
                int cluster = clustering[i];
                for (int j = 0; j < data[i].Length; ++j)
                    newmeans[cluster][j] += data[i][j]; // accumulate sum


            }

            for (int k = 0; k < newmeans.Length; ++k)
            {
                for (int j = 0; j < newmeans[k].Length; ++j)
                
                    newmeans[k][j] /= clusterCounts[k]; // danger of div by 0

                
            }
            return newmeans;
        }

        //verify if there is no cluster empty
        public bool CheckCluster(int DataLength, int numClusters, int[] clustering)
        {
            Boolean flag = false;
            int[] clusterCounts = new int[numClusters];
            for (int i = 0; i < DataLength; ++i)
            {
                int cluster = clustering[i]; //i->index data, -->key du cluster
                ++clusterCounts[cluster];//cluster -> index du cluseter , -->nb qui augmente de 1 quand la data a sa key
            }


            for (int k = 0; k < numClusters; ++k)
            {
                if (clusterCounts[k] != 0)
                {
                    flag = true;

                }

                else
                {
                    flag = false;
                    return flag;
                }

            }
            return flag;
        }

        
        //take the biggest distance from each means to the data, and add them
        public double SumVariation(double[][] data, int numClusters, int[] clustering)
        {
            //calculate the means of each cluster
            double[][] means = NewMeans(data, numClusters, clustering);

            double distances;
            double variation=0.0;

           
           for (int k = 0; k < numClusters; ++k)
            {
                distances = 0.0;
                for (int i = 0; i < data.Length; ++i)
                {
                    if (clustering[i] == k)
                    {
                        double newdistances = calculateDistance(data[i][0], data[i][1], means[k][0], means[k][1]);

                       // MessageBox.Show("distance " + i + " " + newdistances.ToString());
                        if (distances < newdistances) //find the biggest distance to the new means
                        {
                            distances = newdistances;
                        }
                    }
                }
                variation += distances; 
            }

            return variation;

        }

        //find the cluster by calculating the distance from the means to the data
        public int[] findClusters(double[][] data, double[][] means, int numClusters)
        {
            int[] clustering = new int[data.Length];
            double[] distances = new double[numClusters];
            for (int i = 0; i < data.Length; ++i)
            {
                for (int k = 0; k < numClusters; ++k) //calculate the distance from means to data
                    distances[k] = calculateDistance(data[i][0], data[i][1], means[k][0], means[k][1]);

                int newClusterID = MinIndex(distances);//choose the smallest distance and the index of the means is the cluster of the data
                clustering[i] = newClusterID;
            }
            return clustering;
        }



        //calculate the distance from a point(lat,lon) to point(lat,lon) --> Haversine formula
        public double calculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            var R = 6372.8; // In kilometers
            var dLat = toRadians(lat2 - lat1);
            var dLon = toRadians(lon2 - lon1);
            lat1 = toRadians(lat1);
            lat2 = toRadians(lat2);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            var c = 2 * Math.Asin(Math.Sqrt(a)/Math.Sqrt(1-a));
            return R * c;
        }

        public  double toRadians(double angle) //degree to radians
        {
            return Math.PI * angle / 180.0;
        }


        //calculate the clusters, verify if it is not empty, calculate the new means and sum up the variation, then take the best cluster
        private int[] InitClustering2(double[][] data,
         int numClusters)
        {
            int maxcount = numClusters * 10;
            int count = 0;
            int[] clustering = new int[data.Length];
            int[] newclustering = new int[data.Length];
            double[] distances = new double[numClusters];
            Boolean flag ;
            Boolean change ;

            List<KMeansHelp> myhelplist = new List<KMeansHelp>();
            while (myhelplist.Count == 0) //don't stop til it find something
            {
                count = 0;
                flag = false;
                while (!flag && count < maxcount) //don't stop til it didn't obtain maxcount
                {

                    count++;
                    change = true;
                    double[][] means = InitMeans(data.Length, numClusters); //give random means
                   

                    clustering = findClusters(data, means, numClusters);//find cluster with this new mean


                    flag = CheckCluster(data.Length, numClusters, clustering);//verify if there is no empty cluster

                    if (flag) 
                    {

                        while (change)//continue if the cluster has changed
                        {
                            count++;

                            double[][] newmeans = NewMeans(data, numClusters, clustering); //find the new means from the old clusters
                            newclustering = findClusters(data, newmeans, numClusters);//find the new clusters with those new means

                            flag = CheckCluster(data.Length, numClusters, newclustering);//verify there is no empty cluster
                            //if the new cluster is not in the good form, we restart it
                            if (flag)
                            {
                                for (int i = 0; i < data.Length; ++i)//verity if the new cluster changed or not
                                {

                                    if (newclustering[i] == clustering[i])
                                        change = false;//if it didn't change, we keep this cluster and means
                                    else//if it change, we recalculate new means
                                    {
                                        change = true;
                                        break;
                                    }
                                }
                                clustering = newclustering;
                                means = newmeans;
                                if (!change) //we keep cluster,mean and variation
                                {

                                    double variation = SumVariation(data, numClusters, clustering);
                                    myhelplist.Add(new KMeansHelp(means, variation));
                                }

                            }
                            else//there was a probleme with the new means and we kept the old means and old clusters and variation
                            {
                                double variation = SumVariation(data, numClusters, clustering);
                                myhelplist.Add(new KMeansHelp(means, variation));

                                break;
                            }

                            flag = false;
                        }
                    }

                }
            }

            double Minvariation = myhelplist.ElementAt(0).sumVariation;
            KMeansHelp winner = myhelplist.ElementAt(0);
            foreach(KMeansHelp mykmeans in myhelplist) //we check with variation is smaller, it will be our final solution
            {

                if (mykmeans.sumVariation < Minvariation)
                {
                    Minvariation = mykmeans.sumVariation;
                    winner = mykmeans;
                }

            }

            int[] finalclusters = findClusters(data, winner.means, numClusters); //recalculate the final cluster from the best variation and means


            return finalclusters;
        }

      


        //give place to means
        private double[][] Allocate(int numClusters,
          int numColumns)
        {
            double[][] result = new double[numClusters][];
            for (int k = 0; k < numClusters; ++k)
                result[k] = new double[numColumns];
            return result;
        }


       //find the most little distance and return the index of the means
        private int MinIndex(double[] distances)
        {
            int indexOfMin = 0;
            double smallDist = distances[0];
            for (int k = 0; k < distances.Length; ++k)
            {
                if (distances[k] < smallDist)
                {
                    smallDist = distances[k];
                    indexOfMin = k;
                }
            }
            return indexOfMin;
        }

       //return the address to each cluster
        Address[][] GetAddressFromCluster(double[][] data, int[] clustering,
         int numClusters, int decimals,List<Address> addressdispo)
        {
            Address[][] mylist = new Address[numClusters][];


            for (int k = 0; k < numClusters; ++k)
            {
                Address[] mylistaddress = new Address[data.Length];  //it's not the real size of the list
               
                for (int i = 0; i < data.Length; ++i)
                {
                    int clusterID = clustering[i];
                    if (clusterID != k) continue;

                    mylistaddress[i] = addressdispo.ElementAt(i); 
                   
                   
                    
                }

                


                    mylist[k] = mylistaddress;
            } // k

            return mylist;
        }
        #endregion

        #endregion

    }
}
