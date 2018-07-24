using Sprint1Game.CollisionHandling;
using Sprint1Game.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint1Game.CollisionHandling.CollisionSide;
using static Sprint1Game.GameObjects.GameObjectType;

namespace Sprint1Game.Interfaces
{
    public interface ICollisionHandler
    {
        void RegisterCommand(Tuple<ObjectType, ObjectType, Object2Side> collision, ICollisionCommand command);
        bool HandleCollision(IGameObject object1, IGameObject object2);
        void DetectMarioBlockCollisions(IGameObject mario, IGameObject obj);
        void HandleMarioBlockCollisions();
    }
}
