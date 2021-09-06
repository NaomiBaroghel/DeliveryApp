﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.DataVisualization.Charting;
using WPFHalonotTrue.ViewModel;

namespace WPFHalonotTrue.View
{
    /// <summary>
    /// Logique d'interaction pour ChartUserControl.xaml
    /// </summary>
    public partial class ChartUserControl : UserControl
    {
        ChartVM myvm { get; set; }
        public ChartUserControl()
        {
            InitializeComponent();
            myvm = new ChartVM(this);
            this.DataContext = myvm;
            //listCity.Background = new SolidColorBrush(Color.FromArgb(0xFF, 192, 223, 239));

        }


    }
}
