
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint1Game.Interfaces;

namespace Sprint1Game
{
    internal class CrouchRightBigMarioState : MarioState
    {
        private const bool isBig = true;
        private const bool isCrouching = true;
        public override bool IsStar { get; } = false;

        public CrouchRightBigMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateCrouchRightBigMarioSprite();
            this.MarioPosture = MarioPostureEnums.Crouch;
            this.MarioDirection = MarioDirectionEnums.Right;
            this.MarioShape = MarioShapeEnums.Big;
        }

        public override void ChangeFireMode()
        {
            Mario.State = new CrouchRightFireMarioState(Mario);
        }

        public override void ChangeStarMode()
        {
            Mario.State = new CrouchRightStarMarioState(Mario);
        }

        public override void ChangeToLeft()
        {
            Mario.State = new CrouchLeftBigMarioState(Mario);
        }

        public override void ChangeToRight()
        {
        }

        public override void JumpOrStand()
        {
            Mario.State = new IdleRightBigMarioState(Mario);
        }

        public override void Crouch()
        {
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void ChangeSizeToSmall()
        {
            Mario.State = new IdleRightSmallMarioState(Mario);
        }

        public override void Update()
        {
            if (Mario.IsInAir)
            {
                Mario.State = new IdleRightBigMarioState(Mario);
            }else
            {
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
            base.Update();

        }
    }
}