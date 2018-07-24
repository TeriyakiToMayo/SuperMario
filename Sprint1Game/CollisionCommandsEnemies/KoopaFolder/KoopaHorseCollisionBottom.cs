using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Sprint1Game.GameObjects;
using Sprint1Game.GameObjects.EnemyGameObjects;
using Sprint1Game.Interfaces;
using Sprint1Game.States.EnemyStates;

namespace Sprint1Game.CollisionCommandsEnemies
{
    class KoopaHorseCollisionBottom : ICollisionCommand
    {
        public KoopaHorseCollisionBottom()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Koopa2 koopa = (Koopa2)gameObject1;
            if (koopa.State.GetType() == typeof(KoopaSideDeathState))
            {
                return;
            }
            Horse horse = (Horse)gameObject2;
            if (!horse.Alive)
                return;
            horse.Location = new Vector2(horse.Location.X, koopa.Location.Y - gameObject2.Destination.Height - GameUtilities.SinglePixel);
        }
    }
}
