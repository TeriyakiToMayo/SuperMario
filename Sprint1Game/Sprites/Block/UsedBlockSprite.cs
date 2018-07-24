using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint1Game
{
    class UsedBlockSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        private int width;
        private int height;
        public UsedBlockSprite(Texture2D texture)
        {
            Texture = texture;
            width = Texture.Width / BlockSpriteFactory.StageOneSpriteColumns;
            height = Texture.Height / BlockSpriteFactory.StageOneSpriteRows;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            
            int row = BlockSpriteFactory.StageOneSpriteUsedBlock1Row;
            int column = BlockSpriteFactory.StageOneSpriteUsedBlock1Column;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = MakeDestinationRectangle(location);

             
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
             
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
