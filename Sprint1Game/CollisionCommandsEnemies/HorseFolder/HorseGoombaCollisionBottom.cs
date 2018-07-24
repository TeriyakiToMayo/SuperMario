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
    class HorseGoombaCollisionBottom : ICollisionCommand
    {
        public HorseGoombaCollisionBottom()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Goomba2 goomba2 = (Goomba2)gameObject2;
            goomba2.Location = new Vector2(goomba2.Location.X, gameObject1.Location.Y - gameObject2.Destination.Height - GameUtilities.SinglePixel);
        }
    }
}
