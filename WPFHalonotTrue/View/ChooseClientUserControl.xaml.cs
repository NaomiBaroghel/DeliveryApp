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
    /// Logique d'interaction pour ChooseClientUserControl.xaml
    /// </summary>
    public partial class ChooseClientUserControl : UserControl
    {
        ChooseClientVM ccvm { get; set; }
        public ChooseClientUserControl()
        {
            InitializeComponent();
            ccvm = new ChooseClientVM(this);
            this.DataContext = ccvm;
               
        }

        private void clientcombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            choose.IsEnabled = true;
        }
    }
}
