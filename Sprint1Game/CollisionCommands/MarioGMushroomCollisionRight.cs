using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint1Game.Interfaces;

namespace Sprint1Game.CollisionCommands
{
    class MarioGMushroomCollisionRight : ICollisionCommand
    {
        public MarioGMushroomCollisionRight()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IMario mario = (IMario)gameObject1;
            if (mario.State.MarioShape == MarioState.MarioShapeEnums.Dead)
            {
                return;
            }
            IItem mush = (IItem)gameObject2;
            if (!mush.IsCollected)
            {
                mush.Collect();
            }
        }
    }
}