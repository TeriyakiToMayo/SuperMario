using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint1Game.Interfaces;
using static Sprint1Game.GameObjects.GameObjectType;
using Sprint1Game.States.EnemyStates;
using Microsoft.Xna.Framework;
using Sprint1Game.GameObjects;
using Sprint1Game.HeadsUp;
using Sprint1Game.Sound;

namespace Sprint1Game.CollisionCommands
{
    public class MarioKoopaCollisionLeft : ICollisionCommand
    {
        public MarioKoopaCollisionLeft()
        {
        }
        
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IMario mario = (IMario)gameObject1;
            if (mario.State.MarioShape == MarioState.MarioShapeEnums.Dead ||
                mario.IsProtected)
            {
                return;
            }
            Koopa2 koopa = (Koopa2)gameObject2;
            if (koopa.State.GetType() == typeof(KoopaSideDeathState))
            {
                return;
            }

            int marioPreY = (int)(mario.Destination.Y - (mario.Velocity.Y - GameUtilities.SinglePixel));
            if (marioPreY + mario.Destination.Height < gameObject2.Destination.Y)
            {
                ICollisionCommand TopCommand = new MarioKoopaCollisionTop();

                TopCommand.Execute(gameObject1, gameObject2);
                return;
            }

            else if (marioPreY > gameObject2.Destination.Y + gameObject2.Destination.Height)
            {
                ICollisionCommand BottomCommand = new MarioKoopaCollisionBottom();
                BottomCommand.Execute(gameObject1, gameObject2);
                return;
            }

            if (mario.State.IsStar == true)
            {
                ScoringSystem.PlayerScore(mario.Player).AddPointsForSpecialKoopaHit(gameObject2);
                koopa.Terminate("DOWN");
            }
            else
            {
                if (koopa.State.GetType() == typeof(KoopaDeadState) &&
                    koopa.Velocity.X == GameUtilities.StationaryVelocity)
                {
                    ScoringSystem.PlayerScore(mario.Player).AddPointsForInitiatingShell(gameObject2);
                    koopa.Velocity = new Vector2(GameUtilities.KoopaShellVelocity, koopa.Velocity.Y);

                    SoundManager.Instance.PlayKickSound();
                    return;
                }else if(koopa.State.GetType() == typeof(KoopaDeadState) && koopa.Velocity.X > 0)
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
                        SoundManager.Instance.PlayPipeSound();
                        GameUtilities.GameObjectManager.MarioTransition(mario.State.MarioShape, MarioState.MarioShapeEnums.Small, mario);
                        break;
                }
                mario.Location = new Vector2(mario.Location.X, mario.Location.Y);
            }
        }
    }
}
