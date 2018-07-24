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
    class GoombaGoombaCollisionTop : ICollisionCommand
    {
        public GoombaGoombaCollisionTop()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Goomba2 goomba1 = (Goomba2)gameObject1;
            goomba1.Location = new Vector2(goomba1.Location.X, gameObject2.Location.Y - goomba1.Destination.Height);
        }
    }
}
