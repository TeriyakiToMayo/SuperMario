using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.Interfaces;
using Sprint1Game.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.GameObjects
{
    public class BigBush : IGameObject
    {
            private ISprite sprite;
            public Vector2 Location { get; set; }
            public Rectangle Destination { get; set; }
            public GameObjectType.ObjectType Type { get; } = GameObjectType.ObjectType.BigBush;
            public BigBush(Vector2 location)
            {
                sprite = BackgroundSpriteFactory.Instance.CreateBigBushSprite();
                Location = location;
                Destination = sprite.MakeDestinationRectangle(Location);
            }
            public void Draw(SpriteBatch spriteBatch)
            {
                sprite.Draw(spriteBatch, this.Location);
            }
            public void Update()
            {
                Destination = sprite.MakeDestinationRectangle(Location);
                sprite.Update();
            }
        }
    }
