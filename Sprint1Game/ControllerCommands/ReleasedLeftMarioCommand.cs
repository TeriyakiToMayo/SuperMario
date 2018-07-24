using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game
{
    class ReleasedLeftMarioCommand : ICommand
    {
        private IMario mario;

        public ReleasedLeftMarioCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            if (mario.State.MarioPosture == MarioState.MarioPostureEnums.Running)
            {
                mario.State.ChangeToRight();
            }
        }
    }
}
