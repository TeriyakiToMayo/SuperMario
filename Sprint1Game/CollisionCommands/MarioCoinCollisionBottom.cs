using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint1Game.Interfaces;

namespace Sprint1Game.CollisionCommands
{
    public class MarioCoinCollisionBottom : ICollisionCommand
    {
        public MarioCoinCollisionBottom()
        {

        }
        
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IMario mario = (IMario)gameObject1;
            if (mario.State.MarioShape == MarioState.MarioShapeEnums.Dead)
            {
                return;
            }
            IItem coin = (IItem)gameObject2;
            if (!coin.IsCollected)
            {
                coin.Collect();
            }         
        }
    }
}
