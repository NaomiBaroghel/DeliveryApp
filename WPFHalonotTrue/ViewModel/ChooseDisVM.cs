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
    public class ChooseDisVM : INotifyPropertyChanged
    {
        private ChooseDisUserControl choosedisUserControl;
        public ChooseDisModel CurrentModel { get; set; }
        public ReplaceUCCommand MyReplaceUCCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public List<string> ListName { get; set; }
        public List<string> ListDisID { get; set; }
        public List<Distribution> ListDis { get; set; }

        public ChooseDisVM(ChooseDisUserControl choosedisUserControl)
        {
            CurrentModel = new ChooseDisModel(this);
            this.choosedisUserControl = choosedisUserControl;
            MyReplaceUCCommand = new ReplaceUCCommand();
            MyReplaceUCCommand.ReplaceUserControl += Twobutton;
            ListName = new List<string>();
            ListName = GetName();
            ListDisID = new List<string>();
            ListDis = new List<Distribution>();
        }

        public void GetListDis()
        {
            try
            {
                DeliveryMan dMan = CurrentModel.getDman(choosedisUserControl.employeecombobox.SelectedIndex);
                ListDis = CurrentModel.DisNotDone(dMan);
                ListDisID = new List<string>();
                ListDisID = CurrentModel.GetNameDis(ListDis);
                choosedisUserControl.discombobox.ItemsSource = ListDisID;
                choosedisUserControl.discombobox.SelectedIndex = 0;


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Twobutton(string obj)
        {
            switch (obj)
            {
                case "Choose":
                    {
                        choosedisUserControl.secondgrid.Children.Clear();
                        choosedisUserControl.secondgrid.Children.Add(new DoneUserControl(ListDis.ElementAt(choosedisUserControl.discombobox.SelectedIndex), choosedisUserControl.employeecombobox.SelectedIndex, choosedisUserControl,this));

                       // ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                       // ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new DoneUserControl(ListDis.ElementAt(choosedisUserControl.discombobox.SelectedIndex), choosedisUserControl.employeecombobox.SelectedIndex));
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
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            return null;
        }

    }
}
