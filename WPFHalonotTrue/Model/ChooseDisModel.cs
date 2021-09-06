using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFHalonotTrue.ViewModel;

namespace WPFHalonotTrue.Model
{
    public class ChooseDisModel
    {
        private ChooseDisVM choosedisVM;
        BLImp blimp { get; set; }
        public ChooseDisModel(ChooseDisVM chooseDisVM)
        {
            this.choosedisVM = chooseDisVM;
            blimp = new BLImp();
        }

        //return the ID of the distribution of a specific delivery man
        public List<string> GetNameDis(List<Distribution> mydis)
        {
            try
            {

                List<string> mylist = new List<string>();
                foreach (Distribution dis in mydis)
                {
                    string temp = dis.IDDis.ToString();
                    mylist.Add(temp);
                }

                return mylist;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        //return the list of the name of all the delivery man
        public List<string> GetName()
        {

            try
            {
                List<string> mylist = new List<string>();
                foreach (DeliveryMan dm in blimp.GetDManList())
                {
                    string temp = dm.FirstName + " " + dm.LastName;
                    mylist.Add(temp);
                }

                return mylist;

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        //return the deliveryman choosen
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

        //return list of the distribution not done of a delivery man
        public List<Distribution> DisNotDone(DeliveryMan dman)
        {
            try
            {
                return blimp.DisNotDone(dman);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
