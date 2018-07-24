using Sprint1Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.SpriteFactories;
using Sprint1Game.Sprites.Projectiles;
using Sprint1Game.Camera;
using Sprint1Game.Sound;

namespace Sprint1Game.GameObjects
{
    public class FireBallProjectile : IProjectile
    {
        public Vector2 Acceleration { get; set; }
        public Vector2 Location { get; set; }
        public ISprite Sprite { get; set; } 
        public Rectangle DestinationRectangle { get; set; }
        public Rectangle Destination { get; set; }
        public GameObjectType.ObjectType Type { get; } = GameObjectType.ObjectType.FireBallProjectile;      
        public Vector2 Velocity { get; set; }
        public int InitiatingPlayer { get { return player; } }
        public bool Used { get; set; } = false;
        private int terminationCount = 0;
        private int player; 
        private const int HorizontalChange = 1;
        private const int VerticalChange = 1;
        private const int fullScreenWidth = 480;
        private const int maxYSpeed = 3;
        private const int minTerminationCount = 2;

        public FireBallProjectile(Vector2 location, int player)
        {
            Sprite = ProjectileSpriteFactory.Instance.CreateFireBallSprite();
            SoundManager.Instance.PlayFireballSound();
            Location = location;
            this.player = player;
            Velocity = new Vector2(GameUtilities.StationaryVelocity, GameUtilities.StationaryVelocity);
            Acceleration = new Vector2(GameUtilities.StationaryAcceleration, GameUtilities.Gravity);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Location);
        }
        public void Terminate()
        {
            Used = true;
            Acceleration = new Vector2(GameUtilities.StationaryAcceleration, GameUtilities.StationaryAcceleration);
            Velocity = new Vector2(GameUtilities.StationaryVelocity, GameUtilities.StationaryVelocity);    
            Sprite = ProjectileSpriteFactory.Instance.CreateFireBallCombustSprite();
            terminationCount = 0;
        }
        public void Update()
        {
            if (this.Location.X - this.Destination.Width < Camera2D.CameraX ||
                this.Location.X > Camera2D.CameraX + fullScreenWidth)
            {
                this.Terminate();
            }
            
            if (Velocity.Y < maxYSpeed)
            {
                Velocity = new Vector2(this.Velocity.X, this.Velocity.Y + this.Acceleration.Y);
            }
            
            if (Used)
            {
                terminationCount++;
            }
                
            if (terminationCount > minTerminationCount)
            {
                Sprite = ItemSpriteFactory.Instance.CreateDisappearedSprite();
            }

            this.Location = new Vector2(this.Location.X + this.Velocity.X, this.Location.Y + this.Velocity.Y);
            Destination = Sprite.MakeDestinationRectangle(Location);
            Sprite.Update();
        }
    }
}
