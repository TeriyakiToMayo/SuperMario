using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint1Game.Interfaces;
using Microsoft.Xna.Framework;
using Sprint1Game.GameObjects;
using Sprint1Game.HeadsUp;
using Sprint1Game.Sound;
using Sprint1Game.GameObjects.BlockGameObjects;

namespace Sprint1Game.Commands
{
    public class MarioBlockCollisionBottomCommand : ICollisionCommand
    {
        public MarioBlockCollisionBottomCommand()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IMario mario = (IMario)gameObject1;
            if(mario.State.MarioShape == MarioState.MarioShapeEnums.Dead)
            {
                return;
            }
            if (gameObject2.GetType() == typeof(HiddenBlock) && mario.Velocity.Y >= GameUtilities.StationaryVelocity)
            {
                return;
            }

            IBlock block = (IBlock)gameObject2;
            mario.Location = new Vector2(mario.Destination.X, block.Destination.Y + block.Destination.Height - GameUtilities.SinglePixel);
            if(mario.Velocity.Y < GameUtilities.StationaryVelocity)
            {
                mario.Velocity = new Vector2(mario.Velocity.X, GameUtilities.StationaryVelocity);
                if(!((mario.State.MarioShape == MarioState.MarioShapeEnums.Small ||
                    mario.State.MarioShape == MarioState.MarioShapeEnums.StarSmall) &&
                    (block.GetType() == typeof(BrickBlock) || block.GetType() == typeof(UndergroundBrickBlock))))
                {
                    block.Trigger();
                }
                if((mario.State.MarioShape == MarioState.MarioShapeEnums.Small ||
                    mario.State.MarioShape == MarioState.MarioShapeEnums.StarSmall) &&
                    (block.GetType() == typeof(BrickBlock) || block.GetType() == typeof(UndergroundBrickBlock)))
                {
                    int verticalDisplacement = 5 * GameUtilities.SinglePixel;
                    block.Location = new Vector2(block.Location.X, block.Location.Y - verticalDisplacement);
                    SoundManager.Instance.PlayBumpSound();
                }
                if ((mario.State.MarioShape == MarioState.MarioShapeEnums.Big || 
                    mario.State.MarioShape == MarioState.MarioShapeEnums.Fire || 
                    mario.State.MarioShape == MarioState.MarioShapeEnums.StarBig) 
                    && block.GetType() == typeof(QuestionmarkBlock))
                {
                    SoundManager.Instance.PlayBumpSound();
                }
            }
        }
    }
}
