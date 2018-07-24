using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint1Game
{
    public class IdleRightFireMarioState : MarioState
    {
        private const bool isBig = true;
        private const bool isCrouching = false;
        public override bool IsStar { get; } = false;
        public IdleRightFireMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateIdleRightFireMarioSprite();
            this.MarioPosture = MarioPostureEnums.Stand;
            this.MarioDirection = MarioDirectionEnums.Right;
            this.MarioShape = MarioShapeEnums.Fire;

        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new IdleRightBigMarioState(Mario);
        }

        public override void ChangeToLeft()
        {
            Mario.State = new IdleLeftFireMarioState(Mario);
        }

        public override void ChangeToRight()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new RunningRightFireMarioState(Mario);
            }
        }

        public override void Crouch()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new CrouchRightFireMarioState(Mario);
            }
        }

        public override void JumpOrStand()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new JumpRightFireMarioState(Mario);
                Mario.Velocity = new Vector2(Mario.Velocity.X, GameUtilities.marioJumpingSpeed);
            }
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void ChangeSizeToSmall()
        {
            Mario.State = new IdleRightSmallMarioState(Mario);
        }

        public override void ChangeStarMode()
        {
            Mario.State = new IdleRightStarBigMarioState(Mario);
        }

        public override void Update()
        {
            base.Update();
            if (Mario.IsInAir) return;
            if (Mario.Velocity.X >= GameUtilities.marioMovingCriticalSpeed)
            {
                Mario.Acceleration = new Vector2(-GameUtilities.marioMovingCriticalSpeed, Mario.Acceleration.Y);
            }
            else if (Mario.Velocity.X <= -GameUtilities.marioMovingCriticalSpeed)
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