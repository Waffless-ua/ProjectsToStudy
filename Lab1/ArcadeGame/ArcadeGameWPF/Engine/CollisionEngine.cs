using ArcadeGameWPF.API;
using ArcadeGameWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace ArcadeGameWPF.Engine
{
    public class CollisionEngine : IEngine
    {
        private PlayerObject Player;
        private ObservableCollection<EnemyObject> EnemyObjects;
        private ObservableCollection<BulletObject> BulletObjects;
        public int MapSizeX { get; set; }
        public int MapSizeY { get; set; }

        public CollisionEngine( 
            PlayerObject player,
            ObservableCollection<EnemyObject> enemyObjects,
            ObservableCollection<BulletObject> bulletObjects,
            int mapSizeX, int mapSizeY
            )
        {
            Player = player;
            EnemyObjects = enemyObjects;
            BulletObjects = bulletObjects;
        }

        public void Loop(double deltaTime, double globalTime)
        {
            CheckBulletsCollision();
            CheckPlayerCollision();
        }

        private void CheckBulletsCollision()
        {
            var bullets = BulletObjects.ToList();
            var enemies = EnemyObjects.ToList();

            foreach (var bullet in bullets)
            {
                foreach (var enemy in enemies)
                {
                    if (IsColliding(bullet, enemy))
                    {
                        BulletObjects.Remove(bullet);
                        EnemyObjects.Remove(enemy);
                        break;
                    }
                }
            }
        }

        private void CheckPlayerCollision()
        {
            foreach (var enemy in EnemyObjects.ToList())
            {
                if (IsColliding(Player, enemy))
                {
                    Player.Health -= enemy.Damage;

                    EnemyObjects.Remove(enemy);

                    if (Player.Health <= 0)
                    {
                        MessageBox.Show("Game Over!");
                    }
                }
            }
        }

        bool IsColliding(GameObject a, GameObject b)
        {
            return a.PositionX < b.PositionX + b.SizeX &&
                   a.PositionX + a.SizeX > b.PositionX &&
                   a.PositionY < b.PositionY + b.SizeY &&
                   a.PositionY + a.SizeY > b.PositionY;
        }

    }
}
