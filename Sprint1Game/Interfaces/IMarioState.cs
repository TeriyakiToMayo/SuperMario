using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Sprint1Game.MarioState;

namespace Sprint1Game.Interfaces
{
    public interface IMarioState
    {
        MarioPostureEnums MarioPosture { get; set; }
        MarioDirectionEnums MarioDirection { get; set; }
        MarioShapeEnums MarioShape { get; set; }
        ISprite StateSprite { get; set; }
        bool IsStar { get; } 
        void ChangeToRight();
        void JumpOrStand();
        void ChangeSizeToBig();
        void ChangeSizeToSmall();
        void Terminated();
        void ChangeToLeft();
        void Crouch();
        void ChangeFireMode();
        void ChangeStarMode();
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        void MarioShapeChange(MarioShapeEnums newShape);
    }
}