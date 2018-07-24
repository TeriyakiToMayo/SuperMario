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
    class KoopaHorseCollisionTop : ICollisionCommand
    {
        public KoopaHorseCollisionTop()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Koopa2 koopa = (Koopa2)gameObject1;
            if (koopa.State.GetType() == typeof(KoopaSideDeathState))
            {
                return;
            }
            IEnemy horse = (IEnemy)gameObject2;
            if (!horse.Alive)
                return;
            koopa.Location = new Vector2(koopa.Location.X, gameObject2.Location.Y - koopa.Destination.Height);
        }
    }
}
