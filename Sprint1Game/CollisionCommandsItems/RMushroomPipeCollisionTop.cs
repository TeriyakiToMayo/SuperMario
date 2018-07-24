﻿using Microsoft.Xna.Framework;
using Sprint1Game.GameObjects;
using Sprint1Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.CollisionCommandsItems
{
    class RMushroomPipeCollisionTop : ICollisionCommand
    {
        public RMushroomPipeCollisionTop()
        {

        }

        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IItem g = (IItem)gameObject1;

            g.Location = new Vector2(g.Destination.X, gameObject2.Destination.Y - g.Destination.Height);
            g.Velocity = new Vector2(g.Velocity.X, GameUtilities.StationaryVelocity);
        }
    }
}
