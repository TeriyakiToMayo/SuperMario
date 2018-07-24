using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.Camera;
using Sprint1Game.HeadsUp;
using Sprint1Game.Interfaces;
using Sprint1Game.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.DisplayPanel
{
    public class CompetitiveHeadsUpDisplayPanel : IDisplayPanel
    {
        public bool IsEnable { get; set; } = true;
        ITextSprite marioTitleTextSprite;
        ITextSprite scoreTextSprite;
        ITextSprite mario2TitleTextSprite;
        ITextSprite score2TextSprite;
        ITextSprite worldTitleTextSprite;
        ITextSprite worldTextSprite;
        ITextSprite timeTitleTextSprite;
        ITextSprite timeTextSprite;
        private const int distance = 10;
        private const int distanceOfSecRowText = 2 * distance;
        private const int scoreLength = 6;
        private const int coinLength = 2;
        private const int timeLength = 3;

        public CompetitiveHeadsUpDisplayPanel()
        {
            marioTitleTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            marioTitleTextSprite.Text = "PLAYER1";
            scoreTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            scoreTextSprite.Text = fixText("" + ScoringSystem.Player1Score.Score, scoreLength);
            mario2TitleTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            mario2TitleTextSprite.Text = "PLAYER2";
            score2TextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            score2TextSprite.Text = fixText("" + ScoringSystem.Player2Score.Score, scoreLength);
            worldTitleTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            worldTitleTextSprite.Text = "WORLD";
            worldTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            worldTextSprite.Text = "1-1";
            timeTitleTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            timeTitleTextSprite.Text = "TIME";
            timeTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            timeTextSprite.Text = fixText("" + MarioAttributes.Time, timeLength);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (GameUtilities.Game.State.Type == GameStates.Competitive ||
                GameUtilities.Game.State.Type == GameStates.CompetitivePreparing ||
                GameUtilities.Game.State.Type == GameStates.CompetitiveEnding ||
                GameUtilities.Game.State.Type == GameStates.CompetitivePause)
            {

                int marioTitleTextX = Camera2D.CameraX + (Camera2D.CenterOfScreen * 2 / 5 - (marioTitleTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2));
                marioTitleTextSprite.Draw(spriteBatch, new Vector2(marioTitleTextX, distance));

                int scoreTextX = Camera2D.CameraX + (Camera2D.CenterOfScreen * 2 / 5 - (scoreTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2));
                scoreTextSprite.Draw(spriteBatch, new Vector2(scoreTextX, distanceOfSecRowText));

                int mario2TitleTextX = Camera2D.CameraX + (Camera2D.CenterOfScreen * 2 * 2 / 5 - (mario2TitleTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2));
                mario2TitleTextSprite.Draw(spriteBatch, new Vector2(mario2TitleTextX, distance));

                int score2TextX = Camera2D.CameraX + (Camera2D.CenterOfScreen * 2 * 2 / 5 - (score2TextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2));
                score2TextSprite.Draw(spriteBatch, new Vector2(score2TextX, distanceOfSecRowText));

                int worldTitleTextX = Camera2D.CameraX + (Camera2D.CenterOfScreen * 2 * 3 / 5 - (worldTitleTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2));
                worldTitleTextSprite.Draw(spriteBatch, new Vector2(worldTitleTextX, distance));

                int worldTextX = Camera2D.CameraX + (Camera2D.CenterOfScreen * 2 * 3 / 5 - (worldTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2));
                worldTextSprite.Draw(spriteBatch, new Vector2(worldTextX, distanceOfSecRowText));

                int timeTitleTextX = Camera2D.CameraX + (Camera2D.CenterOfScreen * 2 * 4 / 5 - (timeTitleTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2));
                timeTitleTextSprite.Draw(spriteBatch, new Vector2(timeTitleTextX, distance));

                int timeTextX = Camera2D.CameraX + (Camera2D.CenterOfScreen * 2 * 4 / 5 - (timeTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2));
                timeTextSprite.Draw(spriteBatch, new Vector2(timeTextX, distanceOfSecRowText));
            }
        }

        public void Update()
        {
            scoreTextSprite.Text = fixText("" + ScoringSystem.Player1Score.Score, scoreLength);
            score2TextSprite.Text = fixText("" + ScoringSystem.Player2Score.Score, scoreLength);
            timeTextSprite.Text = fixText("" + MarioAttributes.Time, timeLength);
        }

        private static String fixText(String str, int length)
        {
            while (str.Length < length)
            {
                str = "0" + str;
            }

            return str;
        }

    }
}
