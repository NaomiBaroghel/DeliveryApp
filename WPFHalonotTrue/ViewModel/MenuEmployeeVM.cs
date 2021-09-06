using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFHalonotTrue.Command;
using WPFHalonotTrue.View;

namespace WPFHalonotTrue.ViewModel
{
    class MenuEmployeeVM : INotifyPropertyChanged
    {
        public ReplaceUCCommand MyReplaceUCCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public MenuEmployeeVM(View.MenuEmployeeUserControl menuUC)
        {
            MyReplaceUCCommand = new ReplaceUCCommand();
            MyReplaceUCCommand.ReplaceUserControl += Threebutton;


        }

        public void Threebutton(string obj)
        {
            switch(obj)
            {
                case "Create":
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new EmployeeUserControl());
                        break;
                    }
                case "Update":
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new ChooseDManUserControl());
                        break;
                    }
                case "PDF":
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new PDFUserControl());
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

        
    }
}
