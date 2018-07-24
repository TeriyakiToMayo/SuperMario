using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.Interfaces
{
    public interface IProjectile : IGameObject
    {
        ISprite Sprite { get; set; }
        Vector2 Acceleration { get; set; }
        Rectangle DestinationRectangle { get; set; }
        int InitiatingPlayer { get; }
        void Terminate();
    }
}
