﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint1Game.GameObjects.GameObjectType;

namespace Sprint1Game.GameObjects.PipeGameObjects
{
    class LPipe : IPipe
    {
        private ISprite sprite;
        public ObjectType Type { get; } = ObjectType.LPipe;
        public Vector2 Location { get; set; }
        public Rectangle Destination { get; set; }

        public LPipe(Vector2 location)
        {
            sprite = PipeSpriteFactory.Instance.CreateLPipeSprite();
            Location = location;
            Destination = sprite.MakeDestinationRectangle(Location);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, this.Location);
        }

        public void Warp(IMario mario)
        {
        }

        public void Update()
        {
            Destination = sprite.MakeDestinationRectangle(Location);
            sprite.Update();
        }
    }
}
