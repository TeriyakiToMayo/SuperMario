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
using Sprint1Game.HeadsUp;

namespace Sprint1Game.CollisionCommandsEnemies
{
    class KoopaHorseCollisionRight : ICollisionCommand
    {
        public KoopaHorseCollisionRight()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Koopa2 koopa = (Koopa2)gameObject1;
            if (koopa.State.GetType() == typeof(KoopaSideDeathState))
            {
                return;
            }
            Horse goomba = (Horse)gameObject2;
            if (!goomba.Alive)
                return;
            koopa.Location = new Vector2(koopa.Location.X + GameUtilities.SinglePixel, koopa.Location.Y);
            if (koopa.State.GetType() == typeof(KoopaDeadState) &&
                koopa.Velocity.X != GameUtilities.StationaryVelocity)
            {
                ScoringSystem.Player1Score.AddPointsForEnemyHitByShell(gameObject1);
                goomba.Terminate("RIGHT");
                return;
            }
            koopa.ChangeDirection();
            goomba.ChangeDirection();
        }
    }
}
