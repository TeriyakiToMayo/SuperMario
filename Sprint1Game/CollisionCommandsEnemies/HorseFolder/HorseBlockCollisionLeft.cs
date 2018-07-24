using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint1Game.Interfaces;
using Sprint1Game.GameObjects.EnemyGameObjects;

namespace Sprint1Game
{
    class HorseBlockCollisionLeft : ICollisionCommand
    {
        public HorseBlockCollisionLeft()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Horse h = (Horse)gameObject1;
            int horsePreY = (int)(h.Location.Y - (h.Velocity.Y - GameUtilities.SinglePixel));
            if (horsePreY + h.Destination.Height <= gameObject2.Location.Y)
            {
                return;
            }

            else if (horsePreY > gameObject2.Location.Y + gameObject2.Destination.Height)
            {
                return;
            }
            if (h.Velocity.X > GameUtilities.StationaryVelocity)
            {
                h.ChangeDirection();
            }
        }
    }
}

