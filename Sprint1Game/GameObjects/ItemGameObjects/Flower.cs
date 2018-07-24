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
    public class Flower : IItem
    {
        private ISprite sprite;
        public Vector2 Location { get; set; }
        private Vector2 initialLocation;
        public ObjectType Type { get; } = ObjectType.Flower;

        public Rectangle Destination { get; set; }

        public bool IsCollected { get; set; } = false;
        public bool IsPreparing { get; set; } = true;
        public Vector2 Velocity { get; set; }
        public Flower(Vector2 location)
        {
            sprite = ItemSpriteFactory.Instance.CreateFlowerSprite();
            Location = location;
            initialLocation = location;
            Destination = sprite.MakeDestinationRectangle(Location);
            Velocity = new Vector2(GameUtilities.StationaryVelocity, -GameUtilities.FlowerGravity);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Location);
        }

        public void Collect()
        {
            ScoringSystem.AddPointsForCollectingItem(this);
            sprite = ItemSpriteFactory.Instance.CreateDisappearedSprite();
            IsCollected = true;
            SoundManager.Instance.PlayPowerUpSound();
        }

        public void Update()
        {
            if (IsPreparing)
            {
                Location = new Vector2(Location.X, Location.Y + Velocity.Y);
                Destination = sprite.MakeDestinationRectangle(Location);
                if (Location.Y <= initialLocation.Y - Destination.Height + 2 * GameUtilities.SinglePixel)
                {
                    Velocity = new Vector2(GameUtilities.StationaryVelocity, GameUtilities.StationaryVelocity);
                    IsPreparing = false;
                }
                return;
            }

            Destination = sprite.MakeDestinationRectangle(Location);
            sprite.Update();
        }
    }
}