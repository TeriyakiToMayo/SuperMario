using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint1Game.KeyboardController;

namespace Sprint1Game.Interfaces
{
    public interface IController
    {
        void RegisterMario(IMario mario);
        void RegisterCommand(KeyboardKeys name, Keys key, ICommand command);
        void RegisterReleasedCommand(KeyboardKeys name, Keys key, ICommand command);
        bool IsFunctionKeysEnable { get; set; }
        void Update();

        void ClearAllCommandDicts();
    }
}
