using Sprint1Game.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint1Game
{
    public class IdleRightSmallMarioState : MarioState
    {
        private const bool isBig = false;
        private const bool isCrouching = false;
        public override bool IsStar { get; } = false;
        public IdleRightSmallMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateIdleRightSmallMarioSprite();
            this.MarioPosture = MarioPostureEnums.Stand;
            this.MarioDirection = MarioDirectionEnums.Right;
            this.MarioShape = MarioShapeEnums.Small;

        }

        public override void ChangeToLeft()
        {
            Mario.State = new IdleLeftSmallMarioState(Mario);
        }

        public override void ChangeToRight()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new RunningRightSmallMarioState(Mario);
            }
            
        }

        public override void Crouch()
        {
        }

        public override void ChangeFireMode()
        {
            Mario.State = new IdleRightFireMarioState(Mario);
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new IdleRightBigMarioState(Mario);
        }

        public override void JumpOrStand()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new JumpRightSmallMarioState(Mario);
                Mario.Velocity = new Vector2(Mario.Velocity.X, GameUtilities.marioJumpingSpeed);
            }
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void ChangeStarMode()
        {
            Mario.State = new IdleRightStarSmallMarioState(Mario);
        }

        public override void Update()
        {
            base.Update();
            if (Mario.IsInAir) return;
            if (Mario.Velocity.X >= GameUtilities.marioMovingCriticalSpeed)
            {
                Mario.Acceleration = new Vector2(-GameUtilities.marioMovingCriticalSpeed, Mario.Acceleration.Y);
            }
            else if(Mario.Velocity.X <= -GameUtilities.marioMovingCriticalSpeed)
            {
                Mario.Acceleration = new Vector2(GameUtilities.marioMovingCriticalSpeed, Mario.Acceleration.Y);
            }
            else
            {
                Mario.Acceleration = new Vector2(GameUtilities.StationaryAcceleration, Mario.Acceleration.Y);
                Mario.Velocity = new Vector2(GameUtilities.StationaryVelocity, Mario.Velocity.Y);
            }
        }
    }
}
