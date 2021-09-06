using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using WPFHalonotTrue.View;

namespace WPFHalonotTrue.ViewModel
{
    public class MainWindowVM
    {
        public MainWindow mywindwe { get; set; }

        public System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        public Boolean music { get; set; }
        public MainWindowVM(MainWindow mywindwe)
        {
            this.mywindwe = mywindwe;
            StartCloseTimer();

            string fullPathToSound = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @".\Music\BreezMusic.wav");
            player.SoundLocation = fullPathToSound;
            player.PlayLooping();
            music = true;
        }


        private void StartCloseTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(7d);
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            DispatcherTimer timer = (DispatcherTimer)sender;
            timer.Stop();
            timer.Tick -= TimerTick;
            mywindwe.mainGrid.Children.Clear();
            mywindwe.mainGrid.Children.Add(new LoginUserControl());

        }

    }
}
