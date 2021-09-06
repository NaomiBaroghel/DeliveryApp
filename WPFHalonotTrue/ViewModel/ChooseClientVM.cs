using BE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFHalonotTrue.Command;
using WPFHalonotTrue.Model;
using WPFHalonotTrue.View;

namespace WPFHalonotTrue.ViewModel
{
    public class ChooseClientVM : INotifyPropertyChanged
    {
        private ChooseClientUserControl chooseClientUserControl;
        public ChooseClientModel CurrentModel { get; set; }
        public ReplaceUCCommand MyReplaceUCCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public List<string> ListName { get; set; }

        public ChooseClientVM(ChooseClientUserControl chooseclientUserControl)
        {
            CurrentModel = new ChooseClientModel(this);
            this.chooseClientUserControl = chooseclientUserControl;
            MyReplaceUCCommand = new ReplaceUCCommand();
            MyReplaceUCCommand.ReplaceUserControl += Twobutton;
            ListName = new List<string>();
            ListName = GetName();
        }

        private void Twobutton(string obj)
        {
            switch (obj)
            {
                case "Choose":
                    {
                        chooseClientUserControl.secondgrid.Children.Clear();
                        chooseClientUserControl.secondgrid.Children.Add(new UpdateClientUserControl(chooseClientUserControl.clientcombobox.SelectedIndex, chooseClientUserControl, this));
                        
                       // ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                       // ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new UpdateClientUserControl(chooseClientUserControl.clientcombobox.SelectedIndex));
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
                return CurrentModel.GetNameClient();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            return null;
        }

    }
}
