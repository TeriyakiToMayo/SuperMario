﻿using Sprint1Game.GameObjects;
using Sprint1Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.CollisionCommandsItems
{
    class StarBlockCollisionLeft : ICollisionCommand
    {
        public StarBlockCollisionLeft()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            if (gameObject2.GetType() == typeof(HiddenBlock))
            {
                HiddenBlock hiddenBlock = (HiddenBlock)gameObject2;
                if (!hiddenBlock.Used) return;
            }

            Star star = (Star)gameObject1;
            if (star.IsPreparing)
            {
                return;
            }
            int starPreY = (int)(star.Destination.Y - (star.Velocity.Y - GameUtilities.SinglePixel));
            if (starPreY + star.Destination.Height <= gameObject2.Destination.Y)
            {
                return;
            }

            else if (starPreY > gameObject2.Destination.Y + gameObject2.Destination.Height)
            {
                return;
            }
            if (star.Velocity.X > GameUtilities.StationaryVelocity)
            {
                star.ChangeDirection();
            }
        }
    }
}
