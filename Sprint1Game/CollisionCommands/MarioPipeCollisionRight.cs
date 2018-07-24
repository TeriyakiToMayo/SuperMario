using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint1Game.Interfaces;
using Microsoft.Xna.Framework;

namespace Sprint1Game.CollisionCommands
{
    class MarioPipeCollisionRight : ICollisionCommand
    { 
        public MarioPipeCollisionRight()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IMario mario = (IMario)gameObject1;
            if (mario.State.MarioShape == MarioState.MarioShapeEnums.Dead)
            {
                return;
            }
            mario.Location = new Vector2(gameObject2.Destination.X + gameObject2.Destination.Width + GameUtilities.SinglePixel, mario.Destination.Y);
            mario.Velocity = new Vector2(GameUtilities.StationaryVelocity, mario.Velocity.Y);
        }
    }
}
