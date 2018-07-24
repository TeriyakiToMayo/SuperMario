using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.Interfaces
{
    public interface IAnimationInGame : IAnimation
    {
        Vector2 Location { set; get; }
        Vector2 Velocity { get; set; }
        void Draw(SpriteBatch spriteBatch);
        void StartAnimation();
    }
}
