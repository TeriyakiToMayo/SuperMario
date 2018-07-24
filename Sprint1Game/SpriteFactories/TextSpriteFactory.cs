using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.Interfaces;
using Sprint1Game.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.SpriteFactories
{
    class TextSpriteFactory
    {
        private SpriteFont normalFont;

        private static TextSpriteFactory instance = new TextSpriteFactory();

        public static TextSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private TextSpriteFactory()
        {

        }

        public void LoadAllTextures(ContentManager content)
        {
            normalFont = content.Load<SpriteFont>("EmuLogic");
        }

        public ITextSprite CreateNormalFontTextSpriteSprite()
        {
            return new TextSprite(normalFont);
        }
    }
}
