using Microsoft.Xna.Framework;
using Sprint1Game.GameObjects;
using Sprint1Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.CollisionCommandsItems
{
    class StarPipeCollisionTop : ICollisionCommand
    {
        public StarPipeCollisionTop()
        {

        }

        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {

            Star star = (Star)gameObject1;

            star.Location = new Vector2(star.Destination.X, gameObject2.Destination.Y - star.Destination.Height);
            star.Velocity = new Vector2(star.Velocity.X, -5);
        }
    }
}
