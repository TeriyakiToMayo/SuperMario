using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.Camera;
using Sprint1Game.HeadsUp;
using Sprint1Game.Interfaces;
using Sprint1Game.SpriteFactories;
using Sprint1Game.UtilitiesClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.DisplayPanel
{
    public class HeadsUpDisplayPanel : IDisplayPanel
    {
        public bool IsEnable { get; set; } = true;
        ITextSprite marioTitleTextSprite;
        ITextSprite scoreTextSprite;
        ISprite coinSprite;
        ITextSprite coinTextSprite;
        ITextSprite worldTitleTextSprite;
        ITextSprite worldTextSprite;
        ITextSprite timeTitleTextSprite;
        ITextSprite timeTextSprite;
        private const int distanceOfFirstRowText = HUDUtilities.DistanceOfFirstRowText;
        private const int distanceOfSecondRowText = HUDUtilities.DistanceOfSecondRowText;
        private const int scoreLength = HUDUtilities.ScoreLength;
        private const int coinLength = HUDUtilities.CoinLength;
        private const int timeLength = HUDUtilities.TimeLength;

        public HeadsUpDisplayPanel()
        {
            marioTitleTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            marioTitleTextSprite.Text = HUDUtilities.Mario;
            scoreTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            scoreTextSprite.Text = fixText(GameUtilities.EmptyString + ScoringSystem.Player1Score.Score, scoreLength);
            coinSprite = ItemSpriteFactory.Instance.CreateCoinSprite();
            coinTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            coinTextSprite.Text = HUDUtilities.MultiplicationSign + fixText(GameUtilities.EmptyString + CoinSystem.Instance.Coins, coinLength);
            worldTitleTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            worldTitleTextSprite.Text = HUDUtilities.World;
            worldTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            worldTextSprite.Text = HUDUtilities.Level;
            timeTitleTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            timeTitleTextSprite.Text = HUDUtilities.Time;
            timeTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            timeTextSprite.Text = fixText(GameUtilities.EmptyString + MarioAttributes.Time, timeLength);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsCompetitiveMode())
                return;

            int marioTitleTextX = Camera2D.CameraX + (Camera2D.CenterOfScreen * GameUtilities.Two / HUDUtilities.Fifths - (marioTitleTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / GameUtilities.Two));
            marioTitleTextSprite.Draw(spriteBatch, new Vector2(marioTitleTextX, distanceOfFirstRowText));

            int scoreTextX = Camera2D.CameraX + (Camera2D.CenterOfScreen * GameUtilities.Two / HUDUtilities.Fifths - (scoreTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / GameUtilities.Two));
            scoreTextSprite.Draw(spriteBatch, new Vector2(scoreTextX, distanceOfSecondRowText));

            int coinTextX = Camera2D.CameraX + (Camera2D.CenterOfScreen * GameUtilities.Four / HUDUtilities.Fifths - (coinTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / GameUtilities.Two));
            coinTextSprite.Draw(spriteBatch, new Vector2(coinTextX, distanceOfSecondRowText));

            int coinX = coinTextX - coinSprite.MakeDestinationRectangle(Vector2.Zero).Width + GameUtilities.Two;
            int coinY = distanceOfSecondRowText - coinSprite.MakeDestinationRectangle(Vector2.Zero).Height / GameUtilities.Two;
            coinSprite.Draw(spriteBatch, new Vector2(coinX, coinY));

            int worldTitleTextX = Camera2D.CameraX + (Camera2D.CenterOfScreen * GameUtilities.Six / HUDUtilities.Fifths - (worldTitleTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / GameUtilities.Two));
            worldTitleTextSprite.Draw(spriteBatch, new Vector2(worldTitleTextX, distanceOfFirstRowText));

            int worldTextX = Camera2D.CameraX + (Camera2D.CenterOfScreen * GameUtilities.Six / HUDUtilities.Fifths - (worldTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / GameUtilities.Two));
            worldTextSprite.Draw(spriteBatch, new Vector2(worldTextX, distanceOfSecondRowText));

            int timeTitleTextX = Camera2D.CameraX + (Camera2D.CenterOfScreen * GameUtilities.Eight / HUDUtilities.Fifths - (timeTitleTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / GameUtilities.Two));
            timeTitleTextSprite.Draw(spriteBatch, new Vector2(timeTitleTextX, distanceOfFirstRowText));

            int timeTextX = Camera2D.CameraX + (Camera2D.CenterOfScreen * GameUtilities.Eight / HUDUtilities.Fifths - (timeTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / GameUtilities.Two));
            timeTextSprite.Draw(spriteBatch, new Vector2(timeTextX, distanceOfSecondRowText));
        }

        public void Update()
        {
            scoreTextSprite.Text = fixText(GameUtilities.EmptyString + ScoringSystem.Player1Score.Score, scoreLength);
            coinSprite.Update();
            coinTextSprite.Text = HUDUtilities.MultiplicationSign + fixText(GameUtilities.EmptyString + CoinSystem.Instance.Coins, coinLength);
            timeTextSprite.Text = fixText(GameUtilities.EmptyString + MarioAttributes.Time, timeLength);
        }

        private static String fixText(String str, int length)
        {
            while (str.Length < length)
            {
                str = HUDUtilities.Zero + str;
            }

            return str;
        }
        private static bool IsCompetitiveMode()
        {
            return GameUtilities.Game.State.Type == GameStates.CompetitivePreparing ||
                GameUtilities.Game.State.Type == GameStates.Competitive ||
                GameUtilities.Game.State.Type == GameStates.CompetitiveEnding ||
                GameUtilities.Game.State.Type == GameStates.CompetitivePause;
        }
    }
}