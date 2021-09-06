using BE;
using Microsoft.Maps.MapControl.WPF;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFHalonotTrue.Command;
using WPFHalonotTrue.Model;
using WPFHalonotTrue.View;

namespace WPFHalonotTrue.ViewModel
{
    public class KMeansVM : INotifyPropertyChanged
    {
        public ReplaceUCCommand MyReplaceUCCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public KMeansModel CurrentModel { get; set; }
        public KMeansUserControl myUC { get; set; }
        public String MyName;
        public String DisNB;
        public bool food;
        public bool drug;
        Address[][] mylistaddress;
        public int Index = 0;
        List<string> longlat;


        public KMeansVM(View.KMeansUserControl kmeansUC)
        {
            myUC = kmeansUC;
            MyReplaceUCCommand = new ReplaceUCCommand();
            MyReplaceUCCommand.ReplaceUserControl += Fourbutton;
            CurrentModel = new KMeansModel(this);
            food = false;
            drug = false;
            myUC.prev.IsEnabled = false;
            myUC.next.IsEnabled = false;
            myUC.ok.IsEnabled = false;



        }

        [HandleProcessCorruptedStateExceptions]

        public async void KMeans()
        {
            myUC.myGif.Visibility = Visibility.Visible;
            myUC.next.IsEnabled = false;
            myUC.prev.IsEnabled = false;
            myUC.ok.IsEnabled = false;
            food = (bool)myUC.Food.IsChecked;
            drug = (bool)myUC.Drug.IsChecked;
            MessageBox.Show("Configuring Distribution \n It might take some time...", "Configuration", MessageBoxButton.OK, MessageBoxImage.Information);

            try
            {


                mylistaddress = await CurrentModel.KMeans(food, drug);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }



            if (mylistaddress != null)
            {
                Index = 0;
                HelpDisplayMap(Index);
                myUC.next.IsEnabled = true;
                myUC.prev.IsEnabled = false;
                myUC.ok.IsEnabled = true;
                DisNB = (Index + 1).ToString();
                myUC.disnb.Text = DisNB;

                GetName();
                MessageBox.Show("Distribution automatic successfuly done", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                myUC.next.IsEnabled = false;
                myUC.prev.IsEnabled = false;
                myUC.ok.IsEnabled = false;
                MyName = string.Empty;
                DisNB = string.Empty;
                MessageBox.Show("There is not enough data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }


            myUC.myGif.Visibility = Visibility.Hidden;

        }

        public async void HelpDisplayMap(int index)
        {
            myUC.map.Children.Clear();


            if (mylistaddress != null)
            {
                int i = 0;
                foreach (Address myaddress in mylistaddress[index])
                {
                    if (myaddress != null) //it can be null cause the size of the list is bigger than the number of address in it
                    {
                        // MessageBox.Show("New Address : " + myaddress.StringAddress());
                        Boolean flag = false;
                        while (!flag)
                        {
                            try
                            {
                                string streetname = myaddress.StringAddress();
                                if (streetname.Contains("TelAviv"))
                                    streetname = streetname.Replace("TelAviv", "Tel Aviv");

                                var x = await CurrentModel.SearchAddress(streetname);


                                var jo1 = JArray.Parse(x.ToString());


                                longlat = new List<string>();
                                longlat.Add(jo1[0]["lon"].ToString());
                                longlat.Add(jo1[0]["lat"].ToString());


                                flag = true;
                            }
                            catch (Exception e)
                            {
                                continue;
                            }
                        }
                        i++;

                        Pushpin pin = new Pushpin();
                        pin.Location = new Location(Double.Parse(longlat.ElementAt(1).Replace(".", ",")), Double.Parse(longlat.ElementAt(0).Replace(".", ",")));
                        pin.ToolTip = myaddress.StringAddress();

                        myUC.map.Children.Add(pin);

                    }
                }
            }

        }




        public void GetName()
        {
            try
            {
                DeliveryMan myman = CurrentModel.getDman(Index);
                MyName = myman.FirstName + " " + myman.LastName;
                myUC.dmanFname.Text = MyName;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }


        public void Fourbutton(string obj)
        {
            switch (obj)
            {
                case "Prev.":
                    {
                        myUC.next.IsEnabled = true;
                        Index -= 1;
                        DisNB = (Index + 1).ToString();
                        myUC.disnb.Text = DisNB;
                        GetName();
                        if (Index == 0)
                            myUC.prev.IsEnabled = false;
                        HelpDisplayMap(Index);
                        break;
                    }
                case "Next":
                    {
                        myUC.prev.IsEnabled = true;
                        Index += 1;
                        DisNB = (Index + 1).ToString();
                        myUC.disnb.Text = DisNB;

                        GetName();
                        if (Index == mylistaddress.Length - 1)
                            myUC.next.IsEnabled = false;
                        HelpDisplayMap(Index);
                        break;
                    }
                case "OK":
                    {
                        Boolean flag = true;
                        try
                        {

                            for (int i = 0; i < mylistaddress.Length; i++)
                            {

                                DeliveryMan dman = CurrentModel.getDman(i);
                                Distribution mydis = new Distribution();
                                List<Address> mylist = new List<Address>();
                                mydis.DisTime = DateTime.Today;
                                mydis.Drug = drug;
                                mydis.Food = food;

                                foreach (Address myaddress in mylistaddress[i])
                                {
                                    if (myaddress != null)
                                        mylist.Add(myaddress);
                                }


                                CurrentModel.addDis(mydis, mylist);
                                CurrentModel.Assign(mydis, dman);
                            }
                        }
                        catch (Exception e)
                        {
                            flag = false;
                            MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                        }



                        if (flag)
                        {
                            MessageBox.Show("Distributions successfuly added", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                            ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                            ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuDistributionUserControl());
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
