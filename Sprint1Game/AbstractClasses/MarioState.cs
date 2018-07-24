using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.Interfaces;
using Sprint1Game.Camera;
using Sprint1Game.HeadsUp;

namespace Sprint1Game
{
    public abstract class MarioState : IMarioState
    {
        public enum MarioPostureEnums { Stand, Crouch, Jump, Running, Dead }
        public enum MarioDirectionEnums { Left, Right, Dead }
        public enum MarioShapeEnums { Small, Big, Fire, StarBig, StarSmall, Dead }
        public virtual bool IsStar { get; }

        private const int stationarySpeed = 0;
        public ISprite StateSprite { get; set; }

        public MarioPostureEnums MarioPosture { get; set; } = MarioPostureEnums.Stand;
        public MarioDirectionEnums MarioDirection { get; set; } = MarioDirectionEnums.Right;
        public MarioShapeEnums MarioShape {get; set;} = MarioShapeEnums.Small;

        public IMario Mario { get; set; }

        protected MarioState(IMario mario)
        {
            Mario = mario;
        }

        public virtual void ChangeFireMode(){}

        public virtual void ChangeSizeToBig(){}

        public virtual void ChangeSizeToSmall(){}

        public virtual void ChangeStarMode(){}

        public virtual void ChangeToLeft(){}

        public virtual void ChangeToRight(){}

        public virtual void Crouch(){}

        public virtual void JumpOrStand(){}

        public virtual void Terminated(){}

        public virtual void Update()
        {
            if (this.Mario.Destination.Y > GameUtilities.heightOutOfBlocks * GameUtilities.BlockSize - Mario.Destination.Height)
            {
                this.Mario.Location = new Vector2(this.Mario.Location.X, GameUtilities.heightOutOfBlocks * GameUtilities.BlockSize - Mario.Destination.Height);
                this.Mario.State.Terminated();
            }

            if (this.Mario.Destination.X <= Camera2D.CameraX)
            {
                this.Mario.Location = new Vector2(Camera2D.CameraX, (int)this.Mario.Destination.Y);
            }

            if (this.Mario.IsInAir)
            {
                this.Mario.Acceleration = new Vector2(stationarySpeed, this.Mario.Acceleration.Y);
            }

            this.StateSprite.Update();
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            this.StateSprite.Draw(spriteBatch, location);
        }

        public void MarioShapeChange(MarioShapeEnums newShape)
        {
            switch (newShape)
            {
                case MarioShapeEnums.Big:
                    ChangeSizeToBig();
                    break;
                case MarioShapeEnums.Small:
                    ChangeSizeToSmall();
                    break;
                case MarioShapeEnums.Fire:
                    ChangeFireMode();
                    break;
                case MarioShapeEnums.StarBig:
                    ChangeStarMode();
                    break;
                case MarioShapeEnums.StarSmall:
                    ChangeStarMode();
                    break;
            }
        }
    }
}
