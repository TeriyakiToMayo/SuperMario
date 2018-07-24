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
    public class StoneBlock : IBlock
    {
        private ISprite sprite;
        public ObjectType Type { get; } = ObjectType.Block;
        public Vector2 Location { get; set; }
        public Rectangle Destination { get; set; }

        public StoneBlock(Vector2 location)
        {
            sprite = BlockSpriteFactory.Instance.CreateStoneBlockSprite();
            Location = location;
            Destination = sprite.MakeDestinationRectangle(Location);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, this.Location);
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
