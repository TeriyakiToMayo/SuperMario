using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.SpriteFactories;

namespace Sprint1Game.Sprites.Koopa
{
    class KoopaSideDeathSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Destination { get; set; }

        Rectangle sourceRectangle;
        private int koopaWidth = EnemySpriteFactory.Instance.KoopaWidth;
        private int koopaHeight = EnemySpriteFactory.Instance.KoopaHeight;
        private int textureX = (int)EnemySpriteFactory.Instance.KoopaSideDeadCord.X;
        private int textureY = (int)EnemySpriteFactory.Instance.KoopaSideDeadCord.Y;



        public KoopaSideDeathSprite(Texture2D texture)
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
            sourceRectangle = new Rectangle(textureX * koopaWidth, textureY * koopaHeight, koopaWidth, koopaHeight);
            Destination = MakeDestinationRectangle(location);

            spriteBatch.Draw(Texture, Destination, sourceRectangle, Color.White);
        }


        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, koopaWidth, koopaHeight);
        }
    }
}
