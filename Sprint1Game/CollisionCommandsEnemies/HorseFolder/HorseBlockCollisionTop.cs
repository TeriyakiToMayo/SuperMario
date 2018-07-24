using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint1Game.Interfaces;
using Sprint1Game.GameObjects;
using Sprint1Game.GameObjects.EnemyGameObjects;
using Microsoft.Xna.Framework;


namespace Sprint1Game
{
    class HorseBlockCollisionTop : ICollisionCommand
    {
        public HorseBlockCollisionTop()
        {

        }

        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {

            if (gameObject2.GetType() == typeof(HiddenBlock))
            {
                HiddenBlock hiddenBlock = (HiddenBlock)gameObject2;
                if (!hiddenBlock.Used) return;
            }

            Horse horse = (Horse)gameObject1;
            if (!horse.Alive)
            {
                return;
            }
            horse.Location = new Vector2(horse.Location.X, gameObject2.Location.Y - horse.Destination.Height);
            horse.Velocity = new Vector2(horse.Velocity.X, GameUtilities.StationaryVelocity);
        }
    }
}
