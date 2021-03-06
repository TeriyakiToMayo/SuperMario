﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint1Game.Interfaces;
using Microsoft.Xna.Framework;
using Sprint1Game.GameObjects;

namespace Sprint1Game.Commands
{
    public class MarioBlockCollisionLeftCommand : ICollisionCommand
    {
        public MarioBlockCollisionLeftCommand()
        {

        }

        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IMario mario = (IMario)gameObject1;
            if (mario.State.MarioShape == MarioState.MarioShapeEnums.Dead)
            {
                return;
            }
            if (gameObject2.GetType() == typeof(HiddenBlock))
            {
                HiddenBlock hiddenBlock = (HiddenBlock)gameObject2;
                if (!hiddenBlock.Used) return;
            }

            
            int marioPreY = (int)(mario.Destination.Y - (mario.Velocity.Y - GameUtilities.SinglePixel));
            if (marioPreY + mario.Destination.Height < gameObject2.Destination.Y)
            {
                ICollisionCommand TopCommand = new MarioBlockCollisionTopCommand();

                TopCommand.Execute(gameObject1, gameObject2);
                return;
            }
            
            else if (marioPreY > gameObject2.Destination.Y + gameObject2.Destination.Height)
            {
                return;
            }

            mario.Location = new Vector2(gameObject2.Destination.X - mario.Destination.Width - GameUtilities.SinglePixel, mario.Destination.Y);
            if(mario.Velocity.X > 0)
            {
                mario.Velocity = new Vector2(GameUtilities.StationaryVelocity, mario.Velocity.Y);
            }
            
        }
    }
}
