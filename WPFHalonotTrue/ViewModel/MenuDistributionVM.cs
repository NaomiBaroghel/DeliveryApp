using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPFHalonotTrue.Command;
using WPFHalonotTrue.View;

namespace WPFHalonotTrue.ViewModel
{
    class MenuDistributionVM : INotifyPropertyChanged
    {
        public MenuDistributionUserControl myuc;
        public ReplaceUCCommand MyReplaceUCCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public MenuDistributionVM(View.MenuDistributionUserControl menuUC)
        {
            myuc = menuUC;
            MyReplaceUCCommand = new ReplaceUCCommand();
            MyReplaceUCCommand.ReplaceUserControl += Threebutton;


        }

        public void Threebutton(string obj)
        {
            switch(obj)
            {
                case "Create":
                    {
                        myuc.creategrid.Children.Clear();
                        myuc.creategrid.Children.Add(new MenuAssignUserControl());
                        //((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        //((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuAssignUserControl());
                        break;
                    }
                case "Finalize":
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new ChooseDisUserControl());
                        break;
                    }
                case "Chart":
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new ChartUserControl());
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
