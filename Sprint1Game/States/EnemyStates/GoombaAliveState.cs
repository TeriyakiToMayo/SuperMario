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
    public class GoombaAliveState : IEnemyState
    {
        public ISprite StateSprite { get; set; }

        private Goomba2 goomba;

        public GoombaAliveState(Goomba2 goomba)
        {
            StateSprite = EnemySpriteFactory.Instance.CreateGoombaSprite();
            this.goomba = goomba;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            StateSprite.Draw(spriteBatch, location);
        }

        public void Terminate(string direction)
        {
            if (direction.ToUpper().Equals("TOP"))
                goomba.State = new GoombaDeadState();
            else if (direction.ToUpper().Equals("RIGHT") || direction.ToUpper().Equals("LEFT"))
                goomba.State = new GoombaSideDeathState();
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
