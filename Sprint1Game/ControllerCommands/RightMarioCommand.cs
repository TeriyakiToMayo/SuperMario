using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint1Game.Interfaces;
using Microsoft.Xna.Framework;

namespace Sprint1Game.Commands
{
    class RightMarioCommand : ICommand
    {
        private IMario mario;

        public RightMarioCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.State.ChangeToRight();
        }
    }
}
