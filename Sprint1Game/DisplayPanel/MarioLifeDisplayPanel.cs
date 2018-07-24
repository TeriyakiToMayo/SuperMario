using Sprint1Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.SpriteFactories;
using Sprint1Game.Sprites;
using Microsoft.Xna.Framework;
using Sprint1Game.Camera;
using Sprint1Game.Sound;

namespace Sprint1Game.DisplayPanel
{
    public class MarioLifeDisplayPanel : IDisplayPanel
    {
        public bool IsEnable { get; set; }
        ISprite backgroundSprite;
        ISprite marioSprite;
        ITextSprite worldTextSprite;
        ITextSprite multiTextSprite;
        ITextSprite lifeTextSprite;
        private int count = 0;
        private const int maxCount = 100;
        private const int screenHeight = 280;
        private const int firstRowY = screenHeight / 2 - 35;
        private const int secRowY = screenHeight / 2 - 10;

        public MarioLifeDisplayPanel()
        {
            backgroundSprite = BackgroundSpriteFactory.Instance.CreateBlackBackgroundSprite();
            marioSprite = MarioSpriteFactory.Instance.CreateIdleRightSmallMarioSprite();
            worldTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            worldTextSprite.Text = "WORLD 1-1";
            multiTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            multiTextSprite.Text = "*";
            lifeTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            lifeTextSprite.Text = "" + MarioAttributes.MarioLife[GameUtilities.Player1];
            count = maxCount;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (GameUtilities.Game.State.Type == GameStates.LifeDisplay)
            {
                backgroundSprite.Draw(spriteBatch, new Vector2(Camera2D.CameraX, GameUtilities.Origin));

                int worldTextX = Camera2D.CameraX + Camera2D.CenterOfScreen - (worldTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2);
                worldTextSprite.Draw(spriteBatch, new Vector2(worldTextX, firstRowY));

                int multiTextX = Camera2D.CameraX + Camera2D.CenterOfScreen - (multiTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2);
                multiTextSprite.Draw(spriteBatch, new Vector2(multiTextX, secRowY));

                int lifeTextX = Camera2D.CameraX + Camera2D.CenterOfScreen - (lifeTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2) + 20;
                lifeTextSprite.Draw(spriteBatch, new Vector2(lifeTextX, secRowY));

                int marioX = Camera2D.CameraX + Camera2D.CenterOfScreen - (marioSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2) - 20;
                marioSprite.Draw(spriteBatch, new Vector2(marioX, firstRowY));
            }

        }

        public void Update()
        {
            lifeTextSprite.Text = "" + MarioAttributes.MarioLife[GameUtilities.Player1];
            if (GameUtilities.Game.State.Type == GameStates.LifeDisplay)
            {
                count--;
                if (count == 0)
                {
                    Game1 game = (Game1)GameUtilities.Game;
                    game.Reset();
                    GameUtilities.Game.State.Proceed();
                    SoundManager.Instance.PlayOverWorldSong();
                }
            }
        }
    }
}
