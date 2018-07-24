using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.Sprites.Horse
{
    class HorseRightSprite: ISprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Destination { get; set; }
        private Rectangle sourceRectangle;
        private int[] horseWidth = EnemySpriteFactory.Instance.HorseWidthR();
        private int[] horseHeight = EnemySpriteFactory.Instance.HorseHeightR();
        private int[] TextureX = EnemySpriteFactory.Instance.HorseXR();
        private int[] TextureY = EnemySpriteFactory.Instance.HorseYR();
        private int currentFrame = 0;
        private int TotalFrames = EnemySpriteFactory.Instance.HorseTotalFrames;
        private int counter = 0;

        public HorseRightSprite(Texture2D t)
        {
            Texture = t;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Location = location;
            sourceRectangle = new Rectangle(TextureX[currentFrame], TextureY[currentFrame], horseWidth[currentFrame], horseHeight[currentFrame]);
            
            Destination = MakeDestinationRectangle(location);

            spriteBatch.Draw(Texture, Destination, sourceRectangle, Color.White);
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, horseWidth[currentFrame], horseHeight[currentFrame]);
        }

        public void Update()
        {
            Destination = MakeDestinationRectangle(Location);
            if (counter % 5 == 0)
            {
                currentFrame++;
                currentFrame = currentFrame % TotalFrames;
                counter = 0;
            }
            counter++;
        }
    }
}

