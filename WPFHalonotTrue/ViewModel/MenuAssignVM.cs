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
    class MenuAssignVM : INotifyPropertyChanged
    {
        public ReplaceUCCommand MyReplaceUCCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public MenuAssignVM(View.MenuAssignUserControl menuUC)
        {
            MyReplaceUCCommand = new ReplaceUCCommand();
            MyReplaceUCCommand.ReplaceUserControl += Twobutton;


        }

        public void Twobutton(string obj)
        {
            switch(obj)
            {
                case "Manuel":
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new DistributionUserControl());
                        break;
                    }
                case "Auto":
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new KMeansUserControl());
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
