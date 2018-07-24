using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint1Game.GameObjects;
using Sprint1Game.HeadsUp;
using Sprint1Game.Interfaces;
using Sprint1Game.Sound;
using Sprint1Game.GameObjects.EnemyGameObjects;

namespace Sprint1Game.CollisionCommandsProjectiles
{
    class FireBallHorseCollision : ICollisionCommand
    {
        public FireBallHorseCollision()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            FireBallProjectile fireBall = (FireBallProjectile)gameObject1;
            Horse enemy = (Horse)gameObject2;
            if (!enemy.Alive)
            {
                return;
            }
            if (enemy.Alive)
            {
                fireBall.Terminate();
                ScoringSystem.AddPointsForFireballGoombaHit(gameObject2, fireBall.InitiatingPlayer);
                enemy.Terminate("LEFT");
                SoundManager.Instance.PlayKickSound();
            }
        }
    }
}
