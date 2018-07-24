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
    class GMushroomBlockCollisionTop : ICollisionCommand
    {
        public GMushroomBlockCollisionTop()
        {

        }

        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            if (gameObject2.GetType() == typeof(HiddenBlock))
            {
                HiddenBlock hiddenBlock = (HiddenBlock)gameObject2;
                if (!hiddenBlock.Used) return;
            }

            GreenMushroom greenMushroom = (GreenMushroom)gameObject1;
            if (greenMushroom.IsPreparing)
            {
                return;
            }
            greenMushroom.Location = new Vector2(greenMushroom.Location.X, gameObject2.Location.Y - greenMushroom.Destination.Height);
            greenMushroom.Velocity = new Vector2(greenMushroom.Velocity.X, GameUtilities.StationaryVelocity);
        }
    }
}