using ArcadeGameWPF.Commands;
using ArcadeGameWPF.Engine;
using ArcadeGameWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace ArcadeGameWPF.ViewModels
{
    public class GameEnvironmentViewModel : BaseViewModel
    {
        private PlayerObject _player;
        public PlayerObject Player
        {
            get => _player;
            set
            {
                _player = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<EnemyObject> _enemies;
        public ObservableCollection<EnemyObject> Enemies
        {
            get => _enemies;
            set
            {
                _enemies = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<BulletObject> _bullets;
        public ObservableCollection<BulletObject> Bullets
        {
            get => _bullets;
            set
            {
                _bullets = value;
                OnPropertyChanged();
            }
        }

        private DateTime _lastRender;

        public GameEngine gameEngine { get; set; }


        public int MapSizeX { get; set; } = 1280;
        public int MapSizeY { get; set; } = 720;

        public GameEnvironmentViewModel()
        {
            Player = new PlayerObject();
            Enemies = new ObservableCollection<EnemyObject>();
            Bullets = new ObservableCollection<BulletObject>();
            gameEngine = new GameEngine(Player, Enemies, Bullets, MapSizeX, MapSizeY);



            CompositionTarget.Rendering += gameEngine.GameLoop;
        }
        public void OnWindowSizeChange(double width, double height)
        {
            Player.PositionX = (width - Player.SizeX) / 2;
            Player.PositionY = (height - Player.SizeY) / 2;
        }


        private void GameLoop(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            var deltaTime = (now - _lastRender).TotalSeconds;
            _lastRender = now;

            double distance = Player.Speed * deltaTime;
        }

        public void OnKeyDown(Key key)
        {
            switch (key)
            {
                case Key.W: gameEngine.playerEngine._keysPressed.Add("Up"); break;
                case Key.S: gameEngine.playerEngine._keysPressed.Add("Down"); break;
                case Key.A: gameEngine.playerEngine._keysPressed.Add("Left"); break;
                case Key.D: gameEngine.playerEngine._keysPressed.Add("Right"); break;
                case Key.Space: gameEngine.bulletEngine._keysPressed.Add("Space"); break;
            }
        }

        public void OnKeyUp(Key key)
        {
            switch (key)
            {
                case Key.W: gameEngine.playerEngine._keysPressed.Remove("Up"); break;
                case Key.S: gameEngine.playerEngine._keysPressed.Remove("Down"); break;
                case Key.A: gameEngine.playerEngine._keysPressed.Remove("Left"); break;
                case Key.D: gameEngine.playerEngine._keysPressed.Remove("Right"); break;
                case Key.Space: gameEngine.bulletEngine._keysPressed.Remove("Space"); break;
            }
        }



    }
}
