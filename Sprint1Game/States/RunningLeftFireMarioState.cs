using System;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.Sprites;
using Microsoft.Xna.Framework;

namespace Sprint1Game
{
    public class RunningLeftFireMarioState : MarioState
    {
        private const bool isBig = true;
        private const bool isCrouching = false;
        public override bool IsStar { get; } = false;

        public RunningLeftFireMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateRunningLeftFireMarioSprite();
            this.MarioPosture = MarioPostureEnums.Running;
            this.MarioDirection = MarioDirectionEnums.Left;
            this.MarioShape = MarioShapeEnums.Fire;
            Mario.Acceleration = new Vector2(-GameUtilities.MarioRegularAccel, Mario.Acceleration.Y);
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new RunningLeftBigMarioState(Mario);
        }

        public override void ChangeToLeft()
        {
        }

        public override void ChangeToRight()
        {
            Mario.State = new IdleLeftFireMarioState(Mario);
        }

        public override void JumpOrStand()
        {
            Mario.State = new JumpLeftFireMarioState(Mario);
            Mario.Velocity = new Vector2(Mario.Velocity.X, GameUtilities.marioJumpingSpeed);
            Mario.Acceleration = new Vector2(GameUtilities.StationaryAcceleration, Mario.Acceleration.Y);
        }

        public override void Crouch()
        {
            Mario.State = new CrouchLeftFireMarioState(Mario);
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void ChangeSizeToSmall()
        {
            Mario.State = new RunningLeftSmallMarioState(Mario);
        }

        public override void ChangeStarMode()
        {
            Mario.State = new RunningLeftStarBigMarioState(Mario);
        }

        public override void Update()
        {
            if (Mario.IsInAir && Mario.State.MarioPosture != MarioPostureEnums.Jump)
            {
                Mario.State = new IdleLeftFireMarioState(Mario);
            }
            base.Update();

        }
    }
}