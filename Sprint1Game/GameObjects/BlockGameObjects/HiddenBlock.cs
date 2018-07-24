using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.Interfaces;
using Sprint1Game.Sound;
using Sprint1Game.StateMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint1Game.GameObjects.GameObjectType;

namespace Sprint1Game.GameObjects
{
    public class HiddenBlock : IBlock
    {
        private HiddenBlockStateMachine stateMachine;
        public ObjectType Type { get; } = ObjectType.Block;
        public Vector2 Location { get; set; }
        public Rectangle Destination { get; set; }
        public bool Used
        {
            get { return this.stateMachine.Used; }
        }

        public HiddenBlock(Vector2 location)
        {
            stateMachine = new HiddenBlockStateMachine();
            Location = location;
            Destination = stateMachine.MakeDestinationRectangle(Location);
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
            GreenMushroom newObject = new GreenMushroom(new Vector2(Location.X, Location.Y - 2));
            GameUtilities.GameObjectManager.AddItem(newObject);
            SoundManager.Instance.PlayPowerUpAppearsSound();
            stateMachine.BeTriggered();
        }

        public void Update()
        {
            stateMachine.Update();
            Destination = stateMachine.MakeDestinationRectangle(Location);
        }
    }
}
