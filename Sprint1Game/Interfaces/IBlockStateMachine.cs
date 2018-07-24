using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.Interfaces
{
    public interface IBlockStateMachine
    {
        bool Used { get; }
        void BeTriggered();
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        Rectangle MakeDestinationRectangle(Vector2 location);
    }
}
