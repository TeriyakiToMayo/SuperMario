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
    class KoopaKoopaCollisionTop : ICollisionCommand
    {
        public KoopaKoopaCollisionTop()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Koopa2 koopa1 = (Koopa2)gameObject1;
            if (koopa1.State.GetType() == typeof(KoopaSideDeathState))
            {
                return;
            }
            Koopa2 koopa2 = (Koopa2)gameObject2;
            if (koopa2.State.GetType() == typeof(KoopaSideDeathState))
            {
                return;
            }
            koopa1.Location = new Vector2(koopa1.Location.X, gameObject2.Location.Y - koopa1.Destination.Height);
        }
    }
}
