using Microsoft.Xna.Framework;
using Sprint1Game.GameObjects;
using Sprint1Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.CollisionCommandsEnemies
{
    class GoombaBlockCollisionBottom: ICollisionCommand
    {
        public GoombaBlockCollisionBottom()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            Goomba2 g = (Goomba2)gameObject1;
            
            if(!g.Alive)
            {
                return;
            }
            g.Location = new Vector2(g.Location.X, gameObject2.Location.Y + gameObject2.Destination.Height);
            if (g.Velocity.Y > GameUtilities.StationaryVelocity)
            {
                g.Velocity = new Vector2(g.Velocity.X, GameUtilities.StationaryVelocity);                   
            }
        }
    }
}

