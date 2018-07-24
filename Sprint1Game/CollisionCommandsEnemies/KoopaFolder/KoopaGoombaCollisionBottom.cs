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
    class KoopaGoombaCollisionBottom : ICollisionCommand
    {
        public KoopaGoombaCollisionBottom()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Koopa2 koopa = (Koopa2)gameObject1;
            if (koopa.State.GetType() == typeof(KoopaSideDeathState))
            {
                return;
            }
            Goomba2 goomba = (Goomba2)gameObject2;
            if (!goomba.Alive)
                return;
            goomba.Location = new Vector2(goomba.Location.X, koopa.Location.Y - gameObject2.Destination.Height - GameUtilities.SinglePixel);
        }
    }
}
