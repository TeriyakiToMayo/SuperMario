using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.Sprites;
using Sprint1Game.Sprites.Block;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Game
{
    public class BlockSpriteFactory
    {
        public static int BlockSpriteSize { get; set; } = 2;
        public static int StageOneSpriteColumns { get; } = 3;
        public static int StageOneSpriteRows  { get; } = 8;
        public static int StageOneSpriteBrickBlock1Row { get; } = 0;
        public static int StageOneSpriteBrickBlock1Column { get; } = 0;
        public static int StageOneSpriteUsedBlock1Row { get; } = 1;
        public static int StageOneSpriteUsedBlock1Column { get; } = 0;
        public static int StageOneSpriteCrackedBlock1Row { get; } = 4;
        public static int StageOneSpriteCrackedBlock1Column { get; } = 0;
        public static int StageOneSpriteStoneBlock1Row { get; } = 5;
        public static int StageOneSpriteStoneBlock1Column { get; } = 0;
        public static int StageOneSpriteQuestionmark1BlockRow { get; } = 6;

        private Texture2D stageOneSpriteSheet;
        private Texture2D smallBrickSheet;

        private static BlockSpriteFactory instance = new BlockSpriteFactory();

        public static BlockSpriteFactory Instance
        {
            get { return instance; }
        }

        private BlockSpriteFactory()
        {

        }

        public void LoadAllTextures(ContentManager content)
        {
            stageOneSpriteSheet = content.Load<Texture2D>("block_sheet");
            smallBrickSheet = content.Load<Texture2D>("smallbrick");
        }

        public ISprite CreateQuestionmarkBlockSprite()
        {
            return new QuestionmarkBlockSprite(stageOneSpriteSheet);
        }

        public ISprite CreateUsedBlockSprite()
        {
            return new UsedBlockSprite(stageOneSpriteSheet);
        }

        public ISprite CreateBrickBlockSprite()
        {
            return new BrickBlockSprite(stageOneSpriteSheet);
        }

        public ISprite CreateSmallBrickBlockSprite()
        {
            return new SmallBrickSprite(smallBrickSheet);
        }
        public ISprite CreateSmallUndergroundBrickBlockSprite()
        {
            return new SmallBrickSprite(smallBrickSheet, true);
        }

        public ISprite CreateCrackedBlockSprite()
        {
            return new CrackedBlockSprite(stageOneSpriteSheet);
        }

        public ISprite CreateStoneBlockSprite()
        {
            return new StoneBlockSprite(stageOneSpriteSheet);
        }

        public ISprite CreateHiddenBlockSprite()
        {
            return new HiddenBlockSprite(stageOneSpriteSheet);
        }

        public ISprite CreateDisappearedBlockSprite()
        {
            return new DisappearedSprite(stageOneSpriteSheet);
        }
        public ISprite CreateUndergroundCrackedBlockSprite()
        {
            return new UndergroundCrackedBlockSprite(stageOneSpriteSheet);
        }
        public ISprite CreateUndergroundBrickBlockSprite()
        {
            return new UndergroundBrickBlockSprite(stageOneSpriteSheet);
        }
    }
}
