using Sprint1Game.GameObjects;
using Sprint1Game.Interfaces;
using Sprint1Game.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.CollisionCommands
{
    class FireBallRightCollision : ICollisionCommand
    {
        public FireBallRightCollision()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            FireBallProjectile fireBall = (FireBallProjectile)gameObject1;
            int fireBallPreY = (int)(fireBall.Destination.Y - (fireBall.Velocity.Y - GameUtilities.SinglePixel));
            if (fireBallPreY + fireBall.Destination.Height <= gameObject2.Destination.Y)
            {
                return;
            }

            else if (fireBallPreY > gameObject2.Destination.Y + gameObject2.Destination.Height)
            {
                return;
            }
            fireBall.Terminate();
            SoundManager.Instance.PlayBumpSound();
        }
    }
}
