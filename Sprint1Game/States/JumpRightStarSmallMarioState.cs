using Microsoft.Xna.Framework;
using Sprint1Game.Sound;
using Sprint1Game.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game
{
    public class JumpRightStarSmallMarioState : MarioState
    {
        private const bool isBig = true;
        private const bool isCrouching = false;
        public override bool IsStar { get; } = true;

        public JumpRightStarSmallMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateJumpRightStarSmallMarioSprite();
            this.MarioPosture = MarioPostureEnums.Jump;
            this.MarioDirection = MarioDirectionEnums.Right;
            this.MarioShape = MarioShapeEnums.StarSmall;mario.Acceleration = new Vector2(GameUtilities.StationaryAcceleration, mario.Acceleration.Y);
            if (mario.IsInAir == false && !mario.IsProtected)
            {
                SoundManager.Instance.PlaySmallJumpSound();
            }
            mario.IsInAir = true;
        }

        public override void ChangeToLeft()
        {
            Mario.State = new JumpLeftStarSmallMarioState(Mario);
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

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void ChangeFireMode()
        {
            Mario.State = new JumpRightFireMarioState(Mario);}

        public override void ChangeSizeToBig()
        {
            Mario.State = new JumpRightBigMarioState(Mario);
        }

        public override void ChangeSizeToSmall()
        {
            Mario.State = new JumpRightSmallMarioState(Mario);
        }

        public override void ChangeStarMode()
        {
            Mario.State = new JumpRightStarBigMarioState(Mario);}

        public override void Update()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new IdleRightStarSmallMarioState(Mario);
            }
            base.Update();
        }
    }
}
