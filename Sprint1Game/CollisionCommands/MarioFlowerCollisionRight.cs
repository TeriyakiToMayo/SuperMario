using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint1Game.Interfaces;

namespace Sprint1Game.CollisionCommands
{
    class MarioFlowerCollisionRight : ICollisionCommand
    { 
        public MarioFlowerCollisionRight()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IMario mario = (IMario)gameObject1;
            if (mario.State.MarioShape == MarioState.MarioShapeEnums.Dead)
            {
                return;
            }
            IItem flower = (IItem)gameObject2;
            if (!flower.IsCollected)
            {
                flower.Collect();
                switch (mario.State.MarioShape)
                {
                    case MarioState.MarioShapeEnums.Small:
                        GameUtilities.GameObjectManager.MarioTransition(mario.State.MarioShape, MarioState.MarioShapeEnums.Fire, mario);
                        break;
                    case MarioState.MarioShapeEnums.Big:
                        GameUtilities.GameObjectManager.MarioTransition(mario.State.MarioShape, MarioState.MarioShapeEnums.Fire, mario);
                        break;
                    case MarioState.MarioShapeEnums.StarSmall:
                        GameUtilities.GameObjectManager.MarioTransition(mario.State.MarioShape, MarioState.MarioShapeEnums.StarBig, mario);
                        mario.PreStarShape = MarioState.MarioShapeEnums.Fire;
                        break;
                    case MarioState.MarioShapeEnums.StarBig:
                        mario.PreStarShape = MarioState.MarioShapeEnums.Fire;
                        break;
                }
            }
        }
    }
}