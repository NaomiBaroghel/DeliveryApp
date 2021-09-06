using System;
using System.Collections.Generic;
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
using WPFHalonotTrue.ViewModel;

namespace WPFHalonotTrue.View
{
    /// <summary>
    /// Logique d'interaction pour ClientUserControl.xaml
    /// </summary>
    public partial class ClientUserControl : UserControl
    {
        ClientVM clientvm { get; set; }
        public ClientUserControl()
        {
            InitializeComponent();

            clientvm = new ClientVM(this);

            this.DataContext = clientvm;

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
                            if (searchaddress.Text.ToString() != "")
                                if (food.IsChecked == true || drug.IsChecked == true)
                                    create.IsEnabled = true;
                                else
                                    create.IsEnabled = false;
                            else
                                create.IsEnabled = false;
                        else
                            create.IsEnabled = false;
                    else
                        create.IsEnabled = false;
                else
                    create.IsEnabled = false;
            else
                create.IsEnabled = false;
        }

        private void CheckBox_Food(object sender, RoutedEventArgs e)
        {

            food.Background = Brushes.Gray;
            HelpDisplayCreate();

        }

        private void CheckBox_Drug(object sender, RoutedEventArgs e)
        {
            drug.Background = Brushes.Gray;
            HelpDisplayCreate();

        }

        private void UnCheckBox_Food(object sender, RoutedEventArgs e)
        {
            food.Background = Brushes.Gray;
            HelpDisplayCreate();

        }

        private void UnCheckBox_Drug(object sender, RoutedEventArgs e)
        {
            drug.Background = Brushes.Gray;
            HelpDisplayCreate();

        }

        private void searchaddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            HelpDisplayCreate();

        }
    }
}
