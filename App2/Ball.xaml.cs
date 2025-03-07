using System;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace App2
{
    public class Ball : GameMovingObj
    {
        private int _PointRightPlayer = 0;
        private int _PointLeftPlayer = 0;
        private double _speedX = 0;
        private double _speedY = 0;

        public Ball(Canvas scene, string fileName, double x, double y, double size) : base(scene, fileName, x, y, size)
        {
        }

        public Ball(bool contentLoaded) : base(null, string.Empty, 0, 0, 0)
        {
            _contentLoaded = contentLoaded;
        }

        public Ball(bool contentLoaded, int pointRightPlayer, int pointLeftPlayer, double y, double x, UIElement image, int image_Width, int image_Height) : this(contentLoaded)
        {
            _PointRightPlayer = pointRightPlayer;
            _PointLeftPlayer = pointLeftPlayer;
            _y = y;
            _x = x;
            _image = image;
            _image_Width = image_Width;
            _image_Height = image_Height;
        }

        public override Rect GetRect()
        {
            return new Rect(_x + 6, _y + 6, _image_Width - 12, _image_Height - 12);
        }

        public void Move()
        {
            _x += _speedX;
            _y += _speedY;
            UpdatePosition();
        }

        public void SetSpeed(double speedX, double speedY)
        {
            _speedX = speedX;
            _speedY = speedY;
        }

        private void UpdatePosition()
        {
            Canvas.SetLeft(_image, _x);
            Canvas.SetTop(_image, _y);
        }

        public override void Collide(GameObject otherObject)
        {
            if (otherObject is Goal goal)
            {
                if (goal.FlowDirection == Goal.DirectionType.Left)
                {
                    _PointRightPlayer++;
                }
                else
                {
                    _PointLeftPlayer++;
                }
                ResetBallPosition();
                _speedX = 0;
                _speedY = 0;
                GameManager.GameEvents.OnUpdateScore?.Invoke(_PointLeftPlayer, _PointRightPlayer);
            }
            else if (otherObject is Player player)
            {
                double dx = _x - player.X;
                double dy = _y - player.Y;
                double distance = Math.Sqrt(dx * dx + dy * dy);
                dx /= distance;
                dy /= distance;

                SetSpeed(dx * 10, dy * 10);
        }

        private void ResetBallPosition()
        {
            _x = _scene.ActualWidth / 2 - GetRect().Width / 2;
            _y = _scene.ActualHeight / 2 - GetRect().Height / 2;
            UpdatePosition();
        }
    }
}
