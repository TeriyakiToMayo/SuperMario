using Microsoft.Xna.Framework;
using Sprint1Game.GameObjects;
using Sprint1Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.CollisionCommandsItems
{
    class GMushroomBlockBottom : ICollisionCommand
    {
        public GMushroomBlockBottom()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            GreenMushroom g = (GreenMushroom)gameObject1;
            if (gameObject2.GetType() == typeof(HiddenBlock) && g.Velocity.Y >= GameUtilities.StationaryVelocity)
            {
                return;
            }
        }
    }
}