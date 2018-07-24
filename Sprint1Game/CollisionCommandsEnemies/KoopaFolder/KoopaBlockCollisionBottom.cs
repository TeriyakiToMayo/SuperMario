using Microsoft.Xna.Framework;
using Sprint1Game.GameObjects;
using Sprint1Game.Interfaces;
using Sprint1Game.States.EnemyStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.CollisionCommandsEnemies
{
    class KoopaBlockCollisionBottom: ICollisionCommand
    {
        public KoopaBlockCollisionBottom()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Koopa2 k = (Koopa2)gameObject1;
            if (k.State.GetType() == typeof(KoopaSideDeathState))
            {
                return;
            }
            k.Location = new Vector2(k.Location.X, gameObject2.Location.Y - gameObject2.Destination.Height);
            if (k.Velocity.Y < GameUtilities.StationaryVelocity)
            {
                k.Velocity = new Vector2(k.Velocity.X, GameUtilities.StationaryVelocity);
            }
        }
    }
}
