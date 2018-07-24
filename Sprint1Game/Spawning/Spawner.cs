using Sprint1Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint1Game.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.GameObjects.EnemyGameObjects;

namespace Sprint1Game.Spawning
{
    class Spawner : ISpawner
    {
        private ISprite spawnSprite;
        public Rectangle Destination { get; set; }     
        public Vector2 Location { get; set; }
        public GameObjectType.ObjectType Type { get; }
        public bool RightFacing { get; set; }
        private float enemyDistanceBuffer = GameUtilities.EnemyDistanceBuffer;
        private Vector2 bufferVelocity;
        private float bufferDistance;
        private bool hasBeenInView;
        private int verticalOffset = 5;
        private int horizontalOffset = 20;
        private float bufferInitializationDist = 0f;
        private const float bufferDistanceConst = 0f;
//        private bool CanUpdate { get { return hasBeenInView; } }
        public Spawner(Vector2 location, bool rightFacing)
        {
            Type = GameObjectType.ObjectType.Spawner; 
            if(rightFacing)
                spawnSprite = PipeSpriteFactory.Instance.CreateLPipeBottomLeftSprite();
            else
                spawnSprite = PipeSpriteFactory.Instance.CreateLPipeBottomSprite();
            Location = location;
            RightFacing = rightFacing;
            Destination = spawnSprite.MakeDestinationRectangle(Location);
            bufferVelocity = new Vector2(GameUtilities.StationaryVelocity);
            bufferDistance = bufferDistanceConst;
            hasBeenInView = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spawnSprite.Draw(spriteBatch, Location);
        }

        public bool SpawnEnemy(GameObjectType.ObjectType type)
        {
            // if the spawner is not in the game screen dont use it
            if (!hasBeenInView)
                return false;

            // if an enemy hasnt recently been spawned allow one to be spawned     
            else if (bufferVelocity.X == GameUtilities.StationaryVelocity)
            {
                Vector2 spawnLocation;
                if(RightFacing)
                    spawnLocation = new Vector2(Location.X + Destination.Width -horizontalOffset, Location.Y + verticalOffset);//  + Destination.X- 17 * GameUtilities.SinglePixel
                
                else
                    spawnLocation = new Vector2(Location.X, Location.Y + verticalOffset);
                
                IEnemy newEnemy;
                switch (type)
                {
                    case GameObjectType.ObjectType.Goomba:
                        newEnemy = new Goomba2(spawnLocation);
                        break;
                    case GameObjectType.ObjectType.Koopa:
                        newEnemy = new Koopa2(spawnLocation);
                        break;
                    case GameObjectType.ObjectType.Horse:
                        newEnemy = new Horse(spawnLocation);
                        break;
                    default:
                        newEnemy = new Goomba2(spawnLocation);
                        break;
                }

                // makes sure the enemy is moving in the right direction
                if (newEnemy.Velocity.X > GameUtilities.StationaryVelocity && RightFacing == false)
                    newEnemy.ChangeDirection();

                else if (newEnemy.Velocity.X < GameUtilities.StationaryVelocity && RightFacing == true)
                    newEnemy.ChangeDirection();

                bufferVelocity = newEnemy.Velocity;
                GameUtilities.GameObjectManager.AddEnemy(newEnemy);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Update()
        {
            hasBeenInView = true;
            if (bufferVelocity.X != GameUtilities.StationaryVelocity)
            {
                
                bufferDistance += Math.Abs(bufferVelocity.X * GameUtilities.SinglePixel);
                if (bufferDistance > enemyDistanceBuffer)
                {
                    bufferDistance = bufferInitializationDist;
                    bufferVelocity = new Vector2(GameUtilities.StationaryVelocity, GameUtilities.StationaryVelocity);
                }
            }
        }
    }
}
