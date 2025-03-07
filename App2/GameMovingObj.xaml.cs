using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace App2
{
    public abstract class GameMovingObj
    {
        protected Canvas _scene;
        protected Image _image;
        protected double _x, _y, _image_Width, _image_Height;

        protected GameMovingObj(Canvas scene, string fileName, double x, double y, double size)
        {
            _scene = scene;
            _image = new Image { Source = new BitmapImage(new Uri(fileName, UriKind.Relative)) };
            _x = x;
            _y = y;
            _image_Width = size;
            _image_Height = size;
            _scene.Children.Add(_image);
            UpdatePosition();
        }

        protected GameMovingObj(bool contentLoaded, Canvas scene, Image image, double x, double y, double image_Width, double image_Height)
        {
            _contentLoaded = contentLoaded;
            _scene = scene;
            _image = image;
            _x = x;
            _y = y;
            _image_Width = image_Width;
            _image_Height = image_Height;
        }

        public abstract Rect Rect();

        protected void UpdatePosition()
        {
            Canvas.SetLeft(_image, _x);
            Canvas.SetTop(_image, _y);
        }

        public virtual void Stop()
        {
            // Default stop implementation
        }

        public double X => _x;
        public double Y => _y;
    }
}
