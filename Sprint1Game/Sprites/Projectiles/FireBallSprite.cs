using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint1Game.Sprites.Projectiles
{
    class FireBallSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Destination { get; set; }
        Rectangle sourceRectangle;
        private int[] FireBallWidth = {7,7,7,7,7,11,15};
        private int[] FireBallHeight = {7,7,7,7,7,13,15};
        private int[] TextureX = {0,11,23,35,47,59,75};
        private int[] TextureY = {3,3,33,4,1,0};
        private int count;
        
        public FireBallSprite(Texture2D texture)
        {
            Texture = texture;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Location = location;
            sourceRectangle = new Rectangle(TextureX[count], TextureY[count], FireBallWidth[count], FireBallHeight[count]);
            Destination = MakeDestinationRectangle(location);
        
            spriteBatch.Draw(Texture, Destination, sourceRectangle, Color.White);
             
        }
 
        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, FireBallWidth[count], FireBallHeight[count]);
        }

        public void Update()
        {
            count++;
            count = count % 4;
            Destination = MakeDestinationRectangle(Location);
        }
    }
}
