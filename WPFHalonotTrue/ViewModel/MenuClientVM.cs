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
    class MenuClientVM : INotifyPropertyChanged
    {
        public ReplaceUCCommand MyReplaceUCCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public MenuClientVM(View.MenuClientUserControl menuUC)
        {
            MyReplaceUCCommand = new ReplaceUCCommand();
            MyReplaceUCCommand.ReplaceUserControl += Twobutton;


        }

        public void Twobutton(string obj)
        {
            switch(obj)
            {
                case "Create":
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new ClientUserControl());
                        break;
                    }
                case "Update":
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new ChooseClientUserControl());
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
