using BE;
using DAL;
using System;
using System.Collections;
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
    /// Logique d'interaction pour ChooseDisControl.xaml
    /// </summary>
    public partial class ChooseDisUserControl : UserControl
    {
        ChooseDisVM choosevm { get; set; }
        public ChooseDisUserControl()
        {
            InitializeComponent();
            choosevm = new ChooseDisVM(this);
            this.DataContext = choosevm;
           
        }

      

        private void discombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            choose.IsEnabled = true;
        }

        private void employeecombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            choosevm.GetListDis();
        }
    }
}
