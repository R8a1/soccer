using System;
using System.Windows;
using System.Windows.Threading;
using Windows.UI.Xaml.Controls;

namespace CountdownTimer
{
    public partial class Timer : Window
    {
        private DispatcherTimer dispatcherTimer;
        private int countdown = 60;

        public Timer()
        {
            InitializeComponent();
            StartTimer();
        }

        private void StartTimer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            countdown--;
            CountdownText.Text = countdown.ToString();

            if (countdown <= 0)
            {
                dispatcherTimer.Stop();
                ShowGameOverPage();
            }
        }

        private void ShowGameOverPage()
        {
            Frame frame = Window.Current.Content as Frame;
            frame.Navigate(typeof(GameOverPage));
        }
    }
}