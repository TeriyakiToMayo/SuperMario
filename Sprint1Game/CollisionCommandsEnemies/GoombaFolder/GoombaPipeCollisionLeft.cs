using Microsoft.Xna.Framework;
using Sprint1Game.GameObjects;
using Sprint1Game.GameObjects.PipeGameObjects;
using Sprint1Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.CollisionCommandsEnemies
{
    class GoombaPipeCollisionLeft : ICollisionCommand
    {
        public GoombaPipeCollisionLeft()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Goomba2 goomba = (Goomba2)gameObject1;
            if (!goomba.Alive)
            {
                return;
            }
            if (gameObject2.GetType() == typeof(LPipeBottom) ||
                gameObject2.GetType() == typeof(LPipeBottomLeft))
            {
                return;
            }
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
