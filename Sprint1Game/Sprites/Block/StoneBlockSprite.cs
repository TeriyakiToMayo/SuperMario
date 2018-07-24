using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint1Game
{
    class StoneBlockSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        int width;
        int height;

        public StoneBlockSprite(Texture2D texture)
        {
            this.Texture = texture;
            width = this.Texture.Width / BlockSpriteFactory.StageOneSpriteColumns;
            height = this.Texture.Height / BlockSpriteFactory.StageOneSpriteRows;

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            
            int row = BlockSpriteFactory.StageOneSpriteStoneBlock1Row;
            int column = BlockSpriteFactory.StageOneSpriteStoneBlock1Column;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = MakeDestinationRectangle(location);

             
            spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.White);            
        }

        public void Update()
        {
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, width * GameUtilities.SpriteSize, height * GameUtilities.SpriteSize);
        }
    }
}
