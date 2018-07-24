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
    class HorseKoopaCollisionBottom : ICollisionCommand
    {
        public HorseKoopaCollisionBottom()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IEnemy horse = (IEnemy)gameObject1;
            if (!horse.Alive)
                return;
            gameObject2.Location = new Vector2(gameObject2.Location.X, horse.Location.Y - gameObject2.Destination.Height - GameUtilities.SinglePixel);
        }
    }
}