using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ArcadeGameWPF.Enums
{
    public enum KeyAction
    {
        Up,
        Down,
        Left,
        Right,
        Shot
    }
    public static class KeyBindings
    {
        public static readonly Dictionary<Key, KeyAction> Default = new Dictionary<Key, KeyAction>()
        {
            { Key.W, KeyAction.Up },
            { Key.S, KeyAction.Down },
            { Key.A, KeyAction.Left },
            { Key.D, KeyAction.Right },
            { Key.Space, KeyAction.Shot }
        };
    }
}
