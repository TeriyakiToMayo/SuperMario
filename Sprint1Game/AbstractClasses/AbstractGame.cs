using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game
{
    public abstract class AbstractGame : Game
    {
        private GraphicsDeviceManager graphics;

        public GraphicsDeviceManager GraphicsManager
        {
            get
            {
                graphics.PreferredBackBufferWidth = 480;
                graphics.PreferredBackBufferHeight = 240;
                return graphics;
            }
            set
            {
                this.graphics = value;
            }
        }
    }
}
