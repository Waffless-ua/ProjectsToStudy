using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeGameWPF.Models
{
    public class BulletObject : GameObject
    {
        public double Speed { get; set; }
        public BulletObject() : base(0, 0, 0, 0)
        {
            PositionX = 0;
            PositionY = 0;
            SizeX = 25;
            SizeY = 25;
            Speed = 400;
        }
        public BulletObject(double px, double py, double sx, double sy, double speed) : base(px, py, sx, sy)
        {
            PositionX = px;
            PositionY = py;
            SizeX = sx;
            SizeY = sy;
            Speed = speed;
        }
    }
}
