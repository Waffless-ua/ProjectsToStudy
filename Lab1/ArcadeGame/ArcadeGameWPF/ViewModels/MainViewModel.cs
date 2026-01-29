using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeGameWPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public BaseViewModel CurrentViewModel { get; private set; }

        public MainViewModel() 
        {
            CurrentViewModel = new GameEnvironmentViewModel();
        }
    }
}
