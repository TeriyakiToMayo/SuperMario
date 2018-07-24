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
    class GoombaBlockCollisionTop : ICollisionCommand
    {
        public GoombaBlockCollisionTop()
        {

        }

        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            
            if (gameObject2.GetType() == typeof(HiddenBlock))
            {
                HiddenBlock hiddenBlock = (HiddenBlock)gameObject2;
                if (!hiddenBlock.Used) return;
            }

            Goomba2 goomba = (Goomba2)gameObject1;
            if (!goomba.Alive)
            {
                  return;
            }
            goomba.Location = new Vector2(goomba.Location.X, gameObject2.Location.Y - goomba.Destination.Height);
            goomba.Velocity = new Vector2(goomba.Velocity.X, GameUtilities.StationaryVelocity);
        }
    }
}
