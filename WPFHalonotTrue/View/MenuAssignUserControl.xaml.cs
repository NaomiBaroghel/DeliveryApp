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
    /// Logique d'interaction pour MenuAssignUserControl.xaml
    /// </summary>
    public partial class MenuAssignUserControl : UserControl
    {
        MenuAssignVM assignVM { get; set; }
        public MenuAssignUserControl()
        {
            InitializeComponent();
            assignVM = new MenuAssignVM(this);
            this.DataContext = assignVM;
        }
    }
}
