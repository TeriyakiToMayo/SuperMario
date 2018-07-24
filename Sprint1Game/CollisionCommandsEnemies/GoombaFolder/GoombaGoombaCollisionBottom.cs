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
    class GoombaGoombaCollisionBottom : ICollisionCommand
    {
        public GoombaGoombaCollisionBottom()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Goomba2 goomba2 = (Goomba2)gameObject2;
            goomba2.Location = new Vector2(goomba2.Location.X, gameObject1.Location.Y - gameObject2.Destination.Height - GameUtilities.SinglePixel);
        }
    }
}
