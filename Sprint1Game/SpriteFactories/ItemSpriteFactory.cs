using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.Sprites.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game
{
    public class ItemSpriteFactory
    {
        public static int ItemSpriteSheetColumns { get; } = 4;
        public static int ItemSpriteSheetRows { get; } = 5;
        public static int FlowerSpriteRow { get; } = 1;
        public static int FlowerSpriteColumn { get; } = 0;
        public static int CoinSpriteRow { get; } = 4;
        public static int CoinSpriteColumn { get; } = 0;
        public static int RedMushroomSpriteRow { get; } = 0;
        public static int RedMushroomSpriteColumn { get; } = 1;
        public static int GreenMushroomSpriteRow { get; } = 0;
        public static int GreenMushroomSpriteColumn { get; } = 0;
        public static int StarSpriteRow { get; } = 3;
        public static int StarSpriteColumn { get; } = 0;
        public static int BlankSpriteColumn { get; } = 3;
        public static int BlankSpriteRow { get; } = 0;
        public static int FlagSpriteSheetColumns { get; } = 1;
        public static int FlagSpriteSheetRows { get; } = 3;
        public static int FlagSpriteSheetColumn { get; } = 0;
        public static int FlagRow { get; } = 0;
        public static int FlagTopRow { get; } = 1;
        public static int FlagPoleRow { get; } = 2;


        private Texture2D itemSpriteSheet;
        private Texture2D flagSpriteSheet;

        private static ItemSpriteFactory instance = new ItemSpriteFactory();

        public static ItemSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ItemSpriteFactory()
        {

        }

        public void LoadAllTextures(ContentManager content)
        {
            itemSpriteSheet = content.Load<Texture2D>("item_sheet");
            flagSpriteSheet = content.Load<Texture2D>("flagpole");
        }

        public ISprite CreateFlowerSprite()
        {
            return new FlowerSprite(itemSpriteSheet);
        }

        public ISprite CreateCoinSprite()
        {
            return new CoinSprite(itemSpriteSheet);
        }

        public ISprite CreateStarSprite()
        {
            return new StarSprite(itemSpriteSheet);
        }

        public ISprite CreateRedMushroomSprite()
        {
            return new RedMushroomSprite(itemSpriteSheet);
        }

        public ISprite CreateGreenMushroomSprite()
        {
            return new GreenMushroomSprite(itemSpriteSheet);
        }

        public ISprite CreatePipeSprite()
        {
            return new PipeSprite(itemSpriteSheet);
        }

        public ISprite CreateDisappearedSprite()
        {
            return new DisappearedSprite(itemSpriteSheet);
        }

        public ISprite CreateFlagPoleSprite()
        {
            return new FlagPoleSprite(flagSpriteSheet);
        }

        public ISprite CreateFlagTopSprite()
        {
            return new FlagTopSprite(flagSpriteSheet);
        }

        public ISprite CreateFlagSprite()
        {
            return new FlagSprite(flagSpriteSheet);
        }
    }
}
