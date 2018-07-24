using Microsoft.Xna.Framework;
using Sprint1Game.GameObjects;
using Sprint1Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.CollisionCommandsEnemies
{
    class GoombaBlockCollisionLeft : ICollisionCommand
    {
        public GoombaBlockCollisionLeft()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Goomba2 goomba = (Goomba2)gameObject1;
            int goombaPreY = (int)(goomba.Location.Y - (goomba.Velocity.Y - GameUtilities.SinglePixel));
            if (goombaPreY + goomba.Destination.Height <= gameObject2.Location.Y)
            {
                return;
            }

            else if (goombaPreY > gameObject2.Location.Y + gameObject2.Destination.Height)
            {
                return;
            }
            if (goomba.Velocity.X > GameUtilities.StationaryVelocity)
            {
                goomba.ChangeDirection();
            }
        }
    }
}