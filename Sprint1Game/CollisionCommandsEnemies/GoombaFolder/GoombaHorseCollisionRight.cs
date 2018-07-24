using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Sprint1Game.GameObjects;
using Sprint1Game.Interfaces;
using Sprint1Game.GameObjects.EnemyGameObjects;

namespace Sprint1Game.CollisionCommandsEnemies
{
    class GoombaHorseCollisionRight : ICollisionCommand
    {
        public GoombaHorseCollisionRight()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Goomba2 goomba1 = (Goomba2)gameObject1;
            Horse horse = (Horse)gameObject2;
            goomba1.Location = new Vector2(goomba1.Location.X + GameUtilities.SinglePixel, goomba1.Location.Y);
            goomba1.ChangeDirection();
            horse.ChangeDirection();
        }
    }
}
