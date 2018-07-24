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
    public class PoleScoreTextAnimation : IAnimationInGame
    {
        public Vector2 Location { get { return location; } set { location = value; } }

        public AnimationState State { get; set; }

        public Vector2 Velocity { get { return new Vector2(0, poleVelocity); } set { } }

        private Vector2 location;
        private float endLocationY;
        private float cameraXToTextDistance;
        private ITextSprite textSprite;
        private int locationXFix = 7;

        private float poleVelocity = -1 * GameUtilities.VictoryAnimationDownSpeed;

        public PoleScoreTextAnimation(Rectangle marioDestination, Rectangle poleDestination, string score)
        {
            this.textSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            this.textSprite.Text = score;
            this.State = AnimationState.NotStart;
            this.endLocationY = marioDestination.Y;
            float startingLocationY = poleDestination.Y + poleDestination.Height - textSprite.MakeDestinationRectangle(new Vector2(GameUtilities.Origin)).Height;
            this.location = new Vector2(marioDestination.X + marioDestination.Width + locationXFix, startingLocationY);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            textSprite.Draw(spriteBatch, location);
        }

        public void StartAnimation()
        {
            State = AnimationState.IsPlaying;
            GameUtilities.GameObjectManager.AddAnimation(this);
            cameraXToTextDistance = location.X - Camera2D.CameraX;
        }

        public void Update()
        {
            if (State == AnimationState.IsPlaying && location.Y >= endLocationY)
            {
                location.Y = location.Y + poleVelocity;
                location.X = Camera2D.CameraX + cameraXToTextDistance;
            }
            textSprite.Update();
        }
    }
}
