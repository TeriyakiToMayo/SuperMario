using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint1Game.Interfaces;
using Microsoft.Xna.Framework;
using Sprint1Game.Sound;
using Sprint1Game.GameObjects.PipeGameObjects;

namespace Sprint1Game.CollisionCommands
{
    class MarioPipeCollisionTop : ICollisionCommand
    {
        public MarioPipeCollisionTop()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {

            IMario mario = (IMario)gameObject1;
            if (mario.State.MarioShape == MarioState.MarioShapeEnums.Dead)
            {
                return;
            }

            if(mario.Velocity.Y >= 0)
            {
                mario.IsInAir = false;
            }
            
            mario.Location = new Vector2(mario.Destination.X, gameObject2.Destination.Y - mario.Destination.Height);


            IPipe pipe = (IPipe)gameObject2;
            if (mario.State.MarioPosture == MarioState.MarioPostureEnums.Crouch &&
                gameObject2.GetType() == typeof(BigPipe))
            {
                
                pipe.Warp(mario);
            }
            
            if(mario.Velocity.Y > 0)
            {
                mario.Velocity = new Vector2(mario.Velocity.X, GameUtilities.StationaryVelocity);
            }
            
        }
    }
}
