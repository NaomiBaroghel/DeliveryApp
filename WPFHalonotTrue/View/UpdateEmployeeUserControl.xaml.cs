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
    /// Logique d'interaction pour UpdateEmployeeUserControl.xaml
    /// </summary>
    public partial class UpdateEmployeeUserControl : UserControl
    {
       UpdateEmployeeVM uevm { get; set; }
        public UpdateEmployeeUserControl(int selectedIndex, ChooseDManUserControl dManUserControl, ChooseDManVM chooseDManVM)
        {
            InitializeComponent();
            uevm = new UpdateEmployeeVM(this, selectedIndex, dManUserControl, chooseDManVM);
            this.DataContext = uevm;
            

        }
        public UpdateEmployeeUserControl()
        {
            InitializeComponent();
        }

        private void TextAllow2(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

        }
       
    }
}
