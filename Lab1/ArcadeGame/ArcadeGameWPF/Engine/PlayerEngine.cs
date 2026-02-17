using ArcadeGameWPF.API;
using ArcadeGameWPF.Enums;
using ArcadeGameWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ArcadeGameWPF.Engine
{
    public class PlayerEngine : IEngine
    {
        private PlayerObject Player;
        public int MapSizeX { get; set; }
        public int MapSizeY { get; set; }
        private HashSet<KeyAction> KeysPressed { get; set; }
        public PlayerEngine(PlayerObject player, int mapSizeX, int mapSizeY, HashSet<KeyAction> _keysPressed)
        {
            Player = player;
            MapSizeX = mapSizeX;
            MapSizeY = mapSizeY;
            KeysPressed = _keysPressed;



            Player.PositionX = MapSizeX / 2;
            Player.PositionY = MapSizeY / 2;

        }
        public void Loop(double deltaTime, double GlobalTime)
        {
            double distance = Player.Speed * deltaTime;

            foreach (var dir in KeysPressed)
            {
                switch (dir)
                {
                    case KeyAction.Left: 
                        if (Player.PositionX - distance > 0)
                            Player.PositionX -= distance; 
                        break;
                    case KeyAction.Right:
                        if (Player.PositionX + Player.SizeX + distance < MapSizeX)
                            Player.PositionX += distance; 
                        break;
                    case KeyAction.Up:
                        if (Player.PositionY - distance > 0)
                            Player.PositionY -= distance; 
                        break;
                    case KeyAction.Down:
                        if (Player.PositionY + Player.SizeY + distance < MapSizeY)
                            Player.PositionY += distance; 
                        break;
                }
            }
        }
    }
}
