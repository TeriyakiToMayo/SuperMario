using Sprint1Game.Sprites;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint1Game.Sound;

namespace Sprint1Game
{
    internal class JumpLeftSmallMarioState : MarioState
    {
        private const bool isBig = false;
        private const bool isCrouching = false;
        public override bool IsStar { get; } = false;

        public JumpLeftSmallMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateJumpLeftSmallMarioSprite();
            this.MarioPosture = MarioPostureEnums.Jump;
            this.MarioDirection = MarioDirectionEnums.Left;
            this.MarioShape = MarioShapeEnums.Small;
            mario.Acceleration = new Vector2(GameUtilities.StationaryAcceleration, mario.Acceleration.Y);
            if (mario.IsInAir == false && !mario.IsProtected)
            {
                SoundManager.Instance.PlaySmallJumpSound();
            }
            mario.IsInAir = true;
        }

        public override void ChangeToLeft()
        {
            Mario.Location = new Vector2(Mario.Destination.X - GameUtilities.SinglePixel, Mario.Destination.Y);
        }

        public override void ChangeToRight()
        {
            Mario.State = new JumpRightSmallMarioState(Mario);
        }

        public override void JumpOrStand()
        {
        }

        public override void Crouch()
        {
        }

        public override void ChangeFireMode()
        {
            Mario.State = new JumpLeftFireMarioState(Mario);}

        public override void ChangeSizeToBig()
        {
            Mario.State = new JumpLeftBigMarioState(Mario);}

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void ChangeStarMode()
        {
            Mario.State = new JumpLeftStarSmallMarioState(Mario); }

        public override void Update()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new IdleLeftSmallMarioState(Mario);
            }
            base.Update();
        }
    }
}