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
    public interface IEnemy : IGameObject
    {
        IEnemyState State { get; set; }
        bool CanUpdate { get; }
        bool Alive { get; set; }
        bool Moving { get; set; }
        Vector2 Velocity { get; set; }
        void Terminate(String direction);
        void ChangeDirection();
    }
}
