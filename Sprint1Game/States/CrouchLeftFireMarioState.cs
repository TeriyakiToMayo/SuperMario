using System;
using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework;
using Sprint1Game.Interfaces;

namespace Sprint1Game
{
    public class CrouchLeftFireMarioState : MarioState
    {
        private const bool isBig = true;
        private const bool isCrouching = true;
        public override bool IsStar { get; } = false;
        public CrouchLeftFireMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateCrouchLeftFireMarioSprite();
            this.MarioPosture = MarioPostureEnums.Crouch;
            this.MarioDirection = MarioDirectionEnums.Left;
            this.MarioShape = MarioShapeEnums.Fire;
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new CrouchLeftBigMarioState(Mario);
        }

        public override void ChangeStarMode()
        {
            Mario.State = new CrouchLeftStarMarioState(Mario);
        }

        public override void ChangeToLeft()
        {
        }

        public override void ChangeToRight()
        {
            Mario.State = new CrouchRightFireMarioState(Mario);
        }

        public override void JumpOrStand()
        {
            Mario.State = new IdleLeftFireMarioState(Mario);
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
            Mario.State = new IdleLeftSmallMarioState(Mario);
        }

        public override void Update()
        {
            if (Mario.IsInAir)
            {
                Mario.State = new IdleLeftFireMarioState(Mario);
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