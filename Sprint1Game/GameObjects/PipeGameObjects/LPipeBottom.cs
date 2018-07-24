using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.Camera;
using Sprint1Game.Interfaces;
using Sprint1Game.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint1Game.GameObjects.GameObjectType;

namespace Sprint1Game.GameObjects.PipeGameObjects
{
    class LPipeBottom : IPipe
    {
        private ISprite sprite;
        public ObjectType Type { get; } = ObjectType.Pipe;
        public Vector2 Location { get; set; }
        public Rectangle Destination { get; set; }
        private Vector2 teleLocation;
        public bool IsTelable { get; set; } = false;

        public LPipeBottom(Vector2 location, Vector2 teleLocation)
        {
            sprite = PipeSpriteFactory.Instance.CreateLPipeBottomSprite();
            Location = location;
            Destination = sprite.MakeDestinationRectangle(Location);
            this.teleLocation = teleLocation;
            IsTelable = true;
        }

        public LPipeBottom(Vector2 location)
        {
            sprite = PipeSpriteFactory.Instance.CreateLPipeBottomSprite();
            Location = location;
            Destination = sprite.MakeDestinationRectangle(Location);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, this.Location);
        }

        public void Warp(IMario mario)
        {
            if(IsTelable)
            {
                Camera2D.SetCamera(new Vector2(teleLocation.X - 16 * 5, 0));
                mario.Velocity = Vector2.Zero;
                mario.Location = new Vector2(teleLocation.X - 8, teleLocation.Y - mario.Destination.Height);
                SoundManager.Instance.PlayPipeSound();
            }
        }

        public void Update()
        {
            Destination = sprite.MakeDestinationRectangle(Location);
            sprite.Update();
        }
    }
}
