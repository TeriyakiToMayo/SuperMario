using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.Interfaces;
using Sprint1Game.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.DisplayPanel
{
    public class PlayerNameDisplayPanel : IDisplayPanel
    {
        public bool IsEnable { get; set; }
        public Vector2 Location { get; set; }

        public ITextSprite PlayerName {
            get
            {
                return playerNameTextSprite;
            }
        }

        ITextSprite playerNameTextSprite;

        public PlayerNameDisplayPanel()
        {
            playerNameTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            playerNameTextSprite.Text = "";
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (GameUtilities.Game.State.Type == GameStates.Competitive ||
                GameUtilities.Game.State.Type == GameStates.CompetitivePause)
            {
                playerNameTextSprite.Draw(spriteBatch, Location);
            }

        }

        public void Update()
        {
        }
    }
}
