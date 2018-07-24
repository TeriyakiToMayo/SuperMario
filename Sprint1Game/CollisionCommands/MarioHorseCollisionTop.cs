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
using Sprint1Game.Sound;

namespace Sprint1Game.CollisionCommands
{
    class MarioHorseCollisionTop : ICollisionCommand
    {
        public MarioHorseCollisionTop()
        {

        }

        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IMario mario = (IMario)gameObject1;
            IEnemy horse = (IEnemy)gameObject2;
            if (mario.State.MarioShape == MarioState.MarioShapeEnums.Dead || !horse.Alive)
            {
                return;
            }

            mario.Location = new Vector2(mario.Location.X, horse.Location.Y - mario.Destination.Height + GameUtilities.SinglePixel);
            if (horse.Alive)
            {
                mario.Velocity = new Vector2(mario.Velocity.X, GameUtilities.MarioBounceVelocity);
                ScoringSystem.Player1Score.AddPointsForStompingEnemy(gameObject2);
                horse.Terminate("TOP");
                SoundManager.Instance.PlayStompSound();
            }
        }
    }
}

