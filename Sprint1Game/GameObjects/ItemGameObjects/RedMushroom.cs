using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.GameObjects;
using Sprint1Game.Sound;
using Sprint1Game.HeadsUp;
using Sprint1Game.Interfaces;

namespace Sprint1Game
{
    public class RedMushroom : IItem
    {
        private ISprite sprite;
        public Vector2 Location { get; set; }
        private Vector2 initialLocation;
        public Rectangle Destination { get; set; }

        public GameObjectType.ObjectType Type { get; } = GameObjectType.ObjectType.RedMushroom;

        public bool IsCollected { get; set; } = false;
        public bool IsPreparing { get; set; } = true;
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }


        public RedMushroom(Vector2 location)
        {
            sprite = ItemSpriteFactory.Instance.CreateRedMushroomSprite();
            Location = location;
            initialLocation = location;
            Destination = sprite.MakeDestinationRectangle(Location);
            Velocity = new Vector2(0, -0.5f);
            Acceleration = new Vector2(0, 0);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, this.Location);
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
                if (Location.Y <= initialLocation.Y - this.Destination.Height)
                {
                    Velocity = new Vector2(2, 0);
                    Acceleration = new Vector2(0, 0.5f);
                    IsPreparing = false;
                }
                return;
            }

            if (Velocity.Y < 6)
            {
                Velocity = new Vector2(Velocity.X, Velocity.Y + Acceleration.Y);
            }
            Location = new Vector2(Location.X + Velocity.X, Location.Y + Velocity.Y);
            Destination = sprite.MakeDestinationRectangle(Location);
            sprite.Update();
        }

        public void ChangeDirection()
        {
            Velocity = new Vector2(-Velocity.X, Velocity.Y);
        }
    }
}

