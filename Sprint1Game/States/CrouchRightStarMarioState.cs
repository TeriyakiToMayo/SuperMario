using Microsoft.Xna.Framework;
using Sprint1Game.Interfaces;
using Sprint1Game.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game
{
    class CrouchRightStarMarioState : MarioState
    {
        private const bool isBig = true;
        private const bool isCrouching = true;

        public override bool IsStar { get; } = true;
        public CrouchRightStarMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateCrouchRightStarMarioSprite();
            this.MarioPosture = MarioPostureEnums.Crouch;
            this.MarioDirection = MarioDirectionEnums.Right;
            this.MarioShape = MarioShapeEnums.StarBig;
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new CrouchRightBigMarioState(Mario);
        }

        public override void ChangeFireMode()
        {
            Mario.State = new CrouchRightFireMarioState(Mario);
        }

        public override void ChangeToLeft()
        {
            Mario.State = new CrouchLeftStarMarioState(Mario);
        }

        public override void ChangeToRight()
        {
        }

        public override void JumpOrStand()
        {
            Mario.State = new IdleRightStarBigMarioState(Mario);
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
                Mario.State = new IdleRightStarBigMarioState(Mario);
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
