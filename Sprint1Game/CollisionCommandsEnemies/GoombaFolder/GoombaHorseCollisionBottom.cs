using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Sprint1Game.GameObjects;
using Sprint1Game.GameObjects.EnemyGameObjects;
using Sprint1Game.Interfaces;

namespace Sprint1Game.CollisionCommandsEnemies
{
    class GoombaHorseCollisionBottom : ICollisionCommand
    {
        public GoombaHorseCollisionBottom()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Horse goomba2 = (Horse)gameObject2;
            goomba2.Location = new Vector2(goomba2.Location.X, gameObject1.Location.Y - gameObject2.Destination.Height - GameUtilities.SinglePixel);
        }
    }
}
