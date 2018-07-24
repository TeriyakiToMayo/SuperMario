using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Sprint1Game.GameObjects.GameObjectType;
using Sprint1Game.Interfaces;

namespace Sprint1Game
{
    public class CrackedBlock : IBlock
    {
        private ISprite sprite;
        public ObjectType Type { get; } = ObjectType.Block;
        public Vector2 Location { get; set; }
        public Rectangle Destination { get; set; }

        public CrackedBlock(Vector2 location)
        {
            sprite = BlockSpriteFactory.Instance.CreateCrackedBlockSprite();
            Location = location;
            Destination = sprite.MakeDestinationRectangle(Location);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Location);
        }

        public void Trigger()
        {
        }

        public void Update()
        {
            Destination = sprite.MakeDestinationRectangle(Location);
            sprite.Update();
        }
    }
}
