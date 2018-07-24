using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint1Game
{
    class DisappearedSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public DisappearedSprite(Texture2D texture)
        {
            this.Texture = texture;
        }
        
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(GameUtilities.Origin, GameUtilities.Origin, GameUtilities.Origin, GameUtilities.Origin);
            Rectangle destinationRectangle = MakeDestinationRectangle(new Vector2(GameUtilities.Origin, GameUtilities.Origin));
            
            spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.Transparent);
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, GameUtilities.Origin, GameUtilities.Origin);
        }

        public void Update() { }
        
    }
}
