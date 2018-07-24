using Microsoft.Xna.Framework;
using Sprint1Game.Commands;
using Sprint1Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.CollisionCommands
{
    public class MarioMarioCollisionLeftCommand : ICollisionCommand
    {
        public MarioMarioCollisionLeftCommand()
        {

        }

        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IMario mario = (IMario)gameObject1;
            IMario mario2 = (IMario)gameObject2;
            if (mario.State.MarioShape == MarioState.MarioShapeEnums.Dead ||
                mario2.State.MarioShape == MarioState.MarioShapeEnums.Dead ||
                mario.IsProtected || mario2.IsProtected)
            {
                return;
            }

            int marioPreY = (int)(mario.Destination.Y - (mario.Velocity.Y - GameUtilities.SinglePixel));
            if (marioPreY + mario.Destination.Height < gameObject2.Destination.Y)
            {
                ICollisionCommand TopCommand = new MarioMarioCollisionTopCommand();

                TopCommand.Execute(gameObject1, gameObject2);
                return;
            }

            else if (marioPreY > gameObject2.Destination.Y + gameObject2.Destination.Height)
            {
                return;
            }

            if (mario.Velocity.X > 0)
            {
                mario.Location = new Vector2(mario2.Destination.X - mario.Destination.Width - 1, mario.Destination.Y);
                mario.Velocity = new Vector2(GameUtilities.StationaryVelocity, mario.Velocity.Y);
            }

            if (mario2.Velocity.X < 0)
            {
                mario2.Location = new Vector2(mario.Destination.X + mario.Destination.Width + 1, mario2.Destination.Y);
                mario2.Velocity = new Vector2(GameUtilities.StationaryVelocity, mario2.Velocity.Y);
            }
        }
    }
}
