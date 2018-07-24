using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.Camera;
using Sprint1Game.Interfaces;
using Sprint1Game.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.DisplayPanel
{
    class TitleDisplayPanel : IDisplayPanel
    {
        public bool IsEnable { get; set; }
        public int OptionNum
        {
            get
            {
                return option;
            }
        }
        ISprite titleImgSprite;
        ITextSprite instructionTextSprite;
        ITextSprite highestScoreTextSprite;
        ITextSprite castTextSprite;
        private const int screenHeight = 280;
        private const int scoreLength = 6;
        private const int titleImgY = 30;
        private const int castY = screenHeight / GameUtilities.Two + 50;
        private const int instructionY = screenHeight / GameUtilities.Two + 20;
        private const int highestScoreY = screenHeight / GameUtilities.Two + 40;
        private const int optionMax = 2;
        private int option = 0;
        private const String adventureText = "Adventure Mode";
        private const String competitive1Text = "Competitive Mode Map 1";
        private const String competitive2Text = "Competitive Mode Map 2";

        public TitleDisplayPanel()
        {
            this.titleImgSprite = BackgroundSpriteFactory.Instance.CreateTitleImgSprite();
            instructionTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            instructionTextSprite.Text = adventureText;
            highestScoreTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            highestScoreTextSprite.Text = "Top Score - " + fixText(GameUtilities.EmptyString + MarioAttributes.HighestScore, scoreLength);
            castTextSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            castTextSprite.Text = "SPRING \'17 3902 TEAM 5 - ALL RIGHTS RESERVED";
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (GameUtilities.Game.State.Type == GameStates.Title)
            {
                int titleImgX = Camera2D.CameraX + Camera2D.CenterOfScreen - (titleImgSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2);
                titleImgSprite.Draw(spriteBatch, new Vector2(titleImgX, titleImgY));

                int castTextX = Camera2D.CameraX + Camera2D.CenterOfScreen - (castTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2);
                castTextSprite.Draw(spriteBatch, new Vector2(castTextX, castY));

                int instructionTextX = Camera2D.CameraX + Camera2D.CenterOfScreen - (instructionTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2);
                instructionTextSprite.Draw(spriteBatch, new Vector2(instructionTextX, instructionY));

                int highestScoreTextX = Camera2D.CameraX + Camera2D.CenterOfScreen - (highestScoreTextSprite.MakeDestinationRectangle(Vector2.Zero).Width / 2);
                highestScoreTextSprite.Draw(spriteBatch, new Vector2(highestScoreTextX, highestScoreY));
            }

        }

        public void Update()
        {
            highestScoreTextSprite.Text = "Top Score - " + fixText(GameUtilities.EmptyString + MarioAttributes.HighestScore, scoreLength);
            switch (option)
            {
                case 0:
                    instructionTextSprite.Text = adventureText;
                    break;
                case 1:
                    instructionTextSprite.Text = competitive1Text;
                    break;
                case 2:
                    instructionTextSprite.Text = competitive2Text;
                    break;
                default:
                    break;
            }
        }

        public void Up()
        {
            if (option == 0)
            {
                option = optionMax;
            }
            else
            {
                option--;
            }
        }

        public void Down()
        {
            if (option == optionMax)
            {
                option = 0;
            }
            else
            {
                option++;
            }
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
