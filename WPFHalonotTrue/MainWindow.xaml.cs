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
using System.Windows.Threading;
using WPFHalonotTrue.View;
using WPFHalonotTrue.ViewModel;

namespace WPFHalonotTrue
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindowVM myvm;
        public MainWindow()
        {
            InitializeComponent();
            myvm = new MainWindowVM(this);

            
            
        }



       
    }
}
