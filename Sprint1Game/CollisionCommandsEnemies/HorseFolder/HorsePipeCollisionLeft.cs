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
    class HorsePipeCollisionLeft : ICollisionCommand
    {
        public HorsePipeCollisionLeft()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Horse horse = (Horse)gameObject1;
            if (!horse.Alive)
            {
                return;
            }
            if (gameObject2.GetType() == typeof(LPipeBottom) ||
                gameObject2.GetType() == typeof(LPipeBottomLeft))
            {
                return;
            }
            int horsePreY = (int)(horse.Location.Y - (horse.Velocity.Y - GameUtilities.SinglePixel));
            if (horsePreY + horse.Destination.Height <= gameObject2.Location.Y)
            {
                return;
            }

            else if (horsePreY > gameObject2.Location.Y + gameObject2.Destination.Height)
            {
                return;
            }
            if (horse.Velocity.X > GameUtilities.StationaryVelocity)
            {
                horse.ChangeDirection();
            }
        }
    }
}
