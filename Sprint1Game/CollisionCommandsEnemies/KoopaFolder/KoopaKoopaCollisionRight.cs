using Microsoft.Xna.Framework;
using Sprint1Game.GameObjects;
using Sprint1Game.HeadsUp;
using Sprint1Game.Interfaces;
using Sprint1Game.States.EnemyStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.CollisionCommandsEnemies
{
    class KoopaKoopaCollisionRight : ICollisionCommand
    {
        public KoopaKoopaCollisionRight()
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

            if (koopa1.State.GetType() == typeof(KoopaDeadState) &&
                koopa1.Velocity.X != GameUtilities.StationaryVelocity)
            {
                ScoringSystem.Player1Score.AddPointsForEnemyHitByShell(gameObject1);
                koopa2.Terminate("DOWN");
                return;
            }
            if (koopa2.State.GetType() == typeof(KoopaDeadState) &&
                koopa2.Velocity.X != GameUtilities.StationaryVelocity)
            {
                ScoringSystem.Player1Score.AddPointsForEnemyHitByShell(gameObject2);
                koopa1.Terminate("DOWN");
                return;
            }

            koopa1.Location = new Vector2(koopa1.Location.X + GameUtilities.SinglePixel, koopa1.Location.Y);
            koopa1.ChangeDirection();
            koopa2.ChangeDirection();
        }
    }
}
