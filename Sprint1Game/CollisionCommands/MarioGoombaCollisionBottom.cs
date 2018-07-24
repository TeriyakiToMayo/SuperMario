using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint1Game.Interfaces;

using static Sprint1Game.GameObjects.GameObjectType;
using Sprint1Game.SpriteFactories;
using Sprint1Game.HeadsUp;
using Sprint1Game.Sound;

namespace Sprint1Game.CollisionCommands
{
    public class MarioGoombaCollisionBottom : ICollisionCommand
    {
        public MarioGoombaCollisionBottom()
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
            ScoringSystem.PlayerScore(mario.Player).AddPointsForStompingEnemy(gameObject2);
            goomba.Terminate("LEFT");
            SoundManager.Instance.PlayStompSound();
        }
    }
}
