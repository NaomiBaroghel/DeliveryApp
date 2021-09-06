using BE;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFHalonotTrue.ViewModel;

namespace WPFHalonotTrue.View
{
    /// <summary>
    /// Logique d'interaction pour DoneUserControl.xaml
    /// </summary>
    public partial class DoneUserControl : UserControl
    {
        DoneVM dvm { get; set; }
        public DoneUserControl(Distribution distribution,int index, ChooseDisUserControl choosedisUserControl, ChooseDisVM chooseDisVM)
        {
            InitializeComponent();
            dvm = new DoneVM(this, distribution,index, choosedisUserControl, chooseDisVM);
              this.DataContext = dvm;
        }

        public DoneUserControl()
        {
            InitializeComponent();
        }
    }
}
