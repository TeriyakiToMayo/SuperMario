using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.Commands
{
    class ReleasedDownMarioCommand : ICommand
    {
        private IMario mario;

        public ReleasedDownMarioCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            if ((mario.State.MarioShape == MarioState.MarioShapeEnums.Small ||
                mario.State.MarioShape == MarioState.MarioShapeEnums.StarSmall) &&
                mario.State.MarioPosture == MarioState.MarioPostureEnums.Crouch)
            {
                mario.State.MarioPosture = MarioState.MarioPostureEnums.Stand;
                return;
            }

            if (mario.State.MarioPosture == MarioState.MarioPostureEnums.Crouch)
            {
                mario.State.JumpOrStand();
            }
        }
    }
}
