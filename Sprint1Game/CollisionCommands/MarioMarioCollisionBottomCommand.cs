using Sprint1Game.Interfaces;
using Sprint1Game.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.CollisionCommands
{
    public class MarioMarioCollisionBottomCommand : ICollisionCommand
    {
        public MarioMarioCollisionBottomCommand()
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

            switch (mario.State.MarioShape)
            {
                case MarioState.MarioShapeEnums.Small:
                    mario.State.Terminated();
                    break;
                case MarioState.MarioShapeEnums.Big:
                    mario.IsProtected = true;
                    GameUtilities.GameObjectManager.MarioTransition(mario.State.MarioShape, MarioState.MarioShapeEnums.Small, mario);
                    SoundManager.Instance.PlayPipeSound();
                    break;
                case MarioState.MarioShapeEnums.Fire:
                    mario.IsProtected = true;
                    GameUtilities.GameObjectManager.MarioTransition(mario.State.MarioShape, MarioState.MarioShapeEnums.Small, mario);
                    SoundManager.Instance.PlayPipeSound();
                    break;
            }
        }
    }
}
