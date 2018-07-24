using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint1Game.Interfaces;
using Microsoft.Xna.Framework;

namespace Sprint1Game.CollisionCommands
{
    class MarioPipeCollisionBottom : ICollisionCommand
    {
        public MarioPipeCollisionBottom()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IMario mario = (IMario)gameObject1;
            if (mario.State.MarioShape == MarioState.MarioShapeEnums.Dead)
            {
                return;
            }if (mario.Velocity.Y < GameUtilities.StationaryVelocity)
            {}
        }
    }
}
