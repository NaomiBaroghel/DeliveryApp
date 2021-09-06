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
    /// Logique d'interaction pour DistributionUserControl.xaml
    /// </summary>
    public partial class DistributionUserControl : UserControl
        
    {
        DistributionVM disvm { get; set; }
        public DistributionUserControl()
        {
            InitializeComponent();
            disvm = new DistributionVM(this);
            this.DataContext = disvm;
        }
        private void TextAllow(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

            
        }
       
        private void CheckBox_Fix(object sender, RoutedEventArgs e)
        {
            Interval.IsEnabled = true;
            Fix.Background = Brushes.Gray;

        }

        private void UnCheckBox_Fix(object sender, RoutedEventArgs e)
        {
            Interval.IsEnabled = false;
            Fix.Background = Brushes.Gray;

        }




        private void Food_Checked(object sender, RoutedEventArgs e)
        {
            disvm.CheckFood();
            Food.Background = Brushes.Gray;
        }
        
        private void Food_UnChecked(object sender, RoutedEventArgs e)
        {
            disvm.UnCheckFood();
            Food.Background = Brushes.Gray;


        }

        private void Drug_Checked(object sender, RoutedEventArgs e)
        {
            disvm.CheckDrug();
            Drug.Background = Brushes.Gray;

        }



        private void Drug_UnChecked(object sender, RoutedEventArgs e)
        {
            disvm.UnCheckDrug();
            Drug.Background = Brushes.Gray;

        }

        
    }
}
