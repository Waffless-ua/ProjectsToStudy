using ArcadeGameWPF.API;
using ArcadeGameWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeGameWPF.Engine
{
    public class EnemyEngine : IEngine
    {
        private Random random = new Random();

        private ObservableCollection<EnemyObject> EnemyObjects;
        public int MapSizeX { get; set; }
        public int MapSizeY { get; set; }


        public double LastSpawn {  get; set; } = 0;
        public double SpawnInterval { get; set; } = 5;


        public EnemyEngine(ObservableCollection<EnemyObject> enemyObjects,
            int mapSizeX, int mapSizeY) 
        {
            EnemyObjects = enemyObjects;
            MapSizeX = mapSizeX;
            MapSizeY = mapSizeY;
        }


        public void Loop(double deltatime, double globalTime)
        {
            if (globalTime - LastSpawn > SpawnInterval)
            {
                SpawnEnemy();
                LastSpawn = globalTime;
            }
            MoveEnemies(deltatime);
        }


        public void MoveEnemies(double deltatime)
        {
            foreach (EnemyObject enemy in EnemyObjects)
            {
                double distance = enemy.Speed * deltatime;
                enemy.PositionY += distance;
                Debug.WriteLine(enemy.PositionY);
            }
        }


        public void SpawnEnemy()
        {
            var enemy = new EnemyObject();
            var spawnPositionX = 0 + enemy.SizeX + random.Next(1, (int)(MapSizeX - 1 - enemy.SizeX));
            var spawnPositionY = 0 - enemy.SizeY - random.Next(5, 50);

            enemy.PositionX = spawnPositionX;
            enemy.PositionY = spawnPositionY;

            EnemyObjects.Add(enemy);
        }

    }
}
