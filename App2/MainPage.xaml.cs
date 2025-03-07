using System;
using Windows.UI.Xaml.Controls;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App2
{
    public class MainGame
    {
        public Action<int, int> OnUpdateScore; //האירוע יאפשר עדכון תוצאות על גבי מסך השחק
        private int _LeftScore = 0;
        private int _RightScore = 0;
        private Player _player1;
        private Player _player2;
        private Ball _ball;
        private Goal _goal1;
        private Goal _goal2;

        public MainGame(Canvas scene)
        {
            _player1 = new Player(scene, "player1.png", 100, 100, 50);
            _player2 = new Player(scene, "player2.png", 300, 100, 50);
            _ball = new Ball(scene, "ball.png", 200, 200, 30);
            _goal1 = new Goal(scene, 50, 150, 20, 100);
            _goal2 = new Goal(scene, 430, 150, 20, 100);

            GameManager.GameEvents.OnKeyPress += OnKeyPress;
        }

        private void OnKeyPress(object sender, KeyEventArgs e)
        {
            _player1.Move(e.Key);
            _player2.Move(e.Key);

            
            if (e.Key == Key.Left || e.Key == Key.Right || e.Key == Key.Up || e.Key == Key.Down)
            {
                _ball.Move(_player1.X - _ball.X, _player1.Y - _ball.Y);
            }
            public void ShowScores(int scoreLeft,int scoreRight)
            {

            }
        }

    }
}
