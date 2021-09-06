using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFHalonotTrue.ViewModels;

namespace WPFHalonotTrue.View
{
    /// <summary>
    /// Logique d'interaction pour EmployeeUserControl.xaml
    /// </summary>
    public partial class EmployeeUserControl : UserControl
    {
        EmployeeViewModel employeeVM { get; set; }
        public EmployeeUserControl()
        {
            InitializeComponent();
            employeeVM = new EmployeeViewModel(this);
            this.DataContext = employeeVM;
        }

      



        private void TextAllow2(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

            HelpDisplayCreate();
        }

        public void HelpDisplayCreate()
        {
            if (firstname.Text.ToString() != "")
                if (lastname.Text.ToString() != "")
                    if (mail.Text.ToString() != "")
                        if (phonenumber.Text.ToString() != "")
                            create.IsEnabled = true;
                        else
                            create.IsEnabled = false;
                    else
                        create.IsEnabled = false;
                else
                    create.IsEnabled = false;
            else
                create.IsEnabled = false;
        }

        private void firstname_TextChanged(object sender, TextChangedEventArgs e)
        {
            HelpDisplayCreate();

        }

        private void lastname_TextChanged(object sender, TextChangedEventArgs e)
        {
            HelpDisplayCreate();

        }

        private void mail_TextChanged(object sender, TextChangedEventArgs e)
        {
            HelpDisplayCreate();
        }

       
    }
}
