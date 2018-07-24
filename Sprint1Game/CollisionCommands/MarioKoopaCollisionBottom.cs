using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint1Game.Interfaces;
using static Sprint1Game.GameObjects.GameObjectType;
using Sprint1Game.SpriteFactories;
using Sprint1Game.States.EnemyStates;
using Sprint1Game.HeadsUp;

namespace Sprint1Game.CollisionCommands
{
    public class MarioKoopaCollisionBottom : ICollisionCommand
    {
       
        public MarioKoopaCollisionBottom()
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
            ScoringSystem.PlayerScore(mario.Player).AddPointsForStompingEnemy(gameObject2);
            koopa.Terminate("DOWN");
        }
    }
}
