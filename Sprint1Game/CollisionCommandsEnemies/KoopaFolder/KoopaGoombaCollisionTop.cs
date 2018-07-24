using Microsoft.Xna.Framework;
using Sprint1Game.GameObjects;
using Sprint1Game.Interfaces;
using Sprint1Game.States.EnemyStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.CollisionCommandsEnemies
{
    class KoopaGoombaCollisionTop : ICollisionCommand
    {
        public KoopaGoombaCollisionTop()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Koopa2 koopa = (Koopa2)gameObject1;
            if (koopa.State.GetType() == typeof(KoopaSideDeathState))
            {
                return;
            }
            IEnemy goomba = (IEnemy)gameObject2;
            if (!goomba.Alive)
                return;
            koopa.Location = new Vector2(koopa.Location.X, gameObject2.Location.Y - koopa.Destination.Height);
        }
    }
}
