using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.GameObjects;
using Sprint1Game.Interfaces;
using Sprint1Game.SpriteFactories;
using Sprint1Game.States.EnemyStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.States
{
    class KoopaAliveRightState : IEnemyState
    {
        public ISprite StateSprite { get; set; }
        private Koopa2 koopa_;
        public KoopaAliveRightState(Koopa2 koopa)
        {
            StateSprite = EnemySpriteFactory.Instance.CreateKoopaRightSprite();
            koopa_ = koopa;
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
                koopa_.State = new KoopaSideDeathState(koopa_);
        }

        public void Update()
        {
            StateSprite.Update();
        }

        public void ChangeDirection()
        {
            koopa_.State = new KoopaAliveState(koopa_);
        }
    }
}
