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
    public class ChooseDManVM : INotifyPropertyChanged
    {
        private ChooseDManUserControl chooseDManUserControl;
        public ChooseModel CurrentModel { get; set; }
        public ReplaceUCCommand MyReplaceUCCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public List<string> ListName { get; set; }

        public ChooseDManVM(ChooseDManUserControl chooseDManUserControl)
        {
            CurrentModel = new ChooseModel(this);
            this.chooseDManUserControl = chooseDManUserControl;
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
                        // ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        // ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new UpdateEmployeeUserControl(chooseDManUserControl.employeecombobox.SelectedIndex));
                        chooseDManUserControl.secondgrid.Children.Clear();
                        chooseDManUserControl.secondgrid.Children.Add(new UpdateEmployeeUserControl(chooseDManUserControl.employeecombobox.SelectedIndex, chooseDManUserControl,this));
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
