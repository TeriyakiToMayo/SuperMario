using System;
using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework;
using Sprint1Game.Interfaces;

namespace Sprint1Game
{
    public class CrouchRightFireMarioState : MarioState
    {
        private const bool isBig = true;
        private const bool isCrouching = true;
        public override bool IsStar { get; } = false;

        public CrouchRightFireMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateCrouchRightFireMarioSprite();
            this.MarioPosture = MarioPostureEnums.Crouch;
            this.MarioDirection = MarioDirectionEnums.Right;
            this.MarioShape = MarioShapeEnums.Fire;
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new CrouchRightBigMarioState(Mario);
        }

        public override void ChangeStarMode()
        {
            Mario.State = new CrouchRightStarMarioState(Mario);
        }

        public override void ChangeToLeft()
        {
            Mario.State = new CrouchLeftFireMarioState(Mario);
        }

        public override void ChangeToRight()
        {
        }

        public override void JumpOrStand()
        {
            Mario.State = new IdleRightFireMarioState(Mario);
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
                Mario.State = new IdleRightFireMarioState(Mario);
            }
            else
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