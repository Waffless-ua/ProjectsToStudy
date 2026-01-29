using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeGameWPF.API
{
    public interface IEngine
    {
        public void Loop(double deltaTime, double GlobalTime);

    }
}
