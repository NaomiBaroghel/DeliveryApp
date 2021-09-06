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
    /// Logique d'interaction pour PDFUserControl.xaml
    /// </summary>
    public partial class PDFUserControl : UserControl
    {
        PDFVM pdfvm { get; set; }
        public PDFUserControl()
        {
            InitializeComponent();
            pdfvm = new PDFVM(this);
            this.DataContext = pdfvm;

        }

        private void employeecombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pdf.IsEnabled = true;
        }
    }
}
