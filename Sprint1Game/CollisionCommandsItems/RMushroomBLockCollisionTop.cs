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
    class RMushroomBlockCollisionTop : ICollisionCommand
    {
        public RMushroomBlockCollisionTop()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            if (gameObject2.GetType() == typeof(HiddenBlock))
            {
                HiddenBlock hiddenBlock = (HiddenBlock)gameObject2;
                if (!hiddenBlock.Used) return;
            }

            RedMushroom redMushroom = (RedMushroom)gameObject1;
            if (redMushroom.IsPreparing)
            {
                return;
            }
            redMushroom.Location = new Vector2(redMushroom.Location.X, gameObject2.Location.Y - redMushroom.Destination.Height);

            redMushroom.Velocity = new Vector2(redMushroom.Velocity.X, GameUtilities.StationaryVelocity);
        }
    }
}
