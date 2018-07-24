using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.HeadsUp;
using Sprint1Game.Interfaces;
using Sprint1Game.Sound;
using Sprint1Game.StateMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint1Game.GameObjects.GameObjectType;

namespace Sprint1Game.GameObjects.BlockGameObjects
{
    class UndergroundBrickBlock : IBlock
    {
        private IBlockStateMachine state;
        public ObjectType Type { get; } = ObjectType.Block;
        public Vector2 Location { get; set; }
        private Vector2 initialLocation;
        private Vector2 fallingSpeed;
        private Vector2 fallingAcce;
        private Rectangle destinationRect;
        public Rectangle Destination
        {
            get
            {
                if (state.Used)
                    return state.MakeDestinationRectangle(new Vector2(0, 0));
                return destinationRect;
            }
            set
            {
                destinationRect = value;
            }
        }

        public UndergroundBrickBlock(Vector2 location)
        {
            state = new UndergroundBrickBlockStateMachine();
            Location = location;
            initialLocation = location;
            fallingSpeed = new Vector2(0, 0);
            fallingAcce = new Vector2(0, 0.5f);
            destinationRect = state.MakeDestinationRectangle(Location);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch, this.Location);
        }

        public void Trigger()
        {
            state.BeTriggered();
            ScoringSystem.AddPointsForBreakingBlock(this);
            SoundManager.Instance.PlayBrickSmashSound();
        }

        public void Update()
        {
            if (this.Location.Y >= initialLocation.Y)
            {
                this.Location = initialLocation;
                fallingSpeed = new Vector2(0, 0);
            }
            else
            {
                this.Location = new Vector2(this.Location.X, this.Location.Y + fallingSpeed.Y);
                fallingSpeed = new Vector2(0, fallingSpeed.Y + fallingAcce.Y);
            }

            state.Update();
            destinationRect = state.MakeDestinationRectangle(Location);
        }
    }
}
