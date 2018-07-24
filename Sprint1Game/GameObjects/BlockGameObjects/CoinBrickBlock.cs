using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.Animation;
using Sprint1Game.HeadsUp;
using Sprint1Game.Interfaces;
using Sprint1Game.StateMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint1Game.GameObjects.GameObjectType;

namespace Sprint1Game.GameObjects.BlockGameObjects
{
    class CoinBrickBlock : IBlock
    {
        private IBlockStateMachine state;
        public GameObjectType.ObjectType Type { get; } = ObjectType.Block;
        private int coinNum = 5;
        private IAnimationInGame[] coinAnimation;
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
                    return state.MakeDestinationRectangle(Location);
                return destinationRect;
            }
            set
            {
                destinationRect = value;
            }
        }

        public CoinBrickBlock(Vector2 location)
        {
            state = new CoinBrickBlockStateMachine();
            Location = location;
            initialLocation = location;
            fallingSpeed = new Vector2(GameUtilities.StationaryVelocity, GameUtilities.StationaryVelocity);
            fallingAcce = new Vector2(GameUtilities.StationaryAcceleration, GameUtilities.BrickBlockFallingSpeed);
            destinationRect = state.MakeDestinationRectangle(Location);
            coinAnimation = new CoinCollectedFromBlockAnimation[coinNum];
            for (int i = 0; i < coinNum; i++)
                coinAnimation[i] = new CoinCollectedFromBlockAnimation(new Vector2(Location.X, Location.Y - Destination.Height));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch, this.Location);
        }

        public void Trigger()
        {
            if (coinNum > 0)
            {
                Location = new Vector2(Location.X, initialLocation.Y - 5);
                coinNum--;
                coinAnimation[coinNum].StartAnimation();
                CoinSystem.Instance.AddCoin();
                ScoringSystem.AddPointsForCoin(this);
            }
            else
            {
                state.BeTriggered();
            }
        }

        public void Update()
        {
            if (Location.Y >= initialLocation.Y)
            {
                Location = initialLocation;
                fallingSpeed = new Vector2(GameUtilities.StationaryVelocity, GameUtilities.StationaryVelocity);
            }
            else
            {
                Location = new Vector2(Location.X, Location.Y + fallingSpeed.Y);
                fallingSpeed = new Vector2(GameUtilities.StationaryVelocity, fallingSpeed.Y + fallingAcce.Y);
            }

            state.Update();
            destinationRect = state.MakeDestinationRectangle(Location);
        }
    }
}
