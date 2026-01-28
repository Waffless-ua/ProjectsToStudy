using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeGameWPF.Models
{
    public class EnemyObject : GameObject
    {
        public double Speed { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public EnemyObject() : base(0, 0, 0, 0)
        {
            PositionX = 0;
            PositionY = 0;
            SizeX = 50;
            SizeY = 50;
            Speed = 30;
            Damage = 1;
            Health = 1;
        }
        public EnemyObject(double px, double py, double sx, double sy, double speed) : base(px, py, sx, sy)
        {
            PositionX = px;
            PositionY = py;
            SizeX = sx;
            SizeY = sy;
            Speed = speed;
        }
    }
}