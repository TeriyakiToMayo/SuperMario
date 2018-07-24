using Sprint1Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.CollisionCommandsItems
{
    class RMushroomPipeCollisionRight : ICollisionCommand
    {
        public RMushroomPipeCollisionRight()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            RedMushroom redMushroom = (RedMushroom)gameObject1;
            int redMushroomPreY = (int)(redMushroom.Destination.Y - (redMushroom.Velocity.Y - GameUtilities.SinglePixel));
            if (redMushroomPreY + redMushroom.Destination.Height <= gameObject2.Destination.Y)
            {
                return;
            }

            else if (redMushroomPreY > gameObject2.Destination.Y + gameObject2.Destination.Height)
            {
                return;
            }
            redMushroom.ChangeDirection();
        }
    }
}