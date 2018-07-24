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
    class FireBallLeftCollision : ICollisionCommand
    {
        public FireBallLeftCollision()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            FireBallProjectile fireball = (FireBallProjectile)gameObject1;
            int greenMushroomPreY = (int)(fireball.Destination.Y - (fireball.Velocity.Y - GameUtilities.SinglePixel));
            if (greenMushroomPreY + fireball.Destination.Height <= gameObject2.Destination.Y)
            {
                return;
            }

            else if (greenMushroomPreY > gameObject2.Destination.Y + gameObject2.Destination.Height)
            {
                return;
            }
            fireball.Terminate();
            SoundManager.Instance.PlayBumpSound();
        }
    }
}
