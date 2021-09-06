using BE;
using BL;
using System;
using System.Linq;

namespace ProjetHalonot
{
    class Program
    {
        //test
        static void Main(string[] args)
        {
            BLImp blimp = new BLImp();
            
            /* //ce qu'il faut ecrire lorsqu'on veut trouver la location dans Model
             BLImp reader = new BLImp();
             Object o = new object();
             Address myaddress = new Address(10, "Rehov Gueva", MyEnum.City.Natanya,MyEnum.Neighborhood.North);

             var x = await reader.SearchLocation(myaddress, o);
             var jo1 = JArray.Parse(x.ToString());
             // var jo = JObject.Parse(x.ToString());
             //var joke = jo["value"][0]["joke"].ToString();

             Console.WriteLine(jo1[0]["lat"].ToString());
             Console.WriteLine(jo1[0]["lon"].ToString());*/

            Console.WriteLine("Begin");

            DeliveryMan Dman = new DeliveryMan("Mark", "Thomas", "mark.thomas@exemple.com", "0586839402");
            blimp.AddDMan(Dman);
            if (blimp.GetDManList().Count() > 0)
                Console.WriteLine("true");
            else
                Console.WriteLine("false");
            foreach (DeliveryMan myDman in blimp.GetDManList())
            {
                Console.WriteLine(myDman.FirstName + " " + myDman.LastName);
            }
        }
    }
}
