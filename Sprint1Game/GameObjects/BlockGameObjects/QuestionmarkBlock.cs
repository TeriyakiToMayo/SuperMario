using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Sprint1Game.GameObjects.GameObjectType;
using Sprint1Game.StateMachines;
using Sprint1Game.Interfaces;
using Sprint1Game.HeadsUp;
using Sprint1Game.Animation;
using Sprint1Game.Sound;

namespace Sprint1Game
{
    public class QuestionmarkBlock : IBlock
    {
        private QuestionmarkBlockStateMachine stateMachine;
        private IAnimationInGame coinAnimation;
        public ObjectType Type { get; } = ObjectType.Block;
        public Vector2 Location { get; set; }
        public Rectangle Destination { get; set; }
        public bool Used { get { return this.stateMachine.Used; } }

        public enum QuestionmarkBlockTypeEnums { Flower, GreenMushroom, RedMushroom, Star, Coin}
        public QuestionmarkBlockTypeEnums QuestionmarkBlockType { set; get; } = QuestionmarkBlockTypeEnums.Coin;

        public QuestionmarkBlock(Vector2 location)
        {
            stateMachine = new QuestionmarkBlockStateMachine();
            Location = location;
            Destination = stateMachine.MakeDestinationRectangle(Location);
            coinAnimation = new CoinCollectedFromBlockAnimation(new Vector2(Location.X, Location.Y - Destination.Height));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            stateMachine.Draw(spriteBatch, this.Location);
        }

        public void Trigger()
        {
            if (Used)
            {
                return;
            }
            IGameObject newObject = null;
            switch (QuestionmarkBlockType)
            {
                case QuestionmarkBlockTypeEnums.Flower:
                    newObject = new Flower(new Vector2(Location.X, Location.Y - 2));
                    SoundManager.Instance.PlayPowerUpAppearsSound();
                    break;
                case QuestionmarkBlockTypeEnums.GreenMushroom:
                    newObject = new GreenMushroom(new Vector2(Location.X, Location.Y - 2));
                    SoundManager.Instance.PlayPowerUpAppearsSound();
                    break;
                case QuestionmarkBlockTypeEnums.RedMushroom:
                    newObject = new RedMushroom(new Vector2(Location.X, Location.Y - 2));
                    SoundManager.Instance.PlayPowerUpAppearsSound();
                    break;
                case QuestionmarkBlockTypeEnums.Star:
                    newObject = new Star(new Vector2(Location.X, Location.Y - 2));
                    SoundManager.Instance.PlayPowerUpAppearsSound();
                    break;
                default:
                    coinAnimation.StartAnimation();
                    CoinSystem.Instance.AddCoin();
                    ScoringSystem.AddPointsForCoin(this);
                    break;
            }
            if (newObject != null)
            {
                
                newObject.Location = new Vector2(Location.X, Location.Y - 2);
                GameUtilities.GameObjectManager.AddItem(newObject);
            }
            
            stateMachine.BeTriggered();
        }

        public void Update()
        {
            Destination = stateMachine.MakeDestinationRectangle(Location);
            stateMachine.Update();
        }
    }
}
