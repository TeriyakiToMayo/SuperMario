using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game
{
    public class RunningLeftStarSmallMarioState : MarioState
    {
        private const bool isBig = true;
        private const bool isCrouching = false;
        public override bool IsStar { get; } = true;

        public RunningLeftStarSmallMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateRunningLeftStarSmallMarioSprite();
            this.MarioPosture = MarioPostureEnums.Running;
            this.MarioDirection = MarioDirectionEnums.Left;
            this.MarioShape = MarioShapeEnums.StarSmall;
            Mario.Acceleration = new Vector2(-0.25f, Mario.Acceleration.Y);

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
            Mario.State = new IdleLeftStarSmallMarioState(Mario);
        }

        public override void JumpOrStand()
        {
            Mario.State = new JumpLeftStarSmallMarioState(Mario);
            Mario.Velocity = new Vector2(Mario.Velocity.X, GameUtilities.marioJumpingSpeed);
            Mario.Acceleration = new Vector2(0, Mario.Acceleration.Y);
        }

        public override void Crouch()
        {
            Mario.State = new IdleLeftStarSmallMarioState(Mario);
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
            Mario.State = new RunningLeftStarBigMarioState(Mario);
        }

        public override void Update()
        {
            if (Mario.IsInAir && Mario.State.MarioPosture != MarioPostureEnums.Jump)
            {
                Mario.State = new IdleLeftStarSmallMarioState(Mario);
            }
            if (!Mario.IsInAir && Mario.Velocity.X > 0)
            {
                Mario.Velocity = new Vector2(0, Mario.Velocity.Y);
            }
            else if (!Mario.IsInAir && Mario.Velocity.X <= 0)
            {
                Mario.Acceleration = new Vector2(-0.25f, Mario.Acceleration.Y);
            }
            base.Update();

        }
    }
}
