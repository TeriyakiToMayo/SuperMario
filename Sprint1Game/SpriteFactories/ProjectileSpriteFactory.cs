using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.Sprites.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game.SpriteFactories
{
    class ProjectileSpriteFactory
    {
        private Texture2D fireBallSpriteSheet;

        private static ProjectileSpriteFactory instance = new ProjectileSpriteFactory();

        public static ProjectileSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ProjectileSpriteFactory()
        {

        }
        public void LoadAllTextures(ContentManager content)
        {
            fireBallSpriteSheet = content.Load<Texture2D>("fireSprites2");
        }

        public ISprite CreateFireBallSprite()
        {
            return new FireBallSprite(fireBallSpriteSheet);
        }

        public ISprite CreateFireBallCombustSprite()
        {
            return new FireBallCombustSprite(fireBallSpriteSheet);
        }
    }
}
