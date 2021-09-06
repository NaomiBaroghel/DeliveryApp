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
    /// Logique d'interaction pour MenuClientUserControl.xaml
    /// </summary>
    public partial class MenuClientUserControl : UserControl
    {
        MenuClientVM mcvm { get; set; }
        public MenuClientUserControl()
        {
            InitializeComponent();
            mcvm = new MenuClientVM(this);
            this.DataContext = mcvm;
        }
    }
}
