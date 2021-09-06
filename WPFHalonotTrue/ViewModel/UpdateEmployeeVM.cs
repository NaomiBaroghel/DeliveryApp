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
    class UpdateEmployeeVM : INotifyPropertyChanged
    {
        private UpdateEmployeeUserControl updateEmployeeUserControl;
        public ChooseDManUserControl dManUserControl;
        public ChooseDManVM dmanvm;
        public UpdateEmployeeModel uemodel { get; set; }
        public DeliveryMan DMan { get; set; }
        public string FN { get; set; }
        public string LN { get; set; }
        public string DMMail { get; set; }
        public string DMPhone { get; set; }
        public ReplaceUCCommand MyReplaceUCCommand { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;

        public UpdateEmployeeVM(UpdateEmployeeUserControl updateEmployeeUserControl, int index, ChooseDManUserControl dManUserControl, ChooseDManVM chooseDManVM)
        {
            this.updateEmployeeUserControl = updateEmployeeUserControl;
            uemodel = new UpdateEmployeeModel(this);
            this.dManUserControl = dManUserControl;
            this.dmanvm = chooseDManVM;
            DMan = new DeliveryMan();


            updateEmployeeUserControl.update.IsEnabled = true;
            updateEmployeeUserControl.remove.IsEnabled = true;

            try
            {
                DMan = uemodel.getDman(index);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            FN = DMan.FirstName;
            LN = DMan.LastName;
            DMMail = DMan.Mail;
            DMPhone = DMan.Phone;

            MyReplaceUCCommand = new ReplaceUCCommand();
            MyReplaceUCCommand.ReplaceUserControl += Employee_CollectionChanged;

        }

        private void Employee_CollectionChanged(string obj)
        {



            switch (obj)
            {
                case "Update":
                    {
                        Boolean flag = true;
                        if (DMan.FirstName != FN || DMan.LastName != LN)
                        {
                            try
                            {
                                uemodel.UpdateDManName(DMan, FN, LN);

                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                flag = false;

                            }
                        }
                        if (DMan.Mail != DMMail)
                        {
                            try
                            {
                                uemodel.UpdateDManMail(DMan, DMMail);

                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                flag = false;

                            }
                        }
                        if (DMan.Phone != DMPhone)
                        {
                            try
                            {
                                uemodel.UpdateDManPhone(DMan, DMPhone);

                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                flag = false;

                            }
                        }

                        if (flag)
                        {
                            MessageBox.Show("Employee successfully updated", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            dManUserControl.employeecombobox.ItemsSource = dmanvm.GetName();
                            // ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                            // ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuEmployeeUserControl());

                        }


                        break;
                    }
                case "Remove":
                    {
                        if (MessageBox.Show("If you remove this employee all his distribution will be lost ! \n Are you sure you want to remove this employee ?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                        {
                            Boolean flag = true;
                            try
                            {
                                uemodel.removeEmployee(DMan);
                            }
                            catch (Exception e)
                            {
                                flag = false;
                                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                            }

                            if (flag)
                            {
                                MessageBox.Show("Remove with success", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                                dManUserControl.employeecombobox.ItemsSource = dmanvm.GetName();
                                dManUserControl.secondgrid.Children.Clear();
                                dManUserControl.secondgrid.Children.Add(new UpdateEmployeeUserControl());


                                //  ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                                //  ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuEmployeeUserControl());

                            }
                        }
                        break;
                    }
                case "Cancel":
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new ChooseDManUserControl());

                        break;

                    }

            }

        }
    }
}
