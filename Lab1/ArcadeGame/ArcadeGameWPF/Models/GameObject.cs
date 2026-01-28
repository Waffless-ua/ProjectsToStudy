using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeGameWPF.Models
{
    public class GameObject : INotifyPropertyChanged
    {
        private double _positionX;
        public double PositionX
        {
            get => _positionX;
            set
            {
                _positionX = value;
                OnPropertyChanged();
            }
        }

        private double _positionY;
        public double PositionY
        {
            get => _positionY;
            set
            {
                _positionY = value;
                OnPropertyChanged();
            }
        }

        private double _sizeX;
        public double SizeX
        {
            get => _sizeX;
            set
            {
                _sizeX = value;
                OnPropertyChanged();
            }
        }

        private double _sizeY;
        public double SizeY
        {
            get => _sizeY;
            set
            {
                _sizeY = value;
                OnPropertyChanged();
            }
        }


        public GameObject(double positionX, double positionY, double sizex, double sizey)
        {
            PositionX = positionX;
            PositionY = positionY;
            SizeX = sizex;
            SizeY = sizey;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = null)
                    => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
