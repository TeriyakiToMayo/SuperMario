using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint1Game.GameObjects.GameObjectType;

namespace Sprint1Game.Interfaces
{
    public interface ISpawner:IGameObject
    {        
        bool RightFacing { get; set; }
        bool SpawnEnemy(ObjectType type);
    }
}
