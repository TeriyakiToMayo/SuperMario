using Sprint1Game.GameObjects;
using Sprint1Game.Interfaces;
using Sprint1Game.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.CollisionCommandsProjectiles
{
    public class FireBallMarioCollision : ICollisionCommand
    {
        public FireBallMarioCollision()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            if(GameUtilities.Game.State.Type != GameStates.Competitive)
            {
                return;
            }
            IMario mario = (IMario)gameObject2;
            if (mario.State.MarioShape == MarioState.MarioShapeEnums.Dead ||
                mario.IsProtected)
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
