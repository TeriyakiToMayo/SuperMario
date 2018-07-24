using Sprint1Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.CollisionCommandsItems
{
    class GMushroomPipeCollisionLeft : ICollisionCommand
    {
        public GMushroomPipeCollisionLeft()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            GreenMushroom greenMushroom = (GreenMushroom)gameObject1;
            int greenMushroomPreY = (int)(greenMushroom.Destination.Y - (greenMushroom.Velocity.Y - GameUtilities.SinglePixel));
            if (greenMushroomPreY + greenMushroom.Destination.Height <= gameObject2.Destination.Y)
            {
                return;
            }

            else if (greenMushroomPreY > gameObject2.Destination.Y + gameObject2.Destination.Height)
            {
                return;
            }
            greenMushroom.ChangeDirection();
        }
    }
}
