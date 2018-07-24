using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint1Game.Sprites.Block
{
    public class HiddenBlockSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        private int height;
        private int width;

        public HiddenBlockSprite(Texture2D texture)
        {
            this.Texture = texture;
            width = Texture.Width / BlockSpriteFactory.StageOneSpriteColumns;
            height = Texture.Height / BlockSpriteFactory.StageOneSpriteRows;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(GameUtilities.Origin, GameUtilities.Origin, GameUtilities.Origin, GameUtilities.Origin);
            Rectangle destinationRectangle = MakeDestinationRectangle(location);

             
            spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.Transparent);
             
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, width * GameUtilities.SpriteSize, height * GameUtilities.SpriteSize);
        }

        public void Update()
        {
        }
    }
}
