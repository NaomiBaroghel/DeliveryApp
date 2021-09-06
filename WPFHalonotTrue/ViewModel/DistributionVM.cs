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
    class DistributionVM : INotifyPropertyChanged
    {
        public ReplaceUCCommand MyReplaceUCCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public DistributionModel CurrentModel { get; set; }
        public DistributionUserControl myUC { get; set; }
        public Distribution mydis { get; set; }
        public DeliveryMan mydman { get; set; }
        public List<string> ListName { get; set; }
        public List<Address> ListAddressDispo { get; set; }
        public List<string> ListAddressDispoName { get; set; }
        public List<Address> ListAddressChoosen { get; set; }
        public List<string> ListAddressChoosenName { get; set; }


        public DateTime mydate { get; set; }
        public Boolean food { get; set; }
        public Boolean drug { get; set; }
        public Boolean fix { get; set; }
        public int interval { get; set; }




        public DistributionVM(View.DistributionUserControl disUC)
        {
            myUC = disUC;
            myUC.pickdate.SelectedDate = DateTime.Today;
            myUC.pickdate.DisplayDateStart = DateTime.Today;

            MyReplaceUCCommand = new ReplaceUCCommand();
            MyReplaceUCCommand.ReplaceUserControl += Fivebutton;
            mydis = new Distribution();
            mydman = new DeliveryMan();
            CurrentModel = new DistributionModel(this);
            ListName = GetName();
            ListAddressDispo = new List<Address>();
            ListAddressDispoName = new List<string>();
            ListAddressChoosen = new List<Address>();
            ListAddressChoosenName = new List<string>();
            mydate = new DateTime();
            mydate = DateTime.Today;
            food = false;
            drug = false;
            fix = true;
            interval = 1;


        }

        #region getname of

        //get list of name of the deliverymans
        private List<string> GetName()
        {
            try
            {
                return CurrentModel.GetName();
            }
            catch (Exception e)
            {
                MessageBox.Show("You must choose a Delivery Man", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return null;
        }

        //get the name of the address available
        public void GetAddressDispoName(List<Address> addresses)
        {
            ListAddressDispoName = new List<string>();
            if (addresses.Count() > 0)
            {
                foreach (Address myadress in addresses)
                {
                    string temp = myadress.StringAddress();
                    ListAddressDispoName.Add(temp);

                }
                myUC.addressdispo.ItemsSource = ListAddressDispoName;
            }

        }

        //get the name of the chosen address
        public void GetAddressChoosenName(List<Address> addresses)
        {
            ListAddressChoosenName = new List<string>();
            if (addresses.Count() > 0)
            {
                foreach (Address myadress in addresses)
                {
                    string temp = myadress.StringAddress();
                    ListAddressChoosenName.Add(temp);

                }
                myUC.addresschoisies.ItemsSource = ListAddressChoosenName;
            }

        }
        #endregion

        #region check uncheck
        //get the addresses available upon condition (->food or drug)


        public void CheckFood()
        {

            

            try
            {
                if (myUC.Drug.IsChecked == true)
                {

                    ListAddressDispo = CurrentModel.AddressDispo(true, true);
                    GetAddressDispoName(ListAddressDispo);
                    ListAddressChoosen = new List<Address>();
                    GetAddressChoosenName(ListAddressChoosen);

                }
                else
                {

                    ListAddressDispo = CurrentModel.AddressDispo(true, false);
                    GetAddressDispoName(ListAddressDispo);
                    ListAddressChoosen = new List<Address>();
                    GetAddressChoosenName(ListAddressChoosen);

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void UnCheckFood()
        {
            try
            {
                if (myUC.Drug.IsChecked == true)
                {
                    ListAddressDispo = CurrentModel.AddressDispo(false, true);
                    GetAddressDispoName(ListAddressDispo);
                    ListAddressChoosen = new List<Address>();
                    GetAddressChoosenName(ListAddressChoosen);
                }
                else
                {
                    myUC.addressdispo.ItemsSource = string.Empty;
                    myUC.addresschoisies.ItemsSource = string.Empty;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void CheckDrug()
        {
            

            try
            {
                if (myUC.Food.IsChecked == true)
                {
                    ListAddressDispo = CurrentModel.AddressDispo(true, true);
                    GetAddressDispoName(ListAddressDispo);
                    ListAddressChoosen = new List<Address>();
                    GetAddressChoosenName(ListAddressChoosen);
                }
                else
                {
                    ListAddressDispo = CurrentModel.AddressDispo(false, true);
                    GetAddressDispoName(ListAddressDispo);
                    ListAddressChoosen = new List<Address>();
                    GetAddressChoosenName(ListAddressChoosen);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void UnCheckDrug()
        {
            try
            {
                if (myUC.Food.IsChecked == true)
                {
                    ListAddressDispo = CurrentModel.AddressDispo(true, false);
                    GetAddressDispoName(ListAddressDispo);
                    ListAddressChoosen = new List<Address>();
                    GetAddressChoosenName(ListAddressChoosen);
                }
                else
                {

                    myUC.addressdispo.ItemsSource = string.Empty;
                    myUC.addresschoisies.ItemsSource = string.Empty;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        #region button
        public void Fivebutton(string obj)
        {
            switch (obj)
            {
                case "Create":
                    {
                        Boolean flag = true;

                        mydate = (DateTime)myUC.pickdate.SelectedDate.Value;
                        mydis.DisTime = mydate;
                        mydis.Drug = drug;
                        mydis.Food = food;
                        mydis.Fix = fix;
                        if (fix)
                        {
                            mydis.Interval = interval;
                        }
                        else
                            mydis.Interval = 0;

                       try
                       {
                            if (myUC.employee.SelectedIndex >= 0)
                            {
                                mydman = CurrentModel.getDman(myUC.employee.SelectedIndex);
                                CurrentModel.addDis(mydis, ListAddressChoosen);
                                CurrentModel.Assign(mydis, mydman);
                            }
                            else
                                throw new ArgumentException("You need to choose a Delivery Man");



                        }
                        catch (Exception e)
                        {
                            flag = false;
                            MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                        }

                        if (flag)
                        {
                            MessageBox.Show("Distribution create and assign with success !", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                            ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                            ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuUserControl());
                        }
                        break;
                    }
                case "Add":
                    {
                        int myindex = myUC.addressdispo.SelectedIndex;

                        //add the new address to the choosen address
                        ListAddressChoosen.Add(ListAddressDispo.ElementAt(myindex));
                        GetAddressChoosenName(ListAddressChoosen);
                       


                        //remove the address from the address available
                        ListAddressDispo.RemoveAt(myindex);
                        GetAddressDispoName(ListAddressDispo);
                       


                        //remise à zero
                        myUC.addressdispo.ItemsSource = ListAddressDispoName;
                        myUC.addressdispo.SelectedIndex = -1;
                        myUC.addresschoisies.ItemsSource = ListAddressChoosenName;
                        myUC.addresschoisies.SelectedIndex = 0;
                        break;
                    }
                case "Remove":
                    {
                        int myindex = myUC.addresschoisies.SelectedIndex;

                        //add the removed address to the available address
                        ListAddressDispo.Add(ListAddressChoosen.ElementAt(myindex));
                        GetAddressDispoName(ListAddressDispo);


                        //remove the address from the choosen address
                        ListAddressChoosen.RemoveAt(myindex);
                        GetAddressChoosenName(ListAddressChoosen);


                        //remise à zero
                        myUC.addressdispo.ItemsSource = ListAddressDispoName;
                        myUC.addressdispo.SelectedIndex = -1;
                        myUC.addresschoisies.ItemsSource = ListAddressChoosenName;
                        myUC.addresschoisies.SelectedIndex = -1;
                        break;
                    }
                
                case "Reset":
                    {

                        ListAddressDispo = new List<Address>();
                        ListAddressDispoName = new List<string>();
                        ListAddressChoosen = new List<Address>();
                        ListAddressChoosenName = new List<string>();


                        mydate = DateTime.Today;
                        mydman = new DeliveryMan();
                        food = false;
                        drug = false;
                        fix = true;
                        interval = 1;

                        myUC.pickdate.SelectedDate = DateTime.Today;
                        myUC.addresschoisies.ItemsSource = ListAddressChoosenName;
                        myUC.addresschoisies.SelectedIndex = -1;
                        myUC.addressdispo.ItemsSource = ListAddressDispoName;
                        myUC.addressdispo.SelectedIndex = -1;
                        myUC.employee.SelectedIndex = -1;
                        myUC.Food.IsChecked = false;
                        myUC.Drug.IsChecked = false;
                        myUC.Fix.IsChecked = true;
                        myUC.Interval.Text = "1";
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

        #endregion


    }
}
