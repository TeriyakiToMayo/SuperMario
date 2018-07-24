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
    class HorseHorseCollisionLeft : ICollisionCommand
    {
        public HorseHorseCollisionLeft()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Horse horse1 = (Horse)gameObject1;
            Horse horse2 = (Horse)gameObject2;
            horse1.Location = new Vector2(horse1.Location.X - GameUtilities.SinglePixel, horse1.Location.Y);
            horse1.ChangeDirection();
            horse2.ChangeDirection();
        }
    }
}