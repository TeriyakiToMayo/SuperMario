using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.Camera;
using Sprint1Game.Interfaces;
using Sprint1Game.Sound;
using Sprint1Game.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.DisplayPanel
{
    public class CompetitivePreparingDisplayPanel : IDisplayPanel
    {
        public bool IsEnable { get; set; }
        private bool isMapNumNotAssigned = true;
        ISprite backgroundSprite;
        ISprite marioSprite;
        ISprite mario2Sprite;
        ITextSprite worldTextSprite;
        ITextSprite multiTextSprite;
        private int count = 0;
        private const int maxCount = 200;
        private const int screenHeight = 280;
        private const int firstRowY = screenHeight / 2 - 35;
        private const int secRowY = screenHeight / 2 - 10;
        private int mapNum = 0;

        public CompetitivePreparingDisplayPanel()
        {
            backgroundSprite = BackgroundSpriteFactory.Instance.CreateBlackBackgroundSprite();
            marioSprite = MarioSpriteFactory.Instance.CreateIdleRightSmallMarioSprite();
            mario2Sprite = MarioSpriteFactory.Instance.CreateIdleLeftSmallMarioSprite();
            worldTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            multiTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            multiTextSprite.Text = "READY";
            count = maxCount;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (GameUtilities.Game.State.Type == GameStates.CompetitivePreparing)
            {
                backgroundSprite.Draw(spriteBatch, new Vector2(Camera2D.CameraX, GameUtilities.Origin));

                int worldTextX = Camera2D.CameraX + Camera2D.CenterOfScreen - (worldTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2);
                worldTextSprite.Draw(spriteBatch, new Vector2(worldTextX, firstRowY));

                int multiTextX = Camera2D.CameraX + Camera2D.CenterOfScreen - (multiTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2);
                multiTextSprite.Draw(spriteBatch, new Vector2(multiTextX, secRowY));

                int marioX = Camera2D.CameraX + Camera2D.CenterOfScreen - marioSprite.MakeDestinationRectangle(Vector2.Zero).Width * 3;
                marioSprite.Draw(spriteBatch, new Vector2(marioX, firstRowY));

                int mario2X = Camera2D.CameraX + Camera2D.CenterOfScreen + mario2Sprite.MakeDestinationRectangle(Vector2.Zero).Width * 2;
                mario2Sprite.Draw(spriteBatch, new Vector2(mario2X, firstRowY));
            }

        }

        public void Update()
        {
            if (GameUtilities.Game.State.Type == GameStates.CompetitivePreparing)
            {
                if (isMapNumNotAssigned)
                {
                    TitleDisplayPanel titlePanel = (TitleDisplayPanel)GameUtilities.GameObjectManager.TitlePanel;
                    worldTextSprite.Text = "COMPETITIVE MODE MAP " + titlePanel.OptionNum;
                    mapNum = titlePanel.OptionNum;
                    isMapNumNotAssigned = false;
                }
                
                count--;
                multiTextSprite.Text = "" + (count / 50);
                if (count == 0)
                {
                    GameUtilities.Game.State.Proceed();
                    if(mapNum == 1)
                    {
                        SoundManager.Instance.PlayUnderworldSong();
                    }
                    if(mapNum == 2)
                    {
                        SoundManager.Instance.PlayOverWorldSong();
                    }
                    
                }
            }
        }
    }
}
