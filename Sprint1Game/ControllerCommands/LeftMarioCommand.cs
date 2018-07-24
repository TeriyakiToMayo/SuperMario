using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint1Game.Interfaces;
using Microsoft.Xna.Framework;

namespace Sprint1Game.Commands
{
    class LeftMarioCommand : ICommand
    {
        private IMario mario;       

        public LeftMarioCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.State.ChangeToLeft();
        }
    }
}
