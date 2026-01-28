using ArcadeGameWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeGameWPF.Engine
{
    public class GameEngine
    {
        private DateTime _lastRender;
        public double GlobalTime { get; private set; }

        public PlayerEngine playerEngine;
        public EnemyEngine enemyEngine;
        public BulletEngine bulletEngine;
        public CollisionEngine collisionEngine;

        public int MapSizeX { get; set; }
        public int MapSizeY { get; set; }

        public GameEngine(PlayerObject player, 
            ObservableCollection<EnemyObject> enemyObjects, ObservableCollection<BulletObject> bulletObjects,
            int mapSizeX, int mapSizeY)
        {
            MapSizeX = mapSizeX;
            MapSizeY = mapSizeY;

            playerEngine = new PlayerEngine(player, mapSizeX, mapSizeY);
            enemyEngine = new EnemyEngine(enemyObjects, mapSizeX, mapSizeY);
            bulletEngine = new BulletEngine(player, bulletObjects, mapSizeX, mapSizeY);
            collisionEngine = new CollisionEngine(player, enemyObjects, bulletObjects, mapSizeX, mapSizeY);

            GlobalTime = 0;
            _lastRender = DateTime.Now;
        }
         
        public void GameLoop(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            var deltaTime = (now - _lastRender).TotalSeconds;
            _lastRender = now;

            GlobalTime += deltaTime;

            playerEngine.PlayerLoop(deltaTime);
            enemyEngine.EnemyLoop(deltaTime, GlobalTime);
            bulletEngine.BulletLoop(deltaTime, GlobalTime);
            collisionEngine.CollisionLoop(deltaTime, GlobalTime);


        }

    }
}