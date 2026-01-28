using ArcadeGameWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ArcadeGameWPF.Views
{
    /// <summary>
    /// Interaction logic for GameEnvironmentxaml.xaml
    /// </summary>
    public partial class GameEnvironment : UserControl
    {
        public GameEnvironment()
        {
            InitializeComponent();
            Loaded += (_, __) => Keyboard.Focus(this);
        }
        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (DataContext is GameEnvironmentViewModel vm)
                vm.OnKeyDown(e.Key);
        }

        private void UserControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (DataContext is GameEnvironmentViewModel vm)
                vm.OnKeyUp(e.Key);
        }
    }
}
