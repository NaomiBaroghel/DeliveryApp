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
    public class ChooseModel
    {
        private ChooseDManVM chooseDManVM;
        BLImp blimp { get; set; }
        public ChooseModel(ChooseDManVM chooseDManVM)
        {
            this.chooseDManVM = chooseDManVM;
            blimp = new BLImp();
        }


        //return all the name of all the delivery man in the list
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
    }
}
