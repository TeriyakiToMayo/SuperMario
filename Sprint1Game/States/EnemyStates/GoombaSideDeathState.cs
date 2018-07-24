using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.Interfaces;
using Sprint1Game.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.States.EnemyStates
{
    class GoombaSideDeathState:IEnemyState
    {
        public ISprite StateSprite { get; set; }

        public GoombaSideDeathState()
        {
            StateSprite = EnemySpriteFactory.Instance.CreateGoombaSideDeathSprite();
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
