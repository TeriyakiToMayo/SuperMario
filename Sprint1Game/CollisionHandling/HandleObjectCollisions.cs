using Sprint1Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.CollisionHandling
{
    public static class HandleObjectCollisions
    {
        public static void HandleCollisions(ICollisionHandler collisionHandler, IMario[] marios, Collection<IGameObject> blockList, Collection<IGameObject> enemyList, Collection<IGameObject> itemList, Collection<IGameObject> pipeList, Collection<IGameObject> fireBallList, Collection<IGameObject> fireBallList2)
        {
            HandleMarioCollisions(collisionHandler, marios[GameUtilities.Player1], blockList, enemyList, itemList, pipeList);
            if(marios[GameUtilities.Player2] != null)
            {
                HandleMarioCollisions(collisionHandler, marios[GameUtilities.Player2], blockList, enemyList, itemList, pipeList);
                HandleMarioMarioCollisions(collisionHandler, marios[GameUtilities.Player1], marios[GameUtilities.Player2]);
            }
            HandleEnemyCollisions(collisionHandler, blockList, enemyList, pipeList);
            HandleItemCollisions(collisionHandler, blockList, itemList, pipeList);
            HandleFireBallCollisions(collisionHandler, blockList, enemyList, pipeList, GameUtilities.GameObjectManager.MarioPlayer2, fireBallList);
            HandleFireBallCollisions(collisionHandler, blockList, enemyList, pipeList, GameUtilities.GameObjectManager.MarioPlayer1, fireBallList2);
        }

        private static void HandleMarioMarioCollisions(ICollisionHandler collisionHandler, IMario mario1, IMario mario2)
        {
            collisionHandler.HandleCollision(mario1, mario2);
        }

        private static void HandleMarioCollisions(ICollisionHandler collisionHandler, IMario mario, Collection<IGameObject> blockList, Collection<IGameObject> enemyList, Collection<IGameObject> itemList, Collection<IGameObject> pipeList)
        {
            foreach (IGameObject obj in blockList)
            {
                collisionHandler.DetectMarioBlockCollisions(mario, obj);
            }
            collisionHandler.HandleMarioBlockCollisions();
            foreach (IGameObject obj in enemyList)
            {
                collisionHandler.HandleCollision(mario, obj);
            }
            foreach (IGameObject obj in itemList)
            {
                collisionHandler.HandleCollision(mario, obj);
            }
            foreach (IGameObject obj in pipeList)
            {
                collisionHandler.HandleCollision(mario, obj);
            }
        }

        private static void HandleEnemyCollisions(ICollisionHandler collisionHandler, Collection<IGameObject> blockList, Collection<IGameObject> enemyList, Collection<IGameObject> pipeList)
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                foreach (IGameObject obj in blockList)
                {
                    collisionHandler.HandleCollision(enemyList[i], obj);
                }
                for (int j = i + 1; j < enemyList.Count; j++)
                {
                    collisionHandler.HandleCollision(enemyList[i], enemyList[j]);
                }
                foreach (IGameObject obj in pipeList)
                {
                    collisionHandler.HandleCollision(enemyList[i], obj);
                }
            }
        }

        private static void HandleItemCollisions(ICollisionHandler collisionHandler, Collection<IGameObject> blockList, Collection<IGameObject> itemList, Collection<IGameObject> pipeList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                foreach (IGameObject obj in blockList)
                {
                    collisionHandler.HandleCollision(itemList[i], obj);
                }
                foreach (IGameObject obj in pipeList)
                {
                    collisionHandler.HandleCollision(itemList[i], obj);
                }
            }
        }

        private static void HandleFireBallCollisions(ICollisionHandler collisionHandler, Collection<IGameObject> blockList, Collection<IGameObject> enemyList, Collection<IGameObject> pipeList, IMario mario, Collection<IGameObject> fireBallList)
        {
            for (int i = 0; i < fireBallList.Count; i++)
            {
                foreach (IGameObject obj in blockList)
                {
                    collisionHandler.HandleCollision(fireBallList[i], obj);
                }
                foreach (IGameObject obj in pipeList)
                {
                    collisionHandler.HandleCollision(fireBallList[i], obj);
                }
                foreach (IGameObject obj in enemyList)
                {
                    collisionHandler.HandleCollision(fireBallList[i], obj);
                }

                if (GameUtilities.Game.State.Type == GameStates.Competitive && GameUtilities.GameObjectManager.MarioPlayer2 != null)
                {
                    collisionHandler.HandleCollision(fireBallList[i], mario);
                }
                    
            }
        }
    }
}
