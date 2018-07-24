using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.Commands
{
    class ReleasedUpMarioCommand : ICommand
    {
        private Mario mario;

        public ReleasedUpMarioCommand(IMario mario)
        {
            this.mario = (Mario)mario;
        }
        public void Execute()
        {
            mario.CanJump = true;
        }
    }
}
