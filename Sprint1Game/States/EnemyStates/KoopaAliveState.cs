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
    public class KoopaAliveState : IEnemyState
    {
        public ISprite StateSprite { get; set; }
        private Koopa2 koopa_;
        public KoopaAliveState(Koopa2 koopa)
        {
            StateSprite = EnemySpriteFactory.Instance.CreateKoopaSprite();
            this.koopa_ = koopa;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            StateSprite.Draw(spriteBatch, location);
        }

        public void Terminate(String direction)
        {
            if (direction.ToUpper().Equals("UP"))
                koopa_.State = new KoopaDeadState(koopa_);
            else
            {
                koopa_.State = new KoopaSideDeathState(koopa_);
            }
        }

        public void Update()
        {
            StateSprite.Update();
        }

        public void ChangeDirection()
        {
            koopa_.State = new KoopaAliveRightState(koopa_);
        }
    }
}
