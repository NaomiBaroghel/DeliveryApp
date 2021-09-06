//using DemoDataProtocol;
using BE;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WPFHalonotTrue.Command;
using WPFHalonotTrue.Models;
using WPFHalonotTrue.View;

namespace WPFHalonotTrue.ViewModels
{
    public class LoginVM : INotifyPropertyChanged
    {
        public ReplaceUCCommand MyReplaceUCCommand { get; set; }
        public LoginUserControl loginuc { get; set; }
        public LoginModel myloginmodel { get; set; }
        public string password
        {
            get { return loginuc.password.Password; }
            set
            {
                loginuc.password.Password = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("password"));
            }
        }

        Boolean show;
        public event PropertyChangedEventHandler PropertyChanged;

        public LoginVM(View.LoginUserControl loginUC)
        {
            loginuc = loginUC;
            MyReplaceUCCommand = new ReplaceUCCommand();
            myloginmodel = new LoginModel(this);
            MyReplaceUCCommand.ReplaceUserControl += OKbutt;
            show = false;


        }
        public void OKbutt(string obj)
        {
            switch(obj)
            {
                case "OK":
                    try
                    {
                        myloginmodel.createSQL();
                    }
                    catch
                    {
                        //do nothing
                    }

                    if (myloginmodel.CheckPassword(password))
                    {
                        

                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuUserControl());
                    }
                    else
                        MessageBox.Show("Wrong Password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);


                    break;
                case "SHOW":
                    if(show)
                    {
                        show = false;

                        loginuc.imagebutton.Source = new BitmapImage(new Uri("/Images/eyesuncheck.jpg", UriKind.RelativeOrAbsolute));
                        loginuc.password.Visibility = Visibility.Visible;
                        loginuc.password.Password = loginuc.showpassword.Text;
                        loginuc.showpassword.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        show = true;
                        loginuc.imagebutton.Source = new BitmapImage(new Uri("/Images/eyescheck.jpg", UriKind.RelativeOrAbsolute));
                        loginuc.password.Visibility = Visibility.Hidden;
                        loginuc.showpassword.Visibility = Visibility.Visible;
                        loginuc.showpassword.Text = loginuc.password.Password;

                    }

                    break;
            }
           
        }

    }
}
