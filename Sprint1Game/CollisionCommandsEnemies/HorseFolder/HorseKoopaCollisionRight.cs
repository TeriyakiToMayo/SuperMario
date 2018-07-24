using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint1Game.Interfaces;
using Sprint1Game.GameObjects;
using Sprint1Game.GameObjects.EnemyGameObjects;
using Microsoft.Xna.Framework;
using Sprint1Game.States.EnemyStates;
using Sprint1Game.HeadsUp;

namespace Sprint1Game
{
    class HorseKoopaCollisionRight : ICollisionCommand
    {
        public HorseKoopaCollisionRight()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Horse horse = (Horse)gameObject1;
            Koopa2 koopa = (Koopa2)gameObject2;
            if (!horse.Alive)
                return;
            horse.Location = new Vector2(horse.Location.X + GameUtilities.SinglePixel, horse.Location.Y);
            
            if (koopa.State.GetType() == typeof(KoopaDeadState) &&
                koopa.Velocity.X != GameUtilities.StationaryVelocity)
            {
                ScoringSystem.Player1Score.AddPointsForEnemyHitByShell(gameObject2);
                horse.Terminate("RIGHT");
                return;
            }
            horse.ChangeDirection();
            koopa.ChangeDirection();
        }
    }
}
