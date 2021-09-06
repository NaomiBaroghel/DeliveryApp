using BE;
using Microsoft.Maps.MapControl.WPF;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFHalonotTrue.Command;
using WPFHalonotTrue.Model;
using WPFHalonotTrue.View;

namespace WPFHalonotTrue.ViewModel
{
    class ClientVM : INotifyPropertyChanged
    {
        private ClientUserControl clientUserControl;
        private ClientModel CurrentModel;
        private Client client;
        public string FN { get; set; }
        public string LN { get; set; }
        public string DMMail { get; set; }
        public string DMPhone { get; set; }
        public string Address { get; set; }
        public bool food { get; set; }
        public bool drug { get; set; }

        List<string> longlat { get; set; }

        MyZone myzone { get; set; }
        public ReplaceUCCommand MyReplaceUCCommand { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;
        public ClientVM(ClientUserControl clientUserControl)
        {
            this.clientUserControl = clientUserControl;
            CurrentModel = new ClientModel();
            client = new Client();

            MyReplaceUCCommand = new ReplaceUCCommand();
            MyReplaceUCCommand.ReplaceUserControl += Client_CollectionChanged;
            longlat = new List<string>();
            food = false;
            drug = false;
            myzone = new MyZone();



        }

        public async Task SearchLocalisation()
        {
            try
            {
                string streetname = clientUserControl.searchaddress.Text.ToString();
                if (streetname.Contains("TelAviv"))
                    streetname = streetname.Replace("TelAviv", "Tel Aviv");


                var x = await CurrentModel.SearchAddress(streetname);
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
                return;
            }

            Pushpin pin = new Pushpin();
            pin.Location = new Location(Double.Parse(longlat.ElementAt(1).Replace(".", ",")), Double.Parse(longlat.ElementAt(0).Replace(".", ",")));


            clientUserControl.map.SetView(new Location(Double.Parse(longlat.ElementAt(1).Replace(".", ",")), Double.Parse(longlat.ElementAt(0).Replace(".", ","))), 16);
            clientUserControl.map.Children.Clear();
            clientUserControl.map.Children.Add(pin);
        }

        private async void Client_CollectionChanged(string obj)
        {


            switch (obj)
            {
                case "Ok":
                    {
                        try
                        {
                            await SearchLocalisation();
                        }
                        catch(Exception e)
                        {
                            MessageBox.Show(e.Message,"Error",MessageBoxButton.OK,MessageBoxImage.Error);
                        }
                        break;
                    }
                case "Create":
                    {
                        client.FirstName = FN;
                        client.LastName = LN;
                        client.Mail = DMMail;
                        client.Phone = DMPhone;
                        client.Drug = drug;
                        client.Food = food;
                        Boolean flag = true;

                        try
                        {
                            client.MyAddress = getAddress();
                            CurrentModel.AddClient(client);

                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            flag = false;

                        }

                        if (flag)
                        {
                            MessageBox.Show("Client successfully added", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                            ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuUserControl());

                        }


                        break;
                    }
                case "Reset":
                    {
                        FN = null;
                        LN = null;
                        DMMail = null;
                        DMPhone = null;
                        food = false;
                        drug = false;
                        Address = null;

                        clientUserControl.firstname.Text = String.Empty;
                        clientUserControl.lastname.Text = String.Empty;
                        clientUserControl.mail.Text = String.Empty;
                        clientUserControl.phonenumber.Text = String.Empty;
                        clientUserControl.food.IsChecked = false;
                        clientUserControl.drug.IsChecked = false;
                        clientUserControl.searchaddress.Text = String.Empty;


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
                myaddress.StreeName +=" "+ mystring[i];
            }

            return myaddress;
        }
    }
}
