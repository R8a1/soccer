using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App2.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LvlPage : Page
    {
        public LvlPage()
        {
            this.InitializeComponent();
        }

        private void EasyButton_Click(object sender, RoutedEventArgs e)
        {
            GameMovingObj.lvl.BallSpeed = 4;
            GameMovingObj.lvl.GoalSize = 160;
            Frame.Navigate(typeof(GameOverPage));
        }

        private void MidButton_Click(object sender, RoutedEventArgs e)
        {
            GameMovingObj.lvl.BallSpeed = 6;
            GameMovingObj.lvl.GoalSize = 120;
            Frame.Navigate(typeof(GameOverPage));
        }

        private void HardButton_Click(object sender, RoutedEventArgs e)
        {
            GameMovingObj.lvl.BallSpeed = 8;
            GameMovingObj.lvl.GoalSize = 100;
            Frame.Navigate(typeof(GameOverPage));
        }
    }
}