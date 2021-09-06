using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Logique d'interaction pour KMeansUserControl.xaml
    /// </summary>
    public partial class KMeansUserControl : UserControl
    {
        public KMeansVM myvm { get; set; }
        public KMeansUserControl()
        {
            InitializeComponent();
            myvm = new KMeansVM(this);
            this.DataContext = myvm;
        }

        private void Food_Checked(object sender, RoutedEventArgs e)
        {
            myvm.KMeans();
            Food.Background = Brushes.Gray;

        }
        private void Food_UnChecked(object sender, RoutedEventArgs e)
        {
            myvm.KMeans();
            Food.Background = Brushes.Gray;


        }
        private void Drug_Checked(object sender, RoutedEventArgs e)
        {
            myvm.KMeans();
            Drug.Background = Brushes.Gray;

        }

        private void Drug_UnChecked(object sender, RoutedEventArgs e)
        {
            myvm.KMeans();
            Drug.Background = Brushes.Gray;

        }
    }
}
