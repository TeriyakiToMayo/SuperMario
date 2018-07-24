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
    public class BigPipe : IPipe
    {
        private ISprite sprite;
        public ObjectType Type { get; } = ObjectType.Pipe;
        public Vector2 Location { get; set; }
        public Rectangle Destination { get; set; }
        private bool canWarp = false;
        private Vector2 teleLocation;

        public BigPipe(Vector2 location)
        {
            sprite = PipeSpriteFactory.Instance.CreateBigPipeSprite();
            Location = location;
            Destination = sprite.MakeDestinationRectangle(Location);
        }

        public BigPipe(Vector2 location, Vector2 teleLocation)
        {
            sprite = PipeSpriteFactory.Instance.CreateBigPipeSprite();
            Location = location;
            Destination = sprite.MakeDestinationRectangle(Location);
            this.teleLocation = teleLocation;
            canWarp = true;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, this.Location);
        }

        public void Warp(IMario mario)
        {
            if (canWarp)
            {
                Camera2D.SetCamera(new Vector2(teleLocation.X - 16 * 2, 0));
                mario.Location = teleLocation;
                SoundManager.Instance.PlayPipeSound();
                if (MarioAttributes.Time <= 100)
                {
                    SoundManager.Instance.PlayHurryUnderworldSong();
                }
                else
                {
                    SoundManager.Instance.PlayUnderworldSong();
                }
            }
        }

        public void Update()
        {
            Destination = sprite.MakeDestinationRectangle(Location);
            sprite.Update();
        }
    }
}
