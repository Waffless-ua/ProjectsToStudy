using ArcadeGameWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ArcadeGameWPF.Engine
{
    public class PlayerEngine
    {
        private PlayerObject Player;
        public int MapSizeX { get; set; }
        public int MapSizeY { get; set; }
        public PlayerEngine(PlayerObject player, int mapSizeX, int mapSizeY)
        {
            Player = player;
            MapSizeX = mapSizeX;
            MapSizeY = mapSizeY;



            Player.PositionX = MapSizeX / 2;
            Player.PositionY = MapSizeY / 2;

        }
        public HashSet<string> _keysPressed = new HashSet<string>();
        public void PlayerLoop(double deltaTime)
        {
            double distance = Player.Speed * deltaTime;

            foreach (var dir in _keysPressed)
            {
                switch (dir)
                {
                    case "Left": 
                        if (Player.PositionX - distance > 0)
                            Player.PositionX -= distance; 
                        break;
                    case "Right":
                        if (Player.PositionX + Player.SizeX + distance < MapSizeX)
                            Player.PositionX += distance; 
                        break;
                    case "Up":
                        if (Player.PositionY - distance > 0)
                            Player.PositionY -= distance; 
                        break;
                    case "Down":
                        if (Player.PositionY + Player.SizeY + distance < MapSizeY)
                            Player.PositionY += distance; 
                        break;
                }
            }
        }
    }
}
