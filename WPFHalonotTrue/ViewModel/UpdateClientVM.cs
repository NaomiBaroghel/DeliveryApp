using BE;
using Microsoft.Maps.MapControl.WPF;
using Newtonsoft.Json.Linq;
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
    class UpdateClientVM : INotifyPropertyChanged
    {
        public UpdateClientUserControl updateClientUserControl;
        public ChooseClientUserControl clientuc;
        public ChooseClientVM clientvm;
        public UpdateClientModel ucmodel { get; set; }
        public Client myclient { get; set; }
        public string FN { get; set; }
        public string LN { get; set; }
        public string DMMail { get; set; }
        public string DMPhone { get; set; }
        public string Address { get; set; }
        public Address myoldaddress { get; set; }
        public bool food { get; set; }
        public bool drug { get; set; }

        List<string> longlat { get; set; }

        MyZone myzone { get; set; }

        public ReplaceUCCommand MyReplaceUCCommand { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;

        public UpdateClientVM(UpdateClientUserControl updateclientUserControl, int index, ChooseClientUserControl chooseClientUserControl, ChooseClientVM chooseClientVM)
        {
            this.updateClientUserControl = updateclientUserControl;
            clientuc = chooseClientUserControl;
            clientvm = chooseClientVM;
            ucmodel = new UpdateClientModel(this);
            myclient = new Client();
            longlat = new List<string>();
            myzone = new MyZone();


            updateclientUserControl.update.IsEnabled = true;
            updateclientUserControl.remove.IsEnabled = true;

            try
            {
                myclient = ucmodel.getClient(index);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            FN = myclient.FirstName;
            LN = myclient.LastName;
            DMMail = myclient.Mail;
            DMPhone = myclient.Phone;
            food = myclient.Food;
            drug = myclient.Drug;

            try
            {
                myoldaddress = ucmodel.getAddress(myclient);
                Address = myoldaddress.StringAddress();
                updateClientUserControl.searchaddress.Text = Address;
                _ = SearchLocalisation();



            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }


            MyReplaceUCCommand = new ReplaceUCCommand();
            MyReplaceUCCommand.ReplaceUserControl += Client_CollectionChanged;

        }


        public async Task SearchLocalisation()
        {
            try
            {
                string streetname = updateClientUserControl.searchaddress.Text.ToString();
                if (streetname.Contains("TelAviv"))
                    streetname = streetname.Replace("TelAviv", "Tel Aviv");


                var x = await ucmodel.SearchAddress(streetname);
                var jo1 = JArray.Parse(x.ToString());


                longlat = new List<string>();
                longlat.Add(jo1[0]["lon"].ToString());
                longlat.Add(jo1[0]["lat"].ToString());


                if (!(Double.Parse(longlat.ElementAt(1).Replace(".", ",")) <= myzone.LatMax && Double.Parse(longlat.ElementAt(1).Replace(".", ",")) >= myzone.LatMin
                    && Double.Parse(longlat.ElementAt(0).Replace(".", ",")) <= myzone.LonMax && Double.Parse(longlat.ElementAt(0).Replace(".", ",")) >= myzone.LonMin))
                {
                    MessageBox.Show("Cannot deliver to this address", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;

                }


            }
            catch
            {
                MessageBox.Show("Cannot find this address", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            Pushpin pin = new Pushpin();
            pin.Location = new Location(Double.Parse(longlat.ElementAt(1).Replace(".", ",")), Double.Parse(longlat.ElementAt(0).Replace(".", ",")));


            updateClientUserControl.map.SetView(new Location(Double.Parse(longlat.ElementAt(1).Replace(".", ",")), Double.Parse(longlat.ElementAt(0).Replace(".", ","))), 16);
            updateClientUserControl.map.Children.Clear();
            updateClientUserControl.map.Children.Add(pin);
        }

        private async void Client_CollectionChanged(string obj)
        {



            switch (obj)
            {
                case "Update":
                    {
                        Boolean flag = true;
                        if (myclient.FirstName != FN || myclient.LastName != LN)
                        {
                            try
                            {
                                ucmodel.UpdateClientName(myclient, FN, LN);
                                MessageBox.Show("Client name successfully updated", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                flag = false;

                            }
                        }
                        if (myclient.Mail != DMMail)
                        {
                            try
                            {
                                ucmodel.UpdateClientMail(myclient, DMMail);
                                MessageBox.Show("Client Mail successfully updated", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                flag = false;

                            }
                        }
                        if (myclient.Phone != DMPhone)
                        {
                            try
                            {
                                ucmodel.UpdateClientPhone(myclient, DMPhone);
                                MessageBox.Show("Client Phone successfully updated", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                flag = false;

                            }
                        }
                        if (myoldaddress.StringAddress() != Address)
                        {
                            try
                            {
                                Address newaddress = getAddress();
                                ucmodel.UpdateAddress(myclient, newaddress);
                                MessageBox.Show("Client address successfully updated", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                flag = false;

                            }
                        }
                        if (food != myclient.Food || drug != myclient.Drug)
                        {
                            try
                            {
                                ucmodel.UpdateFoodDrug(myclient, food, drug);
                                MessageBox.Show("Client successfully updated", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                flag = false;

                            }
                        }

                        if (flag)
                        {
                            clientuc.clientcombobox.ItemsSource = clientvm.GetName();

                           // ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                           // ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuUserControl());

                        }


                        break;
                    }
                case "Ok":
                    await SearchLocalisation();

                    break;
                case "Remove":
                    {

                        Boolean flag = true;
                        try
                        {
                            // Address address = ucmodel.getAddress(myclient);
                            //  ucmodel.removeAddress(address); //~it doesn't work

                            ucmodel.removeClient(myclient);
                        }
                        catch (Exception e)
                        {
                            flag = false;
                            MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                        }

                        if (flag)
                        {
                            MessageBox.Show("Remove with success", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            clientuc.clientcombobox.ItemsSource = clientvm.GetName();
                            clientuc.secondgrid.Children.Clear();
                            clientuc.secondgrid.Children.Add(new UpdateClientUserControl());

                            // ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                            // ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuClientUserControl());

                        }
                        break;
                    }
                case "Cancel":
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new ChooseClientUserControl());

                        break;

                    }

            }

        }

        private Address getAddress()
        {
            Address myaddress = new Address();
            string address = Address;
            string[] mystring;
            if (address.Contains("Israel"))
                address = address.Replace("Israel", "");

            if (address.Contains("Tel Aviv") || address.Contains("Tel-Aviv"))
            {
                myaddress.ACity = MyEnum.City.TelAviv;
                address = address.Replace("Tel Aviv", "");
                address = address.Replace("Tel-Aviv", "");


            }
            else if (address.Contains("Tiberiad") || address.Contains("Tveria"))
            {
                myaddress.ACity = MyEnum.City.Tiberia;
                address = address.Replace("Tiberiad", "");
                address = address.Replace("Tveria", "");


            }

            else
            {

                mystring = address.Split();


                switch (mystring[mystring.Count() - 1])
                {
                    case "Ashdod":
                        myaddress.ACity = MyEnum.City.Ashdod;
                        address = address.Replace("Ashdod", " ");
                        mystring = address.Split();
                        break;
                    case "Ashkelon":
                        myaddress.ACity = MyEnum.City.Ashkelon;
                        address = address.Replace("Ashkelon", " ");
                        mystring = address.Split();
                        break;

                    case "Eilat":
                        myaddress.ACity = MyEnum.City.Eilat;
                        address = address.Replace("Eilat", " ");
                        mystring = address.Split();
                        break;
                    case "Haifa":
                        myaddress.ACity = MyEnum.City.Haifa;
                        address = address.Replace("Haifa", " ");
                        mystring = address.Split();
                        break;
                    case "Jerusalem":
                        myaddress.ACity = MyEnum.City.Jerusalem;
                        address = address.Replace("Jerusalem", " ");
                        mystring = address.Split();
                        break;
                    case "Netanya":
                        myaddress.ACity = MyEnum.City.Netanya;
                        address = address.Replace("Netanya", " ");
                        mystring = address.Split();
                        break;
                    case "Netivot":
                        myaddress.ACity = MyEnum.City.Netivot;
                        address = address.Replace("Netivot", " ");
                        mystring = address.Split();
                        break;
                    case "Raanana":
                        myaddress.ACity = MyEnum.City.Raanana;
                        address = address.Replace("Ashdod", " ");
                        mystring = address.Split();
                        break;
                    case "Safed":
                        myaddress.ACity = MyEnum.City.Safed;
                        address = address.Replace("Safed", " ");
                        mystring = address.Split();
                        break;

                    case "Tiberia":
                        myaddress.ACity = MyEnum.City.Tiberia;
                        address = address.Replace("Tiberia", " ");
                        mystring = address.Split();
                        break;


                    case "TelAviv":
                        myaddress.ACity = MyEnum.City.TelAviv;
                        address = address.Replace("TelAviv", " ");
                        mystring = address.Split();
                        break;

                    default:
                        throw new Exception("We can't deliver to this city : " + mystring[mystring.Count() - 1]);

                        break;
                }
            }

            mystring = address.Split();
            int nb;
            bool check = int.TryParse(mystring[0], out nb);
            if (check)
            {
                myaddress.NbAppart = nb;
            }
            else
                throw new Exception("You need to enter your appartment number");

            address = address.Replace(nb.ToString(), " ");
            mystring = address.Split();

            for (int i = 1; i < mystring.Count(); i++)
            {
                myaddress.StreeName += " " + mystring[i];
            }

            return myaddress;
        }
    }
}
