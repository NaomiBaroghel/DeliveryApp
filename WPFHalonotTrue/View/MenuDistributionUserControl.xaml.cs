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
    /// Logique d'interaction pour MenuDistributionUserControl.xaml
    /// </summary>
    public partial class MenuDistributionUserControl : UserControl
    {
        MenuDistributionVM menudisVM { get; set; }
        public MenuDistributionUserControl()
        {
            InitializeComponent();
            menudisVM = new MenuDistributionVM(this);
            this.DataContext = menudisVM;
        }
    }
}
