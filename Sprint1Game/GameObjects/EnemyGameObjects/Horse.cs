using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.Interfaces;
using Sprint1Game.States.EnemyStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.GameObjects.EnemyGameObjects
{
    class Horse : IEnemy
    {
        public Rectangle Destination { get; set; }
        public Vector2 Location { get; set; }
        public IEnemyState State { get; set; }
        public bool Alive { get; set; } = true;
        public bool Moving { get; set; } = true;
        public GameObjectType.ObjectType Type { get; } = GameObjectType.ObjectType.Horse;
        private Vector2 velocity;
        private Vector2 acceleration;
        public Vector2 Velocity
        {
            get
            {
                return velocity;
            }
            set
            {
                velocity = value;
            }
        }
        private bool hasBeenInView;
        public bool CanUpdate { get { return hasBeenInView; } }

        public Horse(Vector2 location)
        {
            Location = location;
            State = new HorseRightState(this);
            Destination = State.StateSprite.MakeDestinationRectangle(location);
            velocity = new Vector2(.75f, GameUtilities.StationaryVelocity);
            acceleration = new Vector2(GameUtilities.StationaryAcceleration, 0.5f);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch, this.Location);
        }
        public void Update()
        {
            hasBeenInView = true;
            if (velocity.Y < 3)
            {
                velocity.Y += acceleration.Y;
            }
            
            Location = new Vector2(Location.X + velocity.X, Location.Y + velocity.Y);
            
            State.Update();
            Destination = State.StateSprite.MakeDestinationRectangle(Location);
        }
        public void ChangeDirection()
        {
            Velocity = new Vector2(-Velocity.X, Velocity.Y);
            State.ChangeDirection();
        }
        public void Terminate(string direction)
        {
            State.Terminate(direction);
            Moving = false;
            Alive = false;
            GameUtilities.GameObjectManager.SpawnManager.EnemyTerminated();
            Velocity = new Vector2(GameUtilities.StationaryVelocity);
            acceleration = new Vector2(GameUtilities.StationaryAcceleration);
            Location = new Vector2(Location.X - 20, Location.Y - (48 - Destination.Height));
        }
    }
}
