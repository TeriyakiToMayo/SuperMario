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
    public class RunningLeftSmallMarioState : MarioState
    {
        private const bool isBig = false;
        private const bool isCrouching = false;
        public override bool IsStar { get; } = false;

        public RunningLeftSmallMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateRunningLeftSmallMarioSprite();
            this.MarioPosture = MarioPostureEnums.Running;
            this.MarioDirection = MarioDirectionEnums.Left;
            this.MarioShape = MarioShapeEnums.Small;
            Mario.Acceleration = new Vector2(-GameUtilities.MarioRegularAccel, Mario.Acceleration.Y);
        }

        public override void ChangeToRight()
        {
            Mario.State = new IdleLeftSmallMarioState(Mario);
        }

        public override void ChangeToLeft()
        {
        }

        public override void JumpOrStand()
        {
            Mario.State = new JumpLeftSmallMarioState(Mario);
            Mario.Velocity = new Vector2(Mario.Velocity.X, GameUtilities.marioJumpingSpeed);
            Mario.Acceleration = new Vector2(GameUtilities.StationaryAcceleration, Mario.Acceleration.Y);
        }

        public override void Crouch()
        {
            Mario.State = new IdleLeftSmallMarioState(Mario);
        }

        public override void ChangeFireMode()
        {
            Mario.State = new RunningLeftFireMarioState(Mario);
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new RunningLeftBigMarioState(Mario);
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void ChangeStarMode()
        {
            Mario.State = new RunningLeftStarSmallMarioState(Mario);
        }

        public override void Update()
        {
            if (Mario.IsInAir && Mario.State.MarioPosture != MarioPostureEnums.Jump)
            {
                Mario.State = new IdleLeftSmallMarioState(Mario);
            }
            if (!Mario.IsInAir && Mario.Velocity.X > GameUtilities.StationaryVelocity)
            {
                Mario.Velocity = new Vector2(GameUtilities.StationaryVelocity, Mario.Velocity.Y);
            }
            else if (!Mario.IsInAir && Mario.Velocity.X <= GameUtilities.StationaryVelocity)
            {
                Mario.Acceleration = new Vector2(-GameUtilities.MarioRegularAccel, Mario.Acceleration.Y);
            }
            base.Update();

        }
    }
}
