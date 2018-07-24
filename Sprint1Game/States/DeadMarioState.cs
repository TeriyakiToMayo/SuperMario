using Sprint1Game.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint1Game.Interfaces;
using Sprint1Game.Sound;

namespace Sprint1Game
{
    public class DeadMarioState : MarioState
    {
        private const bool isBig = false;
        private const bool isCrouching = false;
        public override bool IsStar { get; } = false;
        private int counter = 20;
        private IMario mario;
        private float marioDeathBounceAccel = .75f;
        private int marioDeathBounceVelocity = 10;

        public DeadMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateDeadMarioSprite();
            this.MarioPosture = MarioPostureEnums.Dead;
            this.MarioDirection = MarioDirectionEnums.Dead;
            this.MarioShape = MarioShapeEnums.Dead;
            SoundManager.Instance.PlayMarioDyingSound();
            SoundManager.Instance.StopAllSound();
            this.mario = mario;
            this.Mario.Velocity = new Vector2(GameUtilities.StationaryVelocity, GameUtilities.StationaryVelocity);
            this.Mario.Acceleration = new Vector2(GameUtilities.StationaryAcceleration, GameUtilities.StationaryAcceleration);
            MarioAttributes.MarioLife[mario.Player]--;
        }

        public override void ChangeToLeft()
        {
        }

        public override void ChangeToRight()
        {
        }

        public override void JumpOrStand()
        {
        }

        public override void Crouch()
        {
        }

        public override void ChangeFireMode()
        {
            Mario.State = new IdleRightFireMarioState(Mario);
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new IdleRightBigMarioState(Mario);
        }

        public override void ChangeSizeToSmall()
        {
            Mario.State = new IdleRightSmallMarioState(Mario);
        }

        public override void ChangeStarMode()
        {
            Mario.State = new IdleRightStarSmallMarioState(Mario);
        }

        public override void Update()
        {
            if(counter > 0)
            {
                counter--;
            }
            else if(counter == 0)
            {
                this.Mario.Velocity = new Vector2(GameUtilities.StationaryVelocity, -marioDeathBounceVelocity);
                this.Mario.Acceleration = new Vector2(GameUtilities.StationaryAcceleration, marioDeathBounceAccel);
                counter--;
            }

            if (this.Mario.Destination.Y > GameUtilities.Game.GraphicsManager.PreferredBackBufferHeight + 500 * GameUtilities.SinglePixel)
            {
                MarioAttributes.StopTimer();

                if(GameUtilities.Game.State.Type == GameStates.Competitive)
                {
                    GameUtilities.Game.State.GameOver();
                    return;
                }

                if (MarioAttributes.MarioLife[mario.Player] == 0)
                {
                    GameUtilities.Game.State.GameOver();
                }else
                {
                    GameUtilities.Game.State.MarioDied();
                }
                
            }
        }
    }
}
