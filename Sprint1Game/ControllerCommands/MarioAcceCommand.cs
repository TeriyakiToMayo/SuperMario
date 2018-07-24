using Microsoft.Xna.Framework;
using Sprint1Game.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.Commands
{
    class MarioAcceCommand : ICommand
    {
        private int maxFireballNum = 3;
        private float fireBallVelocityX = 4.5f;

        private IMario mario;
        private int player;

        public MarioAcceCommand(IMario mario, int player)
        {
            this.mario = mario;
            this.player = player;
        }

        public void Execute()
        {
            if(!mario.IsInAir && mario.State.MarioPosture == MarioState.MarioPostureEnums.Running)
            {
                mario.MarioTopSpeed = GameUtilities.MarioSprintSpeed;
            }
            
            long length = GameUtilities.GameObjectManager.FireBallListLongCount;
            if (player == 1)
            {
                length = GameUtilities.GameObjectManager.FireBallList2LongCount;
            }

            if ((mario.State.MarioShape == MarioState.MarioShapeEnums.Fire ||
                (mario.State.MarioShape == MarioState.MarioShapeEnums.StarBig &&
                mario.PreStarShape == MarioState.MarioShapeEnums.Fire)) && length < maxFireballNum)
            {
                FireBallProjectile fireBall = new FireBallProjectile(new Vector2(GameUtilities.Origin, GameUtilities.Origin), mario.Player);
                fireBall.Location = new Vector2(mario.Destination.X + mario.Destination.Width - GameUtilities.BlockSize, mario.Destination.Y);
                fireBall.Velocity = new Vector2(fireBallVelocityX, GameUtilities.StationaryVelocity);
                if (mario.State.MarioDirection == MarioState.MarioDirectionEnums.Left)
                {
                    fireBall.Location = new Vector2(mario.Destination.X + 5, mario.Destination.Y);
                    fireBall.Velocity = new Vector2(-fireBall.Velocity.X, GameUtilities.StationaryVelocity);
                }

                if(player == 0)
                {
                    GameUtilities.GameObjectManager.AddFireBall(fireBall);
                }else
                {
                    GameUtilities.GameObjectManager.AddFireBall2(fireBall);
                }
                
            }
            
        }
    }
}
