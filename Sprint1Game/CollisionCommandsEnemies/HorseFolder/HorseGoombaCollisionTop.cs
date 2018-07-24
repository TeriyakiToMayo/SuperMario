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
    class HorseGoombaCollisionTop : ICollisionCommand
    {
        public HorseGoombaCollisionTop()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Horse horse = (Horse)gameObject1;
            horse.Location = new Vector2(horse.Location.X, gameObject2.Location.Y - horse.Destination.Height);
        }
    }
}

