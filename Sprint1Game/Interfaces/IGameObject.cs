using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint1Game.GameObjects.GameObjectType;

namespace Sprint1Game.Interfaces
{
    public interface IGameObject
    {
        Vector2 Location { set; get; }
        Rectangle Destination { get; set; }
        ObjectType Type { get; }
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
