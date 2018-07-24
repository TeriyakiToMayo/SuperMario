using Sprint1Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.Sprites;
using Sprint1Game.SpriteFactories;
using Sprint1Game.Camera;

namespace Sprint1Game.Animation
{
    public class ScoreTextAnimation : IAnimationInGame
    {
        public Vector2 Location { get { return location; } set { location = value; } }

        public AnimationState State { get; set; }

        public Vector2 Velocity { get { return new Vector2(GameUtilities.StationaryVelocity, velocityY); } set { } }

        private const float EndYOffset = 15;
        private Vector2 location;
        private float velocityY;
        private float accelerationY;
        private float endLocationY;
        private float cameraXToTextDistance;
        private ITextSprite textSprite;

        public ScoreTextAnimation(Vector2 location, string score)
        {
            this.textSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            this.textSprite.Text = score;
            this.State = AnimationState.NotStart;
            this.endLocationY = location.Y - EndYOffset * GameUtilities.SinglePixel;
            this.location = location;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            textSprite.Draw(spriteBatch, location);
        }

        public void StartAnimation()
        {
            State = AnimationState.IsPlaying;
            GameUtilities.GameObjectManager.AddAnimation(this);
            accelerationY = GameUtilities.ScoreTextGravity;
            velocityY = GameUtilities.ScoreTextInitialVelocity;
            cameraXToTextDistance = location.X - Camera2D.CameraX;
        }

        public void Update()
        {
            if (State == AnimationState.IsPlaying)
            {
                velocityY = velocityY + accelerationY;
                location.Y = location.Y + velocityY;
                location.X = Camera2D.CameraX + cameraXToTextDistance;
                if (location.Y < endLocationY)
                {
                    State = AnimationState.Stopped;
                }
            }
            textSprite.Update();
        }
    }
}
