using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.Sprites.Goomba
{
    class GoombaSideDeathSprite:ISprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Destination { get; set; }

        Rectangle sourceRectangle;
        private int goombaWidth = EnemySpriteFactory.Instance.GoombaWidth;
        private int goombaHeight = EnemySpriteFactory.Instance.GoombaHeight;
        private int textureX = 32;
        private int textureY = 0;



        public GoombaSideDeathSprite(Texture2D texture)
        {
            Texture = texture;
        }

        public void Update()
        {
            Destination = MakeDestinationRectangle(Location);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Location = location;
            sourceRectangle = new Rectangle(textureX, textureY, goombaWidth, goombaHeight);
            Destination = MakeDestinationRectangle(location);

            spriteBatch.Draw(Texture, Destination, sourceRectangle, Color.White);
        }


        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, goombaWidth, goombaHeight);
        }
    }
}
