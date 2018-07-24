using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.Commands
{
    class ReleasedRightMarioCommand : ICommand
    {
        private IMario mario;

        public ReleasedRightMarioCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            if(mario.State.MarioPosture == MarioState.MarioPostureEnums.Running)
            {
                mario.State.ChangeToLeft();
            }
        }
    }
}
