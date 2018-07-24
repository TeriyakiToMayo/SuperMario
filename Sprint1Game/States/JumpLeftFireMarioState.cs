using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint1Game.Sound;

namespace Sprint1Game
{
    public class JumpLeftFireMarioState : MarioState
    {
        private const bool isBig = true;
        private const bool isCrouching = false;
        public override bool IsStar { get; } = false;
        public JumpLeftFireMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateJumpLeftFireMarioSprite();
            this.MarioPosture = MarioPostureEnums.Jump;
            this.MarioDirection = MarioDirectionEnums.Left;
            this.MarioShape = MarioShapeEnums.Fire;
            mario.Acceleration = new Vector2(GameUtilities.StationaryAcceleration, mario.Acceleration.Y);
            if (mario.IsInAir == false && !mario.IsProtected)
            {
                SoundManager.Instance.PlaySuperJumpSound();
            }
            mario.IsInAir = true;
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new JumpLeftBigMarioState(Mario);
        }

        public override void ChangeToLeft()
        {
            Mario.Location = new Vector2(Mario.Destination.X - GameUtilities.SinglePixel, Mario.Destination.Y);
        }

        public override void ChangeToRight()
        {
            Mario.State = new JumpRightFireMarioState(Mario);
        }

        public override void JumpOrStand()
        {
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
            Mario.State = new JumpLeftSmallMarioState(Mario);
        }

        public override void ChangeStarMode()
        {
            Mario.State = new JumpLeftStarBigMarioState(Mario);
        }

        public override void Update()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new IdleLeftFireMarioState(Mario);
            }
            base.Update();
        }
    }
}