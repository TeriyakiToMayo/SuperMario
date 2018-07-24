using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Sprint1Game.GameObjects.GameObjectType;
using Sprint1Game.Sound;
using Sprint1Game.HeadsUp;
using Sprint1Game.Interfaces;

namespace Sprint1Game
{
    public class Coin : IItem
    {
        private ISprite sprite;
        public Vector2 Location { get; set; }
        public Vector2 Velocity { get; set; }
        
        public ObjectType Type { get; } = ObjectType.Coin;

        public Rectangle Destination { get; set; }

        public bool IsCollected { get; set; } = false;
        public bool IsPreparing { get; set; } = true;

        public Coin(Vector2 location)
        {
            sprite = ItemSpriteFactory.Instance.CreateCoinSprite();
            Location = location;
            Destination = sprite.MakeDestinationRectangle(Location);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, this.Location);
        }

        public void Collect()
        {
            sprite = ItemSpriteFactory.Instance.CreateDisappearedSprite();
            IsCollected = true;
            SoundManager.Instance.PlayCoinSound();
            CoinSystem.Instance.AddCoin();
            ScoringSystem.AddPointsForCoin(this);
        }

        public void Update()
        {
            Destination = sprite.MakeDestinationRectangle(Location);
            sprite.Update();
        }
    }
}
