using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPFHalonotTrue.ViewModel;

namespace WPFHalonotTrue.Model
{
    class PDFModel
    {
        private PDFVM PdfVM;
        BLImp blimp { get; set; }
        public PDFModel(PDFVM pdfVM)
        {
            this.PdfVM = pdfVM;
            blimp = new BLImp();
        }


        //get list of all the name of the delivery men
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

        //return a specific delivery man
        public DeliveryMan GetDman(int index)
        {

            try
            {
                return blimp.GetDManList().ElementAt(index);
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        //print pdf of a specific delivery man
        internal void printPDF(int index)
        {
            try
            {
                blimp.printPDF(index);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
