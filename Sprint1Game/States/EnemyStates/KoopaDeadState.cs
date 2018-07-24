using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.GameObjects;
using Sprint1Game.Interfaces;
using Sprint1Game.SpriteFactories;

namespace Sprint1Game.States.EnemyStates
{
    public class KoopaDeadState : IEnemyState
    {
        public ISprite StateSprite { get; set; }
        private Koopa2 koopa_;
        private int totalDuration = 200;
        private int duration;
        public KoopaDeadState(Koopa2 koopa)
        {
            this.koopa_ = koopa;
            StateSprite = EnemySpriteFactory.Instance.CreateDeadKoopaSprite();
            duration = totalDuration;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            StateSprite.Draw(spriteBatch, location);
        }

        public void Terminate(String direction)
        {
            if (!direction.ToUpper().Equals("UP"))
            {
                koopa_.State = new KoopaSideDeathState(koopa_);
            }
        }

        public void Update()
        {
            if(koopa_.Velocity.X != 0)
            {
                duration = totalDuration;
            }else
            {
                duration--;
            }

            if(duration == 0)
            {
                koopa_.Velocity = new Vector2(-1, 0);
                koopa_.State = new KoopaAliveState(koopa_);
            }

            StateSprite.Update();
        }

        public void ChangeDirection()
        {
        }
    }
}
