using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint1Game
{
    class QuestionmarkBlockSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        private int currentSpriteFrame;
        private int totalSpriteFrame;
        private int spriteFrameIncrement;
        private int currentDrawingFrame;
        private int drawingFrameDelay;
        private int height;
        private int width;

        public QuestionmarkBlockSprite(Texture2D texture)
        {
            this.Texture = texture;
            totalSpriteFrame = BlockSpriteFactory.StageOneSpriteColumns;
            currentDrawingFrame = 0;
            drawingFrameDelay = 10;
            currentSpriteFrame = 0;
            spriteFrameIncrement = -1;
            width = this.Texture.Width / BlockSpriteFactory.StageOneSpriteColumns;
            height = this.Texture.Height / BlockSpriteFactory.StageOneSpriteRows;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            
            int row = BlockSpriteFactory.StageOneSpriteQuestionmark1BlockRow;
            int column = currentSpriteFrame;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = MakeDestinationRectangle(location);

             
            spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.White);
             
        }

        public void Update()
        {
            currentDrawingFrame++;
            if(currentDrawingFrame == drawingFrameDelay)
            {
                currentDrawingFrame = 0;
                if(currentSpriteFrame == 0 || currentSpriteFrame == totalSpriteFrame - 1)
                {
                    spriteFrameIncrement *= -1;
                }
                currentSpriteFrame += spriteFrameIncrement;

            }
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, width * GameUtilities.SpriteSize, height * GameUtilities.SpriteSize);
        }
    }
}
