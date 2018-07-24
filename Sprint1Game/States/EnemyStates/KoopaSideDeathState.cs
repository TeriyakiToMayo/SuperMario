using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.GameObjects;
using Sprint1Game.Interfaces;
using Sprint1Game.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.States.EnemyStates
{
    class KoopaSideDeathState:IEnemyState
    {
        public ISprite StateSprite { get; set; }
        private Koopa2 koopa_;
        public KoopaSideDeathState(Koopa2 koopa)
        {
            this.koopa_ = koopa;
            this.koopa_.Velocity = new Vector2(0, -3.5f);
            StateSprite = EnemySpriteFactory.Instance.CreateKoopaSideDeathSprite();
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
            StateSprite.Update();
        }

        public void ChangeDirection()
        {
        
        }
    }
}
