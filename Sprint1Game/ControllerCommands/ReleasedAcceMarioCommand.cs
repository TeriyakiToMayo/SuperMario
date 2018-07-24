using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.Commands
{
    class ReleasedAcceMarioCommand : ICommand
    {
        private IMario mario;

        public ReleasedAcceMarioCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.MarioTopSpeed = GameUtilities.MarioRegularSpeed;
        }
    }
}
