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
    /// Logique d'interaction pour UpdateClientUserControl.xaml
    /// </summary>
    public partial class UpdateClientUserControl : UserControl
    {
        UpdateClientVM ucvm { get; set; }
        public UpdateClientUserControl(int index, ChooseClientUserControl chooseClientUserControl, ChooseClientVM chooseClientVM)
        {
            InitializeComponent();
            ucvm = new UpdateClientVM(this, index, chooseClientUserControl, chooseClientVM);
            this.DataContext = ucvm;
        }
        public UpdateClientUserControl()
        {
            InitializeComponent();
        }

        private void TextAllow2(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

        }

        private void CheckBox_Food(object sender, RoutedEventArgs e)
        {

            food.Background = Brushes.Gray;

        }

        private void CheckBox_Drug(object sender, RoutedEventArgs e)
        {
            drug.Background = Brushes.Gray;

        }

        private void UnCheckBox_Food(object sender, RoutedEventArgs e)
        {
            food.Background = Brushes.Gray;

        }

        private void UnCheckBox_Drug(object sender, RoutedEventArgs e)
        {
            drug.Background = Brushes.Gray;

        }
    }
}
