using BE;
using System;
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
    class DoneVM : INotifyPropertyChanged
    {
        public DoneUserControl myuc { get; set; }
        public ChooseDisUserControl choosedisuc;
        public ChooseDisVM choosedisvm;
        public ReplaceUCCommand MyReplaceUCCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public DoneModel CurrentModel { get; set; }
        Distribution mydis { get; set; }
        public string MyName { get; set; }
        public string Date { get; set; }
        public string Food { get; set; }
        public string Drug { get; set; }
        public string Fix { get; set; }
        public string Interval { get; set; }
        List<Address> ListAddress { get; set; }
        public List<string> ListAddressChoosenName { get;  set; }

        public DoneVM(View.DoneUserControl doneUC, Distribution dis,int index, ChooseDisUserControl choosedisUserControl, ChooseDisVM chooseDisVM)
        {
            myuc = doneUC;
            choosedisuc = choosedisUserControl;
            choosedisvm = chooseDisVM;
        MyReplaceUCCommand = new ReplaceUCCommand();
            MyReplaceUCCommand.ReplaceUserControl += Threebutton;
            CurrentModel = new DoneModel(this);
            mydis = dis;
            DeliveryMan mydman = getDman(index);
            MyName = mydman.FirstName + " " + mydman.LastName;

            myuc.done.IsEnabled = true;
            myuc.canceldis.IsEnabled = true;
            Date = mydis.DisTime.ToShortDateString();
            if (mydis.DisTime > DateTime.Today)
                doneUC.done.IsEnabled = false;
          
            if (mydis.Food)
            {
                Food = "Yes";
            }
            else
                Food = "No";

            if (mydis.Drug)
            {
                Drug = "Yes";

            }
            else
                Drug = "No";
            if (mydis.Fix)
            {
                Fix = "Yes";
                Interval = mydis.Interval.ToString();
            }
            else
            {
                Fix = "No";
                Interval = "0";
            }

            ListAddress = getAddressFromDis(mydis);
            ListAddressChoosenName= GetAddressChoosenName(ListAddress);




        }

        
        private DeliveryMan getDman(int index)
        {
            try
            {
               return CurrentModel.getDman(index);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return null;
        }

        public List<Address> getAddressFromDis(Distribution dis)
        {
            try
            {
                return CurrentModel.getAddressFromDis(dis);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return null;
        }

        public List<string> GetAddressChoosenName(List<Address> addresses)
        {
           List<string> mylist = new List<string>();
            if (addresses.Count() > 0)
            {
                foreach (Address myadress in addresses)
                {
                    string temp = myadress.StringAddress(); 
                    mylist.Add(temp);
                   

                }
            }
            return mylist;

        }
        public void Threebutton(string obj)
        {
            switch(obj)
            {
                case "Done":
                    {
                        Boolean flag = true;
                        try
                        {
                            CurrentModel.Done(mydis);

                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            flag = false;

                        }

                        if (flag)
                        {
                            MessageBox.Show("Distribution marked as done", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            choosedisvm.GetListDis();
                            choosedisuc.secondgrid.Children.Clear();
                            choosedisuc.secondgrid.Children.Add(new DoneUserControl());

                            // ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                            // ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuDistributionUserControl());

                        }
                        break;
                    }
                case "Cancel Distribution":
                    {
                        Boolean flag = true;
                        try
                        {
                            CurrentModel.CancdelDis(mydis);

                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            flag = false;

                        }

                        if (flag)
                        {
                            MessageBox.Show("Distribution canceled", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            choosedisvm.GetListDis();
                            choosedisuc.secondgrid.Children.Clear();
                            choosedisuc.secondgrid.Children.Add(new DoneUserControl());

                            // ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                            // ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuDistributionUserControl());

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

        
    }
}
