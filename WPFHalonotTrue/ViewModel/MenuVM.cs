using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup.Localizer;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WPFHalonotTrue.Command;
using WPFHalonotTrue.View;

namespace WPFHalonotTrue.ViewModel
{
    class MenuVM : INotifyPropertyChanged
    {
        public MenuUserControl myuc;
        public ReplaceUCCommand MyReplaceUCCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public MenuVM(View.MenuUserControl menuUC)
        {
            myuc = menuUC;



            MyReplaceUCCommand = new ReplaceUCCommand();
            MyReplaceUCCommand.ReplaceUserControl += Threebutton;

            if (((MainWindow)System.Windows.Application.Current.MainWindow).myvm.music)

            {
                myuc.imagemusic.Source = new BitmapImage(new Uri("/Images/musicon.png", UriKind.RelativeOrAbsolute));


            }
            else if (!((MainWindow)System.Windows.Application.Current.MainWindow).myvm.music)
            {
                myuc.imagemusic.Source = new BitmapImage(new Uri("/Images/musicoff.png", UriKind.RelativeOrAbsolute));

            }

        }

        public void Threebutton(string obj)
        {
            switch (obj)
            {
                case "Client":
                    {
                        /* ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                         ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuUserControl());
                         myuc.clientgrid.Children.Clear();*/
                        if (myuc.employeegrid.Children.Count > 2)
                        {
                            myuc.employeegrid.Children.RemoveAt(2);

                        }
                        if (myuc.disgrid.Children.Count > 2)
                        {
                            myuc.disgrid.Children.RemoveAt(2);

                        }
                        myuc.clientgrid.Children.Add(new MenuClientUserControl());

                        break;
                    }
                case "Employee":
                    {
                        /* ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                         ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuEmployeeUserControl());
                         myuc.employeegrid.Children.Clear();*/
                        if (myuc.clientgrid.Children.Count > 2)
                        {
                            myuc.clientgrid.Children.RemoveAt(2);

                        }
                        if (myuc.disgrid.Children.Count > 2)
                        {
                            myuc.disgrid.Children.RemoveAt(2);

                        }
                        myuc.employeegrid.Children.Add(new MenuEmployeeUserControl());

                        break;
                    }
                case "Distribution":
                    {
                        /*  ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                          ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuDistributionUserControl());
                          myuc.disgrid.Children.Clear();*/
                        if (myuc.clientgrid.Children.Count > 2)
                        {
                            myuc.clientgrid.Children.RemoveAt(2);

                        }
                        if (myuc.employeegrid.Children.Count > 2)
                        {
                            myuc.employeegrid.Children.RemoveAt(2);

                        }
                        myuc.disgrid.Children.Add(new MenuDistributionUserControl());

                        break;
                    }
                case "Music":
                    if (((MainWindow)System.Windows.Application.Current.MainWindow).myvm.music)

                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).myvm.music = false;
                        myuc.imagemusic.Source = new BitmapImage(new Uri("/Images/musicoff.png", UriKind.RelativeOrAbsolute));
                        ((MainWindow)System.Windows.Application.Current.MainWindow).myvm.player.Stop();


                    }
                    else if (!((MainWindow)System.Windows.Application.Current.MainWindow).myvm.music)
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).myvm.music = true;
                        myuc.imagemusic.Source = new BitmapImage(new Uri("/Images/musicon.png", UriKind.RelativeOrAbsolute));
                        ((MainWindow)System.Windows.Application.Current.MainWindow).myvm.player.PlayLooping();


                    }
                    break;

                case "Close":
                    ((MainWindow)System.Windows.Application.Current.MainWindow).Close();
                    break;
                case "Help":

                    myuc.Help.Visibility = Visibility.Hidden;
                    myuc.NeedHelp.Visibility = Visibility.Visible;

                    break;
                case "NeedHelp":
                    if (MessageBox.Show("Hi ! \n I'm here to help you understand this application", "Help", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuUserControl());

                        break;

                    }
                    if (MessageBox.Show("There is 3 categorie : Client, Employee, Distribution", "Help", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuUserControl());
                        break;
                    }


                    myuc.clientgrid.Background = Brushes.LightSteelBlue;

                    if (MessageBox.Show("Client is for the people in need you want to add to the list", "Help", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuUserControl());
                        break;
                    }

                    myuc.clientgrid.Background = Brushes.Transparent;
                    myuc.employeegrid.Background = Brushes.LightSteelBlue;

                    if (MessageBox.Show("Employee is for the employee or volunteers that can deliver", "Help", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuUserControl());
                        break;
                    }

                    myuc.employeegrid.Background = Brushes.Transparent;
                    myuc.disgrid.Background = Brushes.LightSteelBlue;

                    if (MessageBox.Show("Distribution is obviously what you need and to whom you need to deliver", "Help", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuUserControl());
                        break;
                    }
                    myuc.disgrid.Background = Brushes.Transparent;
                    myuc.clientgrid.Children.Add(new MenuClientUserControl());
                    if (MessageBox.Show("In the Client you can Create or Update a client", "Help", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuUserControl());
                        break;
                    }

                    ClientUserControl Box = new  ClientUserControl();
                    myuc.menugrid.Children.Add(Box);
                    Grid.SetColumnSpan(Box, 3);
                    if (MessageBox.Show("Here you can create a Client \n Make sure to check if the address exist before create it ! ","Help", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuUserControl());
                        break;
                    }


                    myuc.menugrid.Children.RemoveAt(myuc.menugrid.Children.Count - 1);
                    ChooseClientUserControl Box2 = new ChooseClientUserControl();
                    myuc.menugrid.Children.Add(Box2);
                    Grid.SetColumnSpan(Box2, 3);
                    if (MessageBox.Show("Here you can choose wich client you would like to update ! ", "Help", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuUserControl());
                        break;
                    }


                    myuc.menugrid.Children.RemoveAt(myuc.menugrid.Children.Count - 1);
                    myuc.clientgrid.Children.RemoveAt(2);

                    myuc.employeegrid.Children.Add(new MenuEmployeeUserControl());
                    if (MessageBox.Show("In the Employee you can Create or Update an employee or release a pdf with the report of all his activities", "Help", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuUserControl());
                        break;
                    }


                    EmployeeUserControl Box3 = new EmployeeUserControl();
                    myuc.menugrid.Children.Add(Box3);
                    Grid.SetColumnSpan(Box3, 3);
                    if (MessageBox.Show("Here you can create an Employee ","Help", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuUserControl());
                        break;
                    }

                    myuc.menugrid.Children.RemoveAt(myuc.menugrid.Children.Count - 1);

                    ChooseDManUserControl Box4 = new ChooseDManUserControl();
                    myuc.menugrid.Children.Add(Box4);
                    Grid.SetColumnSpan(Box4, 3);
                    if (MessageBox.Show("Here you can choose wich Employee to update ", "Help", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuUserControl());
                        break;
                    }

                    myuc.menugrid.Children.RemoveAt(myuc.menugrid.Children.Count - 1);

                    PDFUserControl Box5 = new PDFUserControl();
                    myuc.menugrid.Children.Add(Box5);
                    Grid.SetColumnSpan(Box5, 3);
                    if (MessageBox.Show("Here you can choose wich Employee to get his PDF from  ", "Help", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuUserControl());
                        break;
                    }


                    myuc.menugrid.Children.RemoveAt(myuc.menugrid.Children.Count - 1);
                    myuc.employeegrid.Children.RemoveAt(2);

                    myuc.disgrid.Children.Add(new MenuDistributionUserControl());
                    if (MessageBox.Show("In the Distribution you can Create Manualy or Automaticly a distribution(s) \n or mark as Done or Canceled \n or you can look at the statistics", "Help", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuUserControl());
                        break;
                    }

                    DistributionUserControl Box6 = new DistributionUserControl();
                    myuc.menugrid.Children.Add(Box6);
                    Grid.SetColumnSpan(Box6, 3);

                    if (MessageBox.Show("Here you can create a Distribution Manualy", "Help", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuUserControl());
                        break;
                    }

                    myuc.menugrid.Children.RemoveAt(myuc.menugrid.Children.Count - 1);
                    KMeansUserControl Box7 = new KMeansUserControl();
                    myuc.menugrid.Children.Add(Box7);
                    Grid.SetColumnSpan(Box7, 3);

                    if (MessageBox.Show("Here you can create a Distribution Automaticly \n There will be as many distribution created as there are employees", "Help", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuUserControl());
                        break;
                    }


                    myuc.menugrid.Children.RemoveAt(myuc.menugrid.Children.Count - 1);
                    ChooseDisUserControl Box8 = new ChooseDisUserControl();
                    myuc.menugrid.Children.Add(Box8);
                    Grid.SetColumnSpan(Box8, 3);

                    if (MessageBox.Show("Here you can choose wich Distribution to cancel or to mark as done", "Help", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuUserControl());
                        break;
                    }

                    myuc.menugrid.Children.RemoveAt(myuc.menugrid.Children.Count - 1);
                    ChartUserControl Box9 = new ChartUserControl();
                    myuc.menugrid.Children.Add(Box9);
                    Grid.SetColumnSpan(Box9, 3);

                    if (MessageBox.Show("Here you can look for the statistique of each city at the time you choose", "Help", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuUserControl());
                        break;
                    }



                    myuc.menugrid.Children.RemoveAt(myuc.menugrid.Children.Count - 1);
                    myuc.disgrid.Children.RemoveAt(2);


                    if (MessageBox.Show(" Hope it was helpfull ! \n If you didn't find what you needed, you still can send us a message to : \n ornao@gmail.com", "Help", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuUserControl());
                        break;
                    }



                    myuc.Help.Visibility = Visibility.Visible;
                    myuc.NeedHelp.Visibility = Visibility.Hidden;



                    break;

            }
        }

        public void reset()
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
            ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuUserControl());

        }
    }
}
