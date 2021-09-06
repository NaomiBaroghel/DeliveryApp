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
    public class ChooseClientModel
    {
        private ChooseClientVM chooseClientVM;
        BLImp blimp { get; set; }

        public ChooseClientModel(ChooseClientVM chooseclientVM)
        {
            this.chooseClientVM = chooseclientVM;
            blimp = new BLImp();
        }

        //return list of the available client name
        public List<string> GetNameClient()
        {

            try
            {
                List<string> mylist = new List<string>();
                foreach (Client cl in blimp.GetDispoClient())
                {
                    string temp = cl.FirstName + " " + cl.LastName;
                    mylist.Add(temp);
                }

                return mylist;
            }
            catch(Exception e)
            {
                throw e;
            }
           
        }
    }
}
