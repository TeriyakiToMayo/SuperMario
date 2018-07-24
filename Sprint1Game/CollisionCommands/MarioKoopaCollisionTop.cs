using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint1Game.Interfaces;
using static Sprint1Game.GameObjects.GameObjectType;
using Sprint1Game.SpriteFactories;
using Microsoft.Xna.Framework;
using Sprint1Game.States.EnemyStates;
using Sprint1Game.HeadsUp;
using Sprint1Game.Sound;

namespace Sprint1Game.CollisionCommands
{
    public class MarioKoopaCollisionTop : ICollisionCommand
    {
        public MarioKoopaCollisionTop()
        {
        }       

        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IMario mario = (IMario)gameObject1;
            if (mario.State.MarioShape == MarioState.MarioShapeEnums.Dead)
            {
                return;
            }
            IEnemy koopa = (IEnemy)gameObject2;
            if (koopa.State.GetType() == typeof(KoopaSideDeathState))
            {
                
                return;
            }
            mario.Location = new Vector2(mario.Destination.X, koopa.Location.Y - mario.Destination.Height - GameUtilities.SinglePixel * 5);
            mario.Velocity = new Vector2(mario.Velocity.X, GameUtilities.MarioBounceVelocity);
            if (koopa.State.GetType() == typeof(KoopaDeadState))
            {
                SoundManager.Instance.PlayKickSound();
                if (koopa.Velocity.X == GameUtilities.StationaryVelocity)
                {
                    ScoringSystem.PlayerScore(mario.Player).AddPointsForInitiatingShell(gameObject2);
                    koopa.Velocity = new Vector2(GameUtilities.KoopaShellVelocity, koopa.Velocity.Y);
                } else
                {
                    koopa.Velocity = new Vector2(GameUtilities.StationaryVelocity, koopa.Velocity.Y);
                }
            } else
            {
                ScoringSystem.PlayerScore(mario.Player).AddPointsForStompingEnemy(gameObject2);
                koopa.Terminate("UP");
                koopa.Velocity = new Vector2(GameUtilities.StationaryVelocity, koopa.Velocity.Y);
                SoundManager.Instance.PlayStompSound();
                
            }
        }
    }
}
