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
    public class CompetitiveEndingDisplayPanel : IDisplayPanel
    {
        public bool IsEnable { get; set; }
        ISprite backgroundSprite;
        ITextSprite gameOverTextSprite;
        private int count = 0;
        private const int maxCount = 200;
        private const int screenHeight = 280;
        private bool setWinner = true;

        public CompetitiveEndingDisplayPanel()
        {
            backgroundSprite = BackgroundSpriteFactory.Instance.CreateBlackBackgroundSprite();
            gameOverTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            gameOverTextSprite.Text = "";
            count = maxCount;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (GameUtilities.Game.State.Type == GameStates.CompetitiveEnding)
            {
                backgroundSprite.Draw(spriteBatch, new Vector2(Camera2D.CameraX, 0));
                int halfOfGameOverTextWidth = gameOverTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2;
                int gameOverTextY = screenHeight / 2 - 30;
                gameOverTextSprite.Draw(spriteBatch, new Vector2(Camera2D.CameraX + Camera2D.CenterOfScreen - halfOfGameOverTextWidth, gameOverTextY));
            }

        }

        public void Update()
        {
            if (GameUtilities.Game.State.Type == GameStates.CompetitiveEnding)
            {
                String winner = "";
                if (setWinner)
                {
                    if (GameUtilities.GameObjectManager.MarioPlayer1.State.MarioShape == MarioState.MarioShapeEnums.Dead &&
                GameUtilities.GameObjectManager.MarioPlayer2.State.MarioShape != MarioState.MarioShapeEnums.Dead)
                    {
                        winner = "PLAYER 2 WINS";
                    }
                    else if (GameUtilities.GameObjectManager.MarioPlayer1.State.MarioShape != MarioState.MarioShapeEnums.Dead &&
                       GameUtilities.GameObjectManager.MarioPlayer2.State.MarioShape == MarioState.MarioShapeEnums.Dead)
                    {
                        winner = "PLAYER 1 WINS";
                    }
                    else
                    {
                        if (ScoringSystem.Player1Score.Score > ScoringSystem.Player2Score.Score)
                        {
                            winner = "PLAYER 1 WINS";
                        }
                        else if (ScoringSystem.Player1Score.Score < ScoringSystem.Player2Score.Score)
                        {
                            winner = "PLAYER 2 WINS";
                        }
                        else
                        {
                            winner = "DRAW";
                        }
                    }
                    gameOverTextSprite.Text = winner;
                    setWinner = false;
                }
                count--;
                if (count == 0)
                {
                    Game1 game = (Game1)GameUtilities.Game;
                    game.Reset();
                    game.State.Proceed();
                    MarioAttributes.MarioLife[GameUtilities.Player1] = GameUtilities.MarioInitalLife;
                    CoinSystem.Instance.ResetCoin();
                    ScoringSystem.Player1Score.ResetScore();
                    ScoringSystem.Player2Score.ResetScore();
                    MarioAttributes.ClearTimer();
                }
            }
        }
    }
}
