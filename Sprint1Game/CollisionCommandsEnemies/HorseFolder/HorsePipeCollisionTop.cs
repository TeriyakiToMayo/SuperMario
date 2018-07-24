using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint1Game.Interfaces;
using Sprint1Game.GameObjects;
using Sprint1Game.GameObjects.EnemyGameObjects;
using Microsoft.Xna.Framework;
using Sprint1Game.GameObjects.PipeGameObjects;


namespace Sprint1Game
{
    class HorsePipeCollisionTop : ICollisionCommand
    {
        public HorsePipeCollisionTop()
        {

        }

        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            if (gameObject2.GetType() == typeof(HiddenBlock))
            {
                HiddenBlock hiddenBlock = (HiddenBlock)gameObject2;
                if (!hiddenBlock.Used) return;
            }

            Horse goomba = (Horse)gameObject1;
            if (!goomba.Alive)
            {
                return;
            }

            if (gameObject2.GetType() == typeof(LPipeBottom) ||
                gameObject2.GetType() == typeof(LPipeBottomLeft))
            {
                return;
            }

            goomba.Location = new Vector2(goomba.Location.X, gameObject2.Location.Y - goomba.Destination.Height);
            goomba.Velocity = new Vector2(goomba.Velocity.X, GameUtilities.StationaryVelocity);
        }
    }
}
