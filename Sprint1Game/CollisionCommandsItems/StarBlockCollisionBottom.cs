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
    class StarBlockCollisionBottom : ICollisionCommand
    {
        public StarBlockCollisionBottom()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            if (gameObject2.GetType() == typeof(HiddenBlock))
            {
                return;
            }

            Star star = (Star)gameObject1;
            if (star.IsPreparing)
            {
                return;
            }
            star.Location = new Vector2(star.Destination.X, gameObject2.Destination.Y + gameObject2.Destination.Height - GameUtilities.SinglePixel);
            star.Velocity = new Vector2(star.Velocity.X, -star.Velocity.Y);
        }
    }
}
