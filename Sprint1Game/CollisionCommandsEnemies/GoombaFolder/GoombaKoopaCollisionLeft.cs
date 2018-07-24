﻿using Microsoft.Xna.Framework;
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
    class GoombaKoopaCollisionLeft : ICollisionCommand
    {
        public GoombaKoopaCollisionLeft()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Goomba2 goomba = (Goomba2)gameObject1;
            Koopa2 koopa = (Koopa2)gameObject2;
            goomba.Location = new Vector2(goomba.Location.X - GameUtilities.SinglePixel, goomba.Location.Y);

            if (!goomba.Alive)
                return;
            if (koopa.State.GetType() == typeof(KoopaDeadState) &&
                koopa.Velocity.X != GameUtilities.StationaryVelocity)
            {
                ScoringSystem.Player1Score.AddPointsForEnemyHitByShell(gameObject2);
                goomba.Terminate("LEFT");
                return;
            }
            goomba.ChangeDirection();
            koopa.ChangeDirection();
        }
    }
}
