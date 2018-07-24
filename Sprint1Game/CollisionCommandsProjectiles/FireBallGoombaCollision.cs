using Sprint1Game.GameObjects;
using Sprint1Game.HeadsUp;
using Sprint1Game.Interfaces;
using Sprint1Game.Sound;
using Sprint1Game.States.EnemyStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.CollisionCommandsEnemies
{
    class FireBallGoombaCollision : ICollisionCommand
    {
        public FireBallGoombaCollision()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            FireBallProjectile fireBall = (FireBallProjectile)gameObject1;
            Goomba2 enemy = (Goomba2)gameObject2;
            if (!enemy.Alive)
            {
                return;
            }
            if(enemy.State.GetType() != typeof(GoombaDeadState))
            {
                fireBall.Terminate();
                ScoringSystem.AddPointsForFireballGoombaHit(gameObject2, fireBall.InitiatingPlayer);
                enemy.Terminate("LEFT");
                SoundManager.Instance.PlayKickSound();
            }          
        }
    }
}