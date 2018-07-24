using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint1Game.Interfaces;
using Sprint1Game.GameObjects.EnemyGameObjects;
using Microsoft.Xna.Framework;

namespace Sprint1Game
{
    class HorseBlockCollisionBottom:ICollisionCommand
    {
        public HorseBlockCollisionBottom()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Horse h = (Horse)gameObject1;

            if (!h.Alive)
            {
                return;
            }
            h.Location = new Vector2(h.Location.X, gameObject2.Location.Y + gameObject2.Destination.Height);
            if (h.Velocity.Y > GameUtilities.StationaryVelocity)
            {
                h.Velocity = new Vector2(h.Velocity.X, GameUtilities.StationaryVelocity);
            }
        }
    }
}