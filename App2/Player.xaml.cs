using System;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;

namespace App2
{
    public class Player : GameMovingObj
    {
        private int _x;
        private int _y;
        private int _image_Width;
        private int _image_Height;
        private object _image;

        public enum StateType
        {
            Idle,
            RunLeft,
            RunRight,
            RunUp,
            RunDown
        }

        public StateType PlayerState { get; set; } = StateType.Idle;

        // Public integers and variables
        public int Health { get; set; }
        public int Score { get; set; }
        public int Speed { get; set; }
        public int Stamina { get; set; }
        public string PlayerName { get; set; }
        public bool IsActive { get; set; }
        public object Key { get; private set; }

        public Player(Canvas scene, string fileName, double x, double y, double size) : base(scene, fileName, x, y, size)
        {
            Health = 100;
            Score = 0;
            Speed = 5;
            Stamina = 100;
            PlayerName = "Default";
            IsActive = true;
        }

        public override Rect GetRect()
        {
            return new Rect(_x + 6, _y + 6, _image_Width - 12, _image_Height - 12);
        }

        public void Move(Key key)
        {
            switch (key)
            {
                case Key.Left:
                    PlayerState = StateType.RunLeft;
                    _x -= Speed;
                    break;
                case Key.Right:
                    PlayerState = StateType.RunRight;
                    _x += Speed;
                    break;
                case Key.Up:
                    PlayerState = StateType.RunUp;
                    _y -= Speed;
                    break;
                case Key.Down:
                    PlayerState = StateType.RunDown;
                    _y += Speed;
                    break;
                default:
                    PlayerState = StateType.Idle;
                    break;
            }
            MatchImageToState();
        }

        private void MatchImageToState()
        {
            switch (PlayerState)
            {
                case StateType.Idle:
                    _image.Source = new BitmapImage(new Uri("idle.png", UriKind.Relative));
                    break;
                case StateType.RunLeft:
                    _image.Source = new BitmapImage(new Uri("run_left.png", UriKind.Relative));
                    break;
                case StateType.RunRight:
                    _image.Source = new BitmapImage(new Uri("run_right.png", UriKind.Relative));
                    break;
                case StateType.RunUp:
                    _image.Source = new BitmapImage(new Uri("run_up.png", UriKind.Relative));
                    break;
                case StateType.RunDown:
                    _image.Source = new BitmapImage(new Uri("run_down.png", UriKind.Relative));
                    break;
            }
        }

        public bool CollidesWith(Ball ball)
        {
            return GetRect().IntersectsWith(ball.GetRect());
        }
    }
}