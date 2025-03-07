using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App2
{
    public class Goal
    {
        private Rect _goalArea;
        private Rectangle _goalVisual;

        public Goal(Canvas scene, double x, double y, double width, double height)
        {
            _goalArea = new Rect(x, y, width, height);
            _goalVisual = new Rectangle
            {
                Width = width,
                Height = height,
                Fill = new SolidColorBrush(Color.FromArgb(128, 255, 0, 0))
            };
            Canvas.SetLeft(_goalVisual, x);
            Canvas.SetTop(_goalVisual, y);
            scene.Children.Add(_goalVisual);
        }

        public static object DiractionType { get; internal set; }

        public Rect GoalArea => _goalArea;
    }
}
