using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.Interfaces
{
    public interface IItem : IGameObject
    {
        Vector2 Velocity { get; set; }
        bool IsCollected { get; set; }
        bool IsPreparing { get; set; }
        void Collect();
    }
}