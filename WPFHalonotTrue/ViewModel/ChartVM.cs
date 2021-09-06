using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFHalonotTrue.Command;
using WPFHalonotTrue.View;
using System.Windows.Controls.DataVisualization.Charting;
using WPFHalonotTrue.Model;

namespace WPFHalonotTrue.ViewModel
{
    class ChartVM : INotifyPropertyChanged
    {
        public ReplaceUCCommand MyReplaceUCCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ChartUserControl mychartUC { get; set; }
        public List<String> ListCity { get; set; }
        public ChartModel CurrentModel { get; set; }
        public ChartVM(View.ChartUserControl chartUC)
        {
            mychartUC = chartUC;
            mychartUC.pickerdate.SelectedDate = DateTime.Today;
            MyReplaceUCCommand = new ReplaceUCCommand();
            MyReplaceUCCommand.ReplaceUserControl += Threebutton;
            ListCity = new List<string>() { "TelAviv", "Netanya", "Jerusalem", "Eilat", "Haifa", "Safed", "Tiberia", "Netivot", "Ashdod", "Ashkelon", "Raanana" };
            CurrentModel = new ChartModel(this);


        }






        public void Threebutton(string obj)
        {
            switch (obj)
            {
                case "Day":
                    {


                        if (mychartUC.listCity.SelectedItems.Count > 1) //return only the nb of distribution done on the day choseen and cities choosen
                        {

                            PieUserControl mypie = new PieUserControl();
                            mypie.mcChart.Title = "Distributions Done  " + mychartUC.pickerdate.SelectedDate.Value.ToShortDateString();
                            var list = new List<KeyValuePair<string, int>>();


                            foreach (var v in mychartUC.listCity.SelectedItems)
                            {
                                try
                                {
                                    list.Add(new KeyValuePair<string, int>(v.ToString(), CurrentModel.DisDone(mychartUC.pickerdate.SelectedDate.Value, v.ToString())));

                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                }

                            }
                            ((PieSeries)mypie.mcChart.Series[0]).ItemsSource = list;



                            mychartUC.mygrid.Children.Clear();
                            mychartUC.mygrid.Children.Add(mypie);
                        }
                        else
                        {
                            BarUserControl mybar = new BarUserControl();
                            mybar.mcChart.Title = mychartUC.pickerdate.SelectedDate.Value.ToShortDateString() + " at " + mychartUC.listCity.SelectedItem.ToString();
                            try
                            {
                                ((ColumnSeries)mybar.mcChart.Series[0]).ItemsSource =



                                    new KeyValuePair<string, int>[]{
                                    new KeyValuePair<string,int>("", CurrentModel.DisPlanned(mychartUC.pickerdate.SelectedDate.Value, mychartUC.listCity.SelectedItem.ToString())),

                                              };

                                ((ColumnSeries)mybar.mcChart.Series[1]).ItemsSource =



                                    new KeyValuePair<string, int>[]{

                                    new KeyValuePair<string,int>("", CurrentModel.DisDone(mychartUC.pickerdate.SelectedDate.Value,mychartUC.listCity.SelectedItem.ToString())) ,

                                         };

                                ((ColumnSeries)mybar.mcChart.Series[2]).ItemsSource =



                                    new KeyValuePair<string, int>[]{
                                     new KeyValuePair<string,int>("", CurrentModel.DisNotPlannedButDone(mychartUC.pickerdate.SelectedDate.Value, mychartUC.listCity.SelectedItem.ToString())),
                                          };

                                ((ColumnSeries)mybar.mcChart.Series[3]).ItemsSource =



                                    new KeyValuePair<string, int>[]{
                                       new KeyValuePair<string,int>("", CurrentModel.DisCanceled(mychartUC.pickerdate.SelectedDate.Value, mychartUC.listCity.SelectedItem.ToString()))
                                    };

                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }


                            mychartUC.mygrid.Children.Clear();
                            mychartUC.mygrid.Children.Add(mybar);
                        }


                        break;
                    }
                case "Week":
                    {
                        DateTime weekdate = mychartUC.pickerdate.SelectedDate.Value.AddDays(7);

                        if (mychartUC.listCity.SelectedItems.Count > 1)//return only the nb of distribution done on the week choseen and cities choosen
                        {

                            PieUserControl mypie = new PieUserControl();
                            mypie.mcChart.Title = "Distributions Done  " + mychartUC.pickerdate.SelectedDate.Value.ToShortDateString() + " to " + weekdate.ToShortDateString();

                            var list = new List<KeyValuePair<string, int>>();


                            foreach (var v in mychartUC.listCity.SelectedItems)
                            {
                                try
                                {
                                    list.Add(new KeyValuePair<string, int>(v.ToString(), CurrentModel.DisDoneWeek(mychartUC.pickerdate.SelectedDate.Value, v.ToString())));
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                }

                            }
                            ((PieSeries)mypie.mcChart.Series[0]).ItemsSource = list;



                            mychartUC.mygrid.Children.Clear();
                            mychartUC.mygrid.Children.Add(mypie);
                        }
                        else
                        {
                            BarUserControl mybar = new BarUserControl();
                            mybar.mcChart.Title = mychartUC.pickerdate.SelectedDate.Value.ToShortDateString() + " to " + weekdate.ToShortDateString() + " at " + mychartUC.listCity.SelectedItem.ToString();

                            try
                            {

                                ((ColumnSeries)mybar.mcChart.Series[0]).ItemsSource =



                                    new KeyValuePair<string, int>[]{
                                    new KeyValuePair<string,int>("", CurrentModel.DisPlannedWeek(mychartUC.pickerdate.SelectedDate.Value, mychartUC.listCity.SelectedItem.ToString())),

                                              };
                                ((ColumnSeries)mybar.mcChart.Series[1]).ItemsSource =



                                    new KeyValuePair<string, int>[]{

                                    new KeyValuePair<string,int>("", CurrentModel.DisDoneWeek(mychartUC.pickerdate.SelectedDate.Value,mychartUC.listCity.SelectedItem.ToString())) ,

                                         };

                                ((ColumnSeries)mybar.mcChart.Series[2]).ItemsSource =



                                    new KeyValuePair<string, int>[]{
                                     new KeyValuePair<string,int>("", CurrentModel.DisNotPlannedButDoneWeek(mychartUC.pickerdate.SelectedDate.Value, mychartUC.listCity.SelectedItem.ToString())),
                                          };

                                ((ColumnSeries)mybar.mcChart.Series[3]).ItemsSource =



                                    new KeyValuePair<string, int>[]{
                                       new KeyValuePair<string,int>("", CurrentModel.DisCanceledWeek(mychartUC.pickerdate.SelectedDate.Value, mychartUC.listCity.SelectedItem.ToString()))
                                    };

                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }


                            mychartUC.mygrid.Children.Clear();
                            mychartUC.mygrid.Children.Add(mybar);
                        }
                        break;
                    }
                case "Month":
                    {
                        string month = "";
                        switch (mychartUC.pickerdate.SelectedDate.Value.Month.ToString())
                        {
                            case "1":
                                month = "January";
                                break;
                            case "2":
                                month = "February";
                                break;
                            case "3":
                                month = "March";
                                break;
                            case "4":
                                month = "April";
                                break;
                            case "5":
                                month = "May";
                                break;
                            case "6":
                                month = "June";
                                break;
                            case "7":
                                month = "July";
                                break;
                            case "8":
                                month = "August";
                                break;
                            case "9":
                                month = "September";
                                break;
                            case "10":
                                month = "October";
                                break;
                            case "11":
                                month = "November";
                                break;
                            case "12":
                                month = "December";
                                break;
                        }

                        if (mychartUC.listCity.SelectedItems.Count > 1) //return only the nb of distribution done on the month choseen and cities choosen
                        {

                            PieUserControl mypie = new PieUserControl();
                            mypie.mcChart.Title = "Distributions Done in " + month;

                            var list = new List<KeyValuePair<string, int>>();


                            foreach (var v in mychartUC.listCity.SelectedItems)
                            {
                                try
                                {
                                    list.Add(new KeyValuePair<string, int>(v.ToString(), CurrentModel.DisDoneMonth(mychartUC.pickerdate.SelectedDate.Value, v.ToString())));
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                }

                            }
                            ((PieSeries)mypie.mcChart.Series[0]).ItemsSource = list;



                            mychartUC.mygrid.Children.Clear();
                            mychartUC.mygrid.Children.Add(mypie);
                        }
                        else
                        {
                            BarUserControl mybar = new BarUserControl();

                            mybar.mcChart.Title = month + " at " + mychartUC.listCity.SelectedItem.ToString();

                            try
                            {
                                ((ColumnSeries)mybar.mcChart.Series[0]).ItemsSource =



                                    new KeyValuePair<string, int>[]{
                                    new KeyValuePair<string,int>("", CurrentModel.DisPlannedMonth(mychartUC.pickerdate.SelectedDate.Value, mychartUC.listCity.SelectedItem.ToString())),

                                              };
                                ((ColumnSeries)mybar.mcChart.Series[1]).ItemsSource =



                                    new KeyValuePair<string, int>[]{

                                    new KeyValuePair<string,int>("", CurrentModel.DisDoneMonth(mychartUC.pickerdate.SelectedDate.Value,mychartUC.listCity.SelectedItem.ToString())) ,

                                         };

                                ((ColumnSeries)mybar.mcChart.Series[2]).ItemsSource =



                                    new KeyValuePair<string, int>[]{
                                     new KeyValuePair<string,int>("", CurrentModel.DisNotPlannedButDoneMonth(mychartUC.pickerdate.SelectedDate.Value, mychartUC.listCity.SelectedItem.ToString())),
                                          };

                                ((ColumnSeries)mybar.mcChart.Series[3]).ItemsSource =



                                    new KeyValuePair<string, int>[]{
                                       new KeyValuePair<string,int>("", CurrentModel.DisCanceledMonth(mychartUC.pickerdate.SelectedDate.Value, mychartUC.listCity.SelectedItem.ToString()))
                                    };


                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            mychartUC.mygrid.Children.Clear();
                            mychartUC.mygrid.Children.Add(mybar);
                        }
                        break;
                    }
                case "Cancel":
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Clear();
                        ((MainWindow)System.Windows.Application.Current.MainWindow).mainGrid.Children.Add(new MenuUserControl());
                        break;
                    }
            }
        }


    }
}
