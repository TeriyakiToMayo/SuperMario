using Sprint1Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.GameObjects;
using Sprint1Game.SpriteFactories;

namespace Sprint1Game.States.EnemyStates
{
    public class GoombaDeadState : IEnemyState
    {
        public ISprite StateSprite { get; set; }
        private int count = 0;

        public GoombaDeadState()
        {
            StateSprite = EnemySpriteFactory.Instance.CreateDeadGoombaSprite();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            StateSprite.Draw(spriteBatch, location);
        }

        public void Terminate(String direction)
        {
           
        }

        public void Update()
        {
            count++;
            if (count > 60)
                StateSprite = ItemSpriteFactory.Instance.CreateDisappearedSprite();
        }

        public void ChangeDirection()
        {
        }
    }
}
