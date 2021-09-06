
using BE;
using BL;
using DAL;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Runtime.CompilerServices;
using System.IO;
//using KMeansPackage.K_Means;

namespace FrameworkTest
{
    class Program
    {
        static async Task Main(string[] args)
        {


            BLImp blimp = new BLImp();
            DalImp dalimp = new DalImp();



            Console.WriteLine("Begin");


            // dalimp.AddConfig(new Configuration());

            DeliveryMan Dman = new DeliveryMan("Mark", "Thomas", "mark.thomas@exemple.com", "0586839402");
            DeliveryMan Dman2 = new DeliveryMan("Paul", "Levy", "paul.levy@exemple.com", "0567483657");
            DeliveryMan Dman3 = new DeliveryMan("Erik", "Blue", "eriiki@exemple.com", "0587645321");
            //  blimp.AddDMan(Dman);
            //  blimp.AddDMan(Dman2);
            // blimp.AddDMan(Dman3);
            //   blimp.AddDMan(Dman);
            /*  //  dalimp.AddDMan(Dman);
                Console.WriteLine("apres blimp");
                foreach (DeliveryMan myDman in dalimp.myds2.DManList)
                {

                  Console.WriteLine(myDman.FirstName + " " + myDman.LastName + " " + myDman.IDDMan.ToString());

                }
              if (dalimp.myds2.DManList.Count() > 0)
                  Console.WriteLine("true");
              else
                  Console.WriteLine("false");*/

            // food, drug, fix, interval -> time = today, address = null, done = false, cancel = false
            /* Distribution mydis = new Distribution(true, false, false, 0);*/
            // dalimp.AddDistributionTest(mydis);
            //  blimp.AddDistribution(mydis);

            /* Distribution dis = dalimp.myds2.distributionList.FirstOrDefault(mydisss => mydisss.IDDis == 200000001);
             DeliveryMan mydman = dalimp.myds2.DManList.FirstOrDefault(dman => dman.IDDMan == 300000001);
             DeliveryMan mydman2 = dalimp.myds2.DManList.FirstOrDefault(dman => dman.IDDMan == 300000002);*/

            //  Address myaddress = new Address(26, "Najara", MyEnum.City.Jerusalem, MyEnum.Neighborhood.South);

            //Address myadd = dalimp.myds2.AddressList.FirstOrDefault(add => add.IDAddress == 400000001);

            //   dalimp.AddAddress(myaddress);
            //   dalimp.AddAddressToDis(dis, myadd);
            /*  foreach (Address myadddd in dis.AllAddress)
              {
                  Console.WriteLine(myadddd.IDAddress.ToString());
                  Console.WriteLine(myadddd.StreeName.ToString());

              }*/

            //blimp.RemoveDMan(mydman2);
            //  blimp.Assignation(dis, mydman);
            //   blimp.UpdateDManName(mydman, "Mark", "ggggggg");


            /*

            DeliveryMan mydman3 = dalimp.myds2.DManList.ToList().FirstOrDefault(dman => dman.IDDMan == 300000001);
            Console.WriteLine(mydman3.FirstName + " " + mydman3.LastName);

            // dalimp.UpdateTimeinDis(dis);

             foreach (Distribution mydis3 in dalimp.myds2.distributionList)
             {
                 Console.WriteLine(mydis3.IDDis.ToString());
                 Console.WriteLine(mydis3.DisTime.ToString());

             }*/



            Client myclient1 = new Client("Erik", "Francois", "erikfrancois@gmail.com", "0567483947", new Address(14, "Ezel", MyEnum.City.Netanya), true, false); //food
            Client myclient2 = new Client("Barbara", "Elis", "barbaraelis@gmail.com", "0574657493", new Address(20, "Pinsker", MyEnum.City.Netanya), true, true); // food drug
            Client myclient3 = new Client("Paul", "Yen", "yenni@gmail.com", "0598463547", new Address(10, "Geva", MyEnum.City.Netanya), false, true); // drug
            Client myclient4 = new Client("George", "Rou", "rougeorge@gmail.com", "0572435133", new Address(12, "Jerusalem", MyEnum.City.Ashdod), true, false); //food
            Client myclient5 = new Client("Charlotte", "Muli", "charlotte56@gmail.com", "0543721865", new Address(10, "Kremnitzky", MyEnum.City.TelAviv), false, true); //drug
            Client myclient6 = new Client("Yael", "Martin", "yayou@gmail.com", "0598352415", new Address(1, "Hertsel", MyEnum.City.Ashdod), false, true); //drug

            Client myclient7 = new Client("Abel", "Coon", "bibi@gmail.com", "0599856453", new Address(25, "Caro Yosef", MyEnum.City.Jerusalem), true, true); //food drug
            Client myclient8 = new Client("Juliette", "Alpeh", "juju@gmail.com", "0597463524", new Address(8, "Usishkin", MyEnum.City.Jerusalem), false, true); //drug
            Client myclient9 = new Client("Karen", "Martin", "karenmart@gmail.com", "0595463820", new Address(55, "Alon Igal", MyEnum.City.TelAviv), true, true); // food drug
            Client myclient10 = new Client("Liu", "Pen", "peni@gmail.com", "0590754635", new Address(20, "Lillenblum", MyEnum.City.TelAviv), true, false); //food
            Client myclient11 = new Client("Quentin", "Papou", "poupou@gmail.com", "0597645382", new Address(11, "Frishman", MyEnum.City.TelAviv), false, true); //drug

            /*  blimp.AddClient(myclient1);
              blimp.AddClient(myclient2);
              blimp.AddClient(myclient3);
              blimp.AddClient(myclient4);
              blimp.AddClient(myclient5);
              blimp.AddClient(myclient6);
              blimp.AddClient(myclient7);
              blimp.AddClient(myclient8);
              blimp.AddClient(myclient9);
              blimp.AddClient(myclient10);
              blimp.AddClient(myclient11);*/


            // Object o = new object();
            //https://locationiq.com/
            //קוד זה שייך ל 
            // DAL
            //
            // var x = await dalimp.SearchLocation(new Address(2, "Ben Yehouda", MyEnum.City.Jerusalem,MyEnum.Neighborhood.West), o) ;
            // var jo1 = JArray.Parse(x.ToString());
            // var jo = JObject.Parse(x.ToString());
            //var joke = jo["value"][0]["joke"].ToString();
            // Console.WriteLine(jo1[0]["lat"].ToString());
            // Console.WriteLine(jo1[0]["lon"].ToString());

           



            //string fullPathToSound = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"\WPFHalonotTrue\Music\BreezMusic.wav");
            Uri fullPathToSound = new Uri("/WPFHalonotTrue/Music", UriKind.RelativeOrAbsolute);

            Console.WriteLine(fullPathToSound.ToString());




            Console.WriteLine("End");


            Console.ReadLine();



        }

        
    }


}

