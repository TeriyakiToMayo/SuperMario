using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint1Game.Interfaces;
using Sprint1Game.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.GameObjects.EnemyGameObjects;

namespace Sprint1Game.States.EnemyStates
{
    class HorseDeadState: IEnemyState
    {
        public ISprite StateSprite { get; set; }
        private Horse horse;
        public HorseDeadState(Horse h)
        {
            StateSprite = EnemySpriteFactory.Instance.CreateDeadHorseSprite();
            horse = h;
            horse.ToString();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            StateSprite.Draw(spriteBatch, location);
        }

        public void Terminate(string direction)
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

