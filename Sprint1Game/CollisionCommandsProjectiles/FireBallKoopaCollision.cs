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
    class FireBallKoopaCollision: ICollisionCommand
    {
        public FireBallKoopaCollision()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            FireBallProjectile fireBall = (FireBallProjectile)gameObject1;
            IEnemy enemy = (IEnemy)gameObject2;
            if (enemy.State.GetType() != typeof(KoopaSideDeathState))
            {
                fireBall.Terminate();
                ScoringSystem.AddPointsForFireballKoopaHit(gameObject2, fireBall.InitiatingPlayer);
                enemy.Terminate("DOWN");
                SoundManager.Instance.PlayKickSound();
            }
        }
    }
}
