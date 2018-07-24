using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint1Game.Interfaces;
using Microsoft.Xna.Framework;
using Sprint1Game.DisplayPanel;

namespace Sprint1Game.Commands
{
    class MarioDownCommand : ICommand
    {
        private IMario mario;
        
        public MarioDownCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {

            if (GameUtilities.Game.State.Type == Interfaces.GameStates.Title)
            {
                TitleDisplayPanel titlePanel = (TitleDisplayPanel)GameUtilities.GameObjectManager.TitlePanel;
                titlePanel.Down();
                return;
            }

            mario.State.Crouch();

            if(mario.State.MarioShape == MarioState.MarioShapeEnums.Small ||
                mario.State.MarioShape == MarioState.MarioShapeEnums.StarSmall)
            {
                mario.State.MarioPosture = MarioState.MarioPostureEnums.Crouch;
            }
        }
    }
}
