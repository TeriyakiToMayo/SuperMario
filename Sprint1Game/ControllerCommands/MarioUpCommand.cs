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
    class MarioUpCommand : ICommand
    {
        private Mario mario;

        public MarioUpCommand(IMario mario)
        {
            this.mario = (Mario)mario;
        }
        public void Execute()
        {
            if(GameUtilities.Game.State.Type == Interfaces.GameStates.Title)
            {
                TitleDisplayPanel titlePanel = (TitleDisplayPanel)GameUtilities.GameObjectManager.TitlePanel;
                titlePanel.Up();
                return;
            }

            if(mario.CanJump)
            {
                mario.State.JumpOrStand();
            }
            
            mario.CanJump = false;
        }

    }
}
