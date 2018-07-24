using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.Interfaces
{
    public interface IEnemyState
    {
        ISprite StateSprite { get; set; }
        void ChangeDirection();
        void Update();
        void Terminate(String direction);
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
