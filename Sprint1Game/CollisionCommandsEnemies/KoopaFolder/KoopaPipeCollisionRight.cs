using Microsoft.Xna.Framework;
using Sprint1Game.GameObjects;
using Sprint1Game.GameObjects.PipeGameObjects;
using Sprint1Game.Interfaces;
using Sprint1Game.States.EnemyStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.CollisionCommandsEnemies
{
    class KoopaPipeCollisionRight : ICollisionCommand
    {
        public KoopaPipeCollisionRight()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Koopa2 koopa = (Koopa2)gameObject1;
            if (koopa.State.GetType() == typeof(KoopaSideDeathState))
            {
                return;
            }

            if (gameObject2.GetType() == typeof(LPipeBottom) ||
                gameObject2.GetType() == typeof(LPipeBottomLeft))
            {
                return;
            }

            int koopaPreY = (int)(koopa.Location.Y - (koopa.Velocity.Y - GameUtilities.SinglePixel));
            if (koopaPreY + koopa.Destination.Height <= gameObject2.Location.Y)
            {
                return;
            }

            else if (koopaPreY > gameObject2.Location.Y + gameObject2.Destination.Height)
            {
                return;
            }
            if(koopa.Velocity.X < GameUtilities.StationaryVelocity)
            {
                koopa.ChangeDirection();
            }
            
        }
    }
}