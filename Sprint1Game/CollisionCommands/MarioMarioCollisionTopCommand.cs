using Sprint1Game.Interfaces;
using Sprint1Game.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.CollisionCommands
{
    public class MarioMarioCollisionTopCommand : ICollisionCommand
    {
        public MarioMarioCollisionTopCommand()
        {

        }

        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IMario mario = (IMario)gameObject1;
            IMario mario2 = (IMario)gameObject2;
            if (mario.State.MarioShape == MarioState.MarioShapeEnums.Dead ||
                mario2.State.MarioShape == MarioState.MarioShapeEnums.Dead ||
                mario.IsProtected || mario2.IsProtected)
            {
                return;
            }

            switch (mario2.State.MarioShape)
            {
                case MarioState.MarioShapeEnums.Small:
                    mario2.State.Terminated();
                    break;
                case MarioState.MarioShapeEnums.Big:
                    mario2.IsProtected = true;
                    GameUtilities.GameObjectManager.MarioTransition(mario2.State.MarioShape, MarioState.MarioShapeEnums.Small, mario2);
                    SoundManager.Instance.PlayPipeSound();
                    break;
                case MarioState.MarioShapeEnums.Fire:
                    mario2.IsProtected = true;
                    GameUtilities.GameObjectManager.MarioTransition(mario2.State.MarioShape, MarioState.MarioShapeEnums.Small, mario2);
                    SoundManager.Instance.PlayPipeSound();
                    break;
            }
        }
    }
}
