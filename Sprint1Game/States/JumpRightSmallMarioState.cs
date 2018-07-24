using Sprint1Game.Sprites;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint1Game.Sound;

namespace Sprint1Game
{
    public class JumpRightSmallMarioState : MarioState
    {
        private const bool isBig = false;
        private const bool isCrouching = false;
        public override bool IsStar { get; } = false;

        public JumpRightSmallMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateJumpRightSmallMarioSprite();
            this.MarioPosture = MarioPostureEnums.Jump;
            this.MarioDirection = MarioDirectionEnums.Right;
            this.MarioShape = MarioShapeEnums.Small; mario.Acceleration = new Vector2(GameUtilities.StationaryAcceleration, mario.Acceleration.Y);
            if (mario.IsInAir == false && !mario.IsProtected)
            {
                SoundManager.Instance.PlaySmallJumpSound();
            }
            mario.IsInAir = true;
        }

        public override void ChangeToLeft()
        {
            Mario.State = new JumpLeftSmallMarioState(Mario);
        }

        public override void ChangeToRight()
        {
            Mario.Location = new Vector2(Mario.Destination.X + GameUtilities.SinglePixel, Mario.Destination.Y);
        }

        public override void JumpOrStand()
        {
        }

        public override void Crouch()
        {
        }

        public override void ChangeFireMode()
        {
            Mario.State = new JumpRightFireMarioState(Mario);}

        public override void ChangeSizeToBig()
        {
            Mario.State = new JumpRightBigMarioState(Mario); }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void ChangeStarMode()
        {
            Mario.State = new JumpRightStarSmallMarioState(Mario);}

        public override void Update()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new IdleRightSmallMarioState(Mario);
            }
            base.Update();
        }
    }
}
