using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint1Game.MarioState;

namespace Sprint1Game
{
    public interface IMario : IGameObject
    {
        int Player { get; }
        IMarioState State { get; set; }
        bool IsInAir { get; set; }
        bool IsProtected { get; set; }
        MarioShapeEnums PreStarShape { get; set; }
        Vector2 Velocity{ get; set;}
        float MarioTopSpeed { get; set; }
        Vector2 Acceleration { get; set; }
    }
}
