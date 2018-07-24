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
    class MarioHorseCollisionBottom : ICollisionCommand
    {
        public MarioHorseCollisionBottom()
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
            ScoringSystem.Player1Score.AddPointsForStompingEnemy(gameObject2);
            horse.Terminate("LEFT");
            SoundManager.Instance.PlayStompSound();
        }
    }
}