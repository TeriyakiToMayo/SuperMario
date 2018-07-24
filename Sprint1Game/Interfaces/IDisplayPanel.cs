﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.Interfaces
{
    public interface IDisplayPanel
    {
        bool IsEnable { get; set; }

        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
