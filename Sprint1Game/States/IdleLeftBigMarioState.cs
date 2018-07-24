
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint1Game.Interfaces;

namespace Sprint1Game
{
    public class IdleLeftBigMarioState : MarioState
    {
        private const bool isBig = true;
        private const bool isCrouching = false;
        public override bool IsStar { get; } = false;
        public IdleLeftBigMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftBigMarioSprite();
            this.MarioPosture = MarioPostureEnums.Stand;
            this.MarioDirection = MarioDirectionEnums.Left;
            this.MarioShape = MarioShapeEnums.Big;
        }

        public override void ChangeFireMode()
        {
            Mario.State = new IdleLeftFireMarioState(Mario);
        }

        public override void ChangeToLeft()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new RunningLeftBigMarioState(Mario);
            }
            
        }

        public override void ChangeToRight()
        {
            Mario.State = new IdleRightBigMarioState(Mario);
        }

        public override void Crouch()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new CrouchLeftBigMarioState(Mario);
            }
        }

        public override void JumpOrStand()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new JumpLeftBigMarioState(Mario);
                Mario.Velocity = new Vector2(Mario.Velocity.X, GameUtilities.marioJumpingSpeed);
            }
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void ChangeSizeToSmall()
        {
            Mario.State = new IdleLeftSmallMarioState(Mario);
        }

        public override void ChangeStarMode()
        {
            Mario.State = new IdleLeftStarBigMarioState(Mario);
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