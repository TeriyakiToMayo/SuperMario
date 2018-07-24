using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.GameObjects.EnemyGameObjects;
using Sprint1Game.Interfaces;
using Sprint1Game.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.States.EnemyStates
{
    class HorseLeftState : IEnemyState
    {
        public ISprite StateSprite { get; set; }
        private Horse horse;
        public HorseLeftState(Horse h)
        {
            StateSprite = EnemySpriteFactory.Instance.CreateHorseLeftSprite();
            horse = h;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            StateSprite.Draw(spriteBatch, location);
        }

        public void Terminate(string direction)
        {
            horse.State = new HorseDeadState(horse);
        }
        public void Update()
        {
            StateSprite.Update();
        }
        public void ChangeDirection()
        {
            horse.State = new HorseRightState(horse);
        }
    }
}
