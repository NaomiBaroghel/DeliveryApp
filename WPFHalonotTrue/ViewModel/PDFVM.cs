using BE;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPFHalonotTrue.Command;
using WPFHalonotTrue.Model;
using WPFHalonotTrue.View;

namespace WPFHalonotTrue.ViewModel
{
    class PDFVM : INotifyPropertyChanged
    {
        private PDFUserControl PDFUserControl;
        public PDFModel CurrentModel { get; set; }
        public ReplaceUCCommand MyReplaceUCCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public List<string> ListName { get; set; }

        public PDFVM(PDFUserControl pdfUserControl)
        {
            CurrentModel = new PDFModel(this);
            this.PDFUserControl = pdfUserControl;
            MyReplaceUCCommand = new ReplaceUCCommand();
            MyReplaceUCCommand.ReplaceUserControl += Twobutton;
            ListName = new List<string>();
            ListName = GetName();
        }

        private void Twobutton(string obj)
        {
            switch (obj)
            {
                case "PDF":
                    {
                        Boolean flag = true;
                        try
                        {

                            CurrentModel.printPDF(PDFUserControl.employeecombobox.SelectedIndex);


                        }
                        catch(Exception e)
                        {
                            flag = false;
                            MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                        }

                        if(flag)
                        {
                            MessageBox.Show("Print with success !", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                            ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuUserControl());

                        }
                        break;
                    }
               
                case "Cancel":
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuUserControl());
                        break;
                    }
            }
        }

        public List<string> GetName()
        {
            try
            {
                return CurrentModel.GetName();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            return null;
        }

    }
}
