using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.SpriteFactories;

namespace Sprint1Game.Sprites.Horse
{
    class HorseDeadSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Destination { get; set; }
        private Rectangle sourceRectangle;
        private int horseWidth = EnemySpriteFactory.Instance.DeadHorseWidth;
        private int horseHeight = EnemySpriteFactory.Instance.DeadHorseHeight;
        private int TextureX = 0;
        private int TextureY = 0;
        private int currentFrame = 0;
        private int TotalFrames = EnemySpriteFactory.Instance.DeadHorseTotalFrames;
        private int counter = 0;
        private int counterY = 0;

        public HorseDeadSprite(Texture2D t)
        {
            Texture = t;
            
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Location = location;
            
            Destination = MakeDestinationRectangle(Location);
             
            sourceRectangle = new Rectangle(TextureX, TextureY, horseWidth, horseHeight);      

            spriteBatch.Draw(Texture, Destination, sourceRectangle, Color.White);
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, horseWidth, horseHeight);
        }

        public void Update()
        {
            if (counter % 5 == 0)
            {
                TextureX += horseWidth;
                counterY++;
                if(counterY>5)
                    TextureY += horseHeight;
                
                counterY = counterY % 6;
                TextureX = TextureX % Texture.Width;
                TextureY = TextureY % Texture.Height;

                currentFrame++;
                if(currentFrame > TotalFrames)
                {
                    horseWidth = 0;
                    horseHeight = 0;
                }
            }
            counter++;
        }
    }
}
