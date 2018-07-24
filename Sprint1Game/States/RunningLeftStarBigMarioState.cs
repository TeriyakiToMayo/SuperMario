using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game
{
    public class RunningLeftStarBigMarioState : MarioState
    {
        private const bool isBig = true;
        private const bool isCrouching = false;
        public override bool IsStar { get; } = true;

        public RunningLeftStarBigMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateRunningLeftStarBigMarioSprite();
            this.MarioPosture = MarioPostureEnums.Running;
            this.MarioDirection = MarioDirectionEnums.Left;
            this.MarioShape = MarioShapeEnums.StarBig;
            Mario.Acceleration = new Vector2(-GameUtilities.MarioRegularAccel, Mario.Acceleration.Y);
        }

        public override void ChangeFireMode()
        {
            Mario.State = new RunningLeftFireMarioState(Mario);
        }

        public override void ChangeToLeft()
        {
        }

        public override void ChangeToRight()
        {
            Mario.State = new IdleLeftStarBigMarioState(Mario);
        }

        public override void JumpOrStand()
        {
            Mario.State = new JumpLeftStarBigMarioState(Mario);
            Mario.Velocity = new Vector2(Mario.Velocity.X, GameUtilities.marioJumpingSpeed);
            Mario.Acceleration = new Vector2(GameUtilities.StationaryAcceleration, Mario.Acceleration.Y);
        }

        public override void Crouch()
        {
            Mario.State = new CrouchLeftStarMarioState(Mario);
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new RunningLeftBigMarioState(Mario);
        }

        public override void ChangeSizeToSmall()
        {
            Mario.State = new RunningLeftSmallMarioState(Mario);
        }

        public override void ChangeStarMode()
        {
            Mario.State = new RunningLeftStarSmallMarioState(Mario);
        }

        public override void Update()
        {
            if (Mario.IsInAir && Mario.State.MarioPosture != MarioPostureEnums.Jump)
            {
                Mario.State = new IdleLeftStarBigMarioState(Mario);
            }
            base.Update();

        }
    }
}
