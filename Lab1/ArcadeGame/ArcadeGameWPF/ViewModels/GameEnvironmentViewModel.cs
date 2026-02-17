using ArcadeGameWPF.Commands;
using ArcadeGameWPF.Engine;
using ArcadeGameWPF.Enums;
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

        public void OnKeyDown(Key key)
        {
            if (KeyBindings.Default.TryGetValue(key, out var action))
                gameEngine._actionsPressed.Add(action);
        }

        public void OnKeyUp(Key key)
        {
            if (KeyBindings.Default.TryGetValue(key, out var action))
                gameEngine._actionsPressed.Remove(action);
        }
    }
}
