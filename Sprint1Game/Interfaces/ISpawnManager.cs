using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.Interfaces
{
    public interface ISpawnManager
    {
        void Update();
        void EnemyTerminated();
        void AddSpawner(ISpawner s);
    }
}
