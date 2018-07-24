using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint1Game.Interfaces;
using static Sprint1Game.GameObjects.GameObjectType;
using Sprint1Game.SpriteFactories;
using Microsoft.Xna.Framework;
using Sprint1Game.HeadsUp;
using Sprint1Game.Sound;

namespace Sprint1Game.CollisionCommands
{
    public class MarioGoombaCollisionTop : ICollisionCommand
    {
        public MarioGoombaCollisionTop()
        {

        }
        
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IMario mario = (IMario)gameObject1;
            IEnemy goomba = (IEnemy)gameObject2;
            if (mario.State.MarioShape == MarioState.MarioShapeEnums.Dead || !goomba.Alive)
            {
                return;
            }
            
            mario.Location = new Vector2(mario.Location.X, goomba.Location.Y - mario.Destination.Height+ GameUtilities.SinglePixel);
            if (goomba.Alive)
            {
                mario.Velocity = new Vector2(mario.Velocity.X, GameUtilities.MarioBounceVelocity);
                ScoringSystem.PlayerScore(mario.Player).AddPointsForStompingEnemy(gameObject2);
                goomba.Terminate("TOP");
                SoundManager.Instance.PlayStompSound();
            }
                
        }
    }
}
