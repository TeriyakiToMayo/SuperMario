using Microsoft.Xna.Framework;
using Sprint1Game.Interfaces;
using Sprint1Game.States.GameStates;
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
                return graphics;
            }
            set
            {
                this.graphics = value;
            }
        }

        public IGameState State { get; set; }

        public bool IsPause { get; set; } = false;
        public bool IsControllerEnable { get; set; } = true;
        public bool IsInAnimation { get; set; } = false;
    }
}
