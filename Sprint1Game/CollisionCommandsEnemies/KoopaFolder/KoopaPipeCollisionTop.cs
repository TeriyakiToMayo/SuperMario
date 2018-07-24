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
    class KoopaPipeCollisionTop : ICollisionCommand
    {
        public KoopaPipeCollisionTop()
        {

        }

        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            if (gameObject2.GetType() == typeof(HiddenBlock))
            {
                HiddenBlock hiddenBlock = (HiddenBlock)gameObject2;
                if (!hiddenBlock.Used) return;
            }

            if (gameObject2.GetType() == typeof(LPipeBottom) ||
                gameObject2.GetType() == typeof(LPipeBottomLeft))
            {
                return;
            }

            Koopa2 koopa = (Koopa2)gameObject1;
            if (koopa.State.GetType() == typeof(KoopaSideDeathState))
            {
                return;
            }
            koopa.Location = new Vector2(koopa.Location.X, gameObject2.Location.Y - koopa.Destination.Height);
            koopa.Velocity = new Vector2(koopa.Velocity.X, GameUtilities.StationaryVelocity);
        }
    }
}
