using ArcadeGameWPF.API;
using ArcadeGameWPF.Enums;
using ArcadeGameWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ArcadeGameWPF.Engine
{
    public class BulletEngine : IEngine
    {
        private PlayerObject Player;
        private ObservableCollection<BulletObject> BulletObjects;
        public int MapSizeX { get; set; }
        public int MapSizeY { get; set; }
        private HashSet<KeyAction> KeysPressed { get; set; }
        public BulletEngine(PlayerObject player,
            ObservableCollection<BulletObject> bulletObjects,
            int mapSizeX, int mapSizeY, HashSet<KeyAction> _keysPressed)
        {
            Player = player;
            BulletObjects = bulletObjects;
            MapSizeX = mapSizeX;
            MapSizeY = mapSizeY;
            KeysPressed = _keysPressed;
        }

        public double LastSpawn { get; set; } = -10;
        public double SpawnInterval { get; set; } = 0.5;


        public void Loop(double deltatime, double globalTime)
        {
            MoveBullet(deltatime);
            SpawnBullet(globalTime);
        }
        public void MoveBullet(double deltatime)
        {
            foreach (BulletObject bulletObject in BulletObjects)
            {
                double distance = bulletObject.Speed * deltatime;
                bulletObject.PositionY -= distance;
            }
        }
        public void SpawnBullet(double globalTime)
        {
            if (KeysPressed.Contains(KeyAction.Shot))
            {
                if (globalTime - LastSpawn > SpawnInterval)
                {
                    var bullet = new BulletObject();

                    bullet.PositionX = Player.PositionX + Player.SizeX / 4;
                    bullet.PositionY = Player.PositionY - Player.SizeY / 2;

                    LastSpawn = globalTime;
                    BulletObjects.Add(bullet);
                    Debug.Write(bullet);
                }
            }
        }
    }
}
