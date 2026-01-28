using ArcadeGameWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeGameWPF.Models
{
    public class PlayerObject : GameObject
    {
        public double Speed { get; set; }
        public int Damage { get; set; }

        private int health;
        public int Health
        {
            get => health;
            set
            {
                if (health != value)
                {
                    health = value;
                    OnPropertyChanged();
                }
            }
        }
        public PlayerObject() : base(0, 0, 0, 0)
        {
            PositionX = 0;
            PositionY = 0;
            SizeX = 50;
            SizeY = 50;
            Speed = 300;
            Damage = 1;
            Health = 3;
        }
        public PlayerObject(double px, double py, double sx, double sy, double speed) : base(px, py, sx, sy)
        {
            PositionX = px;
            PositionY = py;
            SizeX = sx; 
            SizeY = sy;
            Speed = speed;

        }
    }
}
