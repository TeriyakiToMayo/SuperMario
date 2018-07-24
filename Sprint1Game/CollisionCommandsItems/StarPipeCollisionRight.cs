using Sprint1Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.CollisionCommandsItems
{
    class StarPipeCollisionRight : ICollisionCommand
    {
        public StarPipeCollisionRight()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Star star = (Star)gameObject1;
            int starPreY = (int)(star.Destination.Y - (star.Velocity.Y - GameUtilities.SinglePixel));
            if (starPreY + star.Destination.Height <= gameObject2.Destination.Y)
            {
                return;
            }

            else if (starPreY > gameObject2.Destination.Y + gameObject2.Destination.Height)
            {
                return;
            }
            star.ChangeDirection();
        }
    }
}
