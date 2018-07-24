using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint1Game.Interfaces;

namespace Sprint1Game.CollisionCommands
{
    class MarioStarCollisionLeft : ICollisionCommand
    {
        public MarioStarCollisionLeft()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IMario mario = (IMario)gameObject1;
            if (mario.State.MarioShape == MarioState.MarioShapeEnums.Dead)
            {
                return;
            }
            IItem star = (IItem)gameObject2;
            if (!star.IsCollected)
            {
                star.Collect();
                if (mario.State.MarioShape != MarioState.MarioShapeEnums.StarSmall &&
                    mario.State.MarioShape != MarioState.MarioShapeEnums.StarBig)
                {
                    GameUtilities.GameObjectManager.MarioTransition(mario.State.MarioShape, MarioState.MarioShapeEnums.StarSmall, mario);
                }
            }
        }
    }
}
