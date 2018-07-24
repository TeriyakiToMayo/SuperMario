using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.StateMachines
{
    class CoinBrickBlockStateMachine : IBlockStateMachine
    {
        private ISprite sprite;
        private bool used;
        public bool Used { get { return used; } }

        public CoinBrickBlockStateMachine()
        {
            this.sprite = BlockSpriteFactory.Instance.CreateBrickBlockSprite();
            used = false;
        }

        public void BeTriggered()
        {
            if (used == false)
            {
                this.sprite = BlockSpriteFactory.Instance.CreateUsedBlockSprite();
                used = true;
            }
        }

        public void Update()
        {
            sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return sprite.MakeDestinationRectangle(location);
        }
    }
}
