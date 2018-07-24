using Microsoft.Xna.Framework;
using Sprint1Game.GameObjects;
using Sprint1Game.GameObjects.PipeGameObjects;
using Sprint1Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.CollisionCommandsEnemies
{
    class GoombaPipeCollisionBottom : ICollisionCommand
    {
        public GoombaPipeCollisionBottom()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Goomba2 g = (Goomba2)gameObject1;
            if (!g.Alive)
            {
                return;
            }
            if(gameObject2.GetType() == typeof(LPipeBottom) ||
                gameObject2.GetType() == typeof(LPipeBottomLeft))
            {
                return;
            }
            g.Location = new Vector2(g.Location.X, gameObject2.Location.Y - g.Destination.Height);
            if (g.Velocity.Y < GameUtilities.StationaryVelocity)
            {
                g.Velocity = new Vector2(g.Velocity.X, GameUtilities.StationaryVelocity);
            }
        }
    }
}
