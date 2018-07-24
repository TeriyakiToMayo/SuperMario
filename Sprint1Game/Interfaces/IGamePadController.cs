using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint1Game.Controllers.GamePadController;

namespace Sprint1Game.Interfaces
{
    public interface IGamePadController
    {
        void RegisterMario(IMario mario);
        void RegisterCommand(KeyboardKeys2 name, Buttons key, ICommand command);
        void RegisterReleasedCommand(KeyboardKeys2 name, Buttons key, ICommand command);
        void Update();
        void ClearAllCommandDicts();
    }
}
