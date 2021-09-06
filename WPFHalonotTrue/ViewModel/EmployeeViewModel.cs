//using DemoDataProtocol;
using BE;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using WPFHalonotTrue.Command;
using WPFHalonotTrue.Models;
using WPFHalonotTrue.View;

namespace WPFHalonotTrue.ViewModels
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
         private EmployeeModel CurrentModel;
         private DeliveryMan Dman;
         public string FN { get; set; }
         public string LN { get; set; }
         public string DMMail { get; set; }
         public string DMPhone { get; set; }

        public ReplaceUCCommand MyReplaceUCCommand { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;
         private EmployeeUserControl employeeUserControl;

        public EmployeeViewModel(EmployeeUserControl employeeUserControl)
        {
            CurrentModel = new EmployeeModel();
            this.employeeUserControl = employeeUserControl;
            MyReplaceUCCommand = new ReplaceUCCommand();
            MyReplaceUCCommand.ReplaceUserControl += Employee_CollectionChanged;
            Dman = new DeliveryMan();
        }

        private void Employee_CollectionChanged(object sender)
         {
            
            switch(sender)
            {
                case "Create":
                    {
                        Dman.FirstName = FN;
                        Dman.LastName = LN;
                        Dman.Mail = DMMail;
                        Dman.Phone = DMPhone;
                        Boolean flag = true;
                        try
                        {
                            CurrentModel.AddDMan(Dman);

                        }
                        catch(Exception e)
                        {
                            MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            flag = false;
                           
                        }

                        if (flag)
                        {
                            MessageBox.Show("Employee successfully added", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                            ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuUserControl());

                        }


                        break;
                    }
                
                case "Reset":
                    {
                        FN = "";
                        LN = "";
                        DMMail = "";
                        DMPhone = "";

                        employeeUserControl.firstname.Text = string.Empty;
                        employeeUserControl.lastname.Text = string.Empty;
                        employeeUserControl.mail.Text = string.Empty;
                        employeeUserControl.phonenumber.Text = string.Empty;

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
