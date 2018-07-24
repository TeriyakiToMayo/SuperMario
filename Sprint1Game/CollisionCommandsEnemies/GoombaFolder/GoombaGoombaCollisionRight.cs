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
    class GoombaGoombaCollisionRight : ICollisionCommand
    {
        public GoombaGoombaCollisionRight()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Goomba2 goomba1 = (Goomba2)gameObject1;
            Goomba2 goomba2 = (Goomba2)gameObject2;
            goomba1.Location = new Vector2(goomba1.Location.X + GameUtilities.SinglePixel, goomba1.Location.Y);
            goomba1.ChangeDirection();
            goomba2.ChangeDirection();
        }
    }
}
