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
    class KoopaGoombaCollisionLeft : ICollisionCommand
    {
        public KoopaGoombaCollisionLeft()
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

            if (koopa.State.GetType() == typeof(KoopaDeadState) && 
                koopa.Velocity.X != GameUtilities.StationaryVelocity)
            {
                ScoringSystem.Player1Score.AddPointsForEnemyHitByShell(gameObject1);
                goomba.Terminate("LEFT");
                return;
            }

            koopa.Location = new Vector2(koopa.Location.X - GameUtilities.SinglePixel, koopa.Location.Y);
            koopa.ChangeDirection();
            goomba.ChangeDirection();
        }
    }
}
