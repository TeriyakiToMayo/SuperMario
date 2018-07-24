using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.Sprites;
using Sprint1Game.Sprites.Goomba;
using Sprint1Game.Sprites.Koopa;
using Sprint1Game.Sprites.Horse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Sprint1Game.SpriteFactories
{
    public class EnemySpriteFactory
    {
        public int GoombaSpriteSheetColumn { get; } = 3;
        public int GoombaSpriteSheetRows { get; } = 1;
        public int GoombaWalkTotalFrame { get; } = 2;
        public int GoombaWidth {
            get
            {
                return enemyGoombaSpriteSheet.Width / GoombaSpriteSheetColumn;
            }
        }

        public int GoombaHeight
        {
            get
            {
                return enemyGoombaSpriteSheet.Height / GoombaSpriteSheetRows;
            }
        }

        public Vector2 GoombaWalkCord { get; } = new Vector2(GameUtilities.Origin, GameUtilities.Origin);
        public Vector2 GoombaDeadCord { get; } = new Vector2(2, GameUtilities.Origin);

        public int KoopaSpriteSheetColumn { get; } = 5;
        public int KoopaSpriteSheetRows { get; } = 1;
        public int KoopaWalkTotalFrame { get; } = 2;
        public int KoopaWidth
        {
            get
            {
                return enemyKoopaSpriteSheet.Width / KoopaSpriteSheetColumn;
            }
        }

        public int KoopaHeight
        {
            get
            {
                return enemyKoopaSpriteSheet.Height / KoopaSpriteSheetRows;
            }
        }

        public Vector2 KoopaWalkCord { get; } = new Vector2(GameUtilities.Origin, GameUtilities.Origin);
        public Vector2 KoopaDeadCord { get; } = new Vector2(2, GameUtilities.Origin);
        public Vector2 KoopaSideDeadCord { get; } = new Vector2(4, GameUtilities.Origin);

        
        
        private int[] horseXR { get; } = { 3, 27, 52, 77, 102, 2, 27, 51, 77, 101, 1, 26, 53, 78, 103 };
        public int[] HorseXR()
        {
            return horseXR;
        }
        private int[] horseYR { get; } = { 2, 2 ,2 ,2 ,2 , 18, 18, 18, 17, 17, 33, 33, 33, 33, 33};
        public int[] HorseYR()
        {
            return horseYR;
        }
        private int[] horseWidthR { get; } = { 19, 20, 20, 20, 19, 20, 20, 20, 21, 22, 23, 22, 21, 20, 20};
        public int[] HorseWidthR()
        {
            return horseWidthR;
        }
        private int[] horseHeightR { get; } = { 15, 15, 15, 15, 15, 15 ,15 ,15, 15, 15, 14, 14, 14, 14, 14};
        public int[] HorseHeightR()
        {
            return horseHeightR;
        }
        private int[] horseXL { get; } = { 4, 28, 53, 78, 103, 2, 27, 54, 78, 103, 2, 27, 51, 77, 101 };
        public int[] HorseXL()
        {
            return horseXL;
        }
        private int[] horseYL { get; } = { 2, 2, 2, 2, 2, 17, 17, 17, 17, 17, 33, 33, 33, 33, 33 };
        public int[] HorseYL()
        {
            return horseYL;
        }
        private int[] horseWidthL { get; } = { 19, 20, 20, 20, 19, 20, 20, 20, 21, 22, 23, 22, 21, 20, 20 };
        public int[] HorseWidthL()
        {
            return horseWidthL;
        }
        private int[] horseHeightL { get; } = { 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 14, 14, 14, 14, 14 };
        public int[] HorseHeightL()
        {
            return horseHeightL;
        }
        public int HorseTotalFrames { get; } = 15;

        public int DeadHorseWidth { get; } = 50;
        public int DeadHorseHeight { get; } = 47;
        public int DeadHorseTotalFrames { get; } = 24;


        private Texture2D enemyGoombaSpriteSheet;
        private Texture2D enemyKoopaSpriteSheet;
        private Texture2D enemyGoombaSpriteSheetFlipped;
        private Texture2D enemyKoopaRightSpriteSheet;
        private Texture2D horseSpriteSheetR;
        private Texture2D horseSpriteSheetL;
        private Texture2D horseExplosion;
        private static EnemySpriteFactory instance = new EnemySpriteFactory();

        public static EnemySpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private EnemySpriteFactory()
        {

        }

        public void LoadAllTextures(ContentManager content)
        {
            enemyGoombaSpriteSheet = content.Load<Texture2D>("goomba_sheet");
            enemyKoopaSpriteSheet = content.Load<Texture2D>("turtle_sheet_3");
            enemyKoopaRightSpriteSheet = content.Load<Texture2D>("turtle_sheet2");
            enemyGoombaSpriteSheetFlipped = content.Load<Texture2D>("goomba_sheet_F");
            horseSpriteSheetR = content.Load<Texture2D>("HorseSpriteSheetWhiteR");
            horseSpriteSheetL = content.Load<Texture2D>("HorseSpriteSheetWhiteL");
            horseExplosion = content.Load<Texture2D>("explosion");
        }

        public ISprite CreateGoombaSprite()
        {
            return new GoombaSprite(enemyGoombaSpriteSheet);
        }

        public ISprite CreateKoopaSprite()
        {
            return new KoopaSprite(enemyKoopaSpriteSheet);
        }

        public ISprite CreateKoopaRightSprite()
        {
            return new KoopaSprite(enemyKoopaRightSpriteSheet);
        }

        public ISprite CreateDeadGoombaSprite()
        {
            return new DeadGoombaSprite(enemyGoombaSpriteSheet);
        }

        public ISprite CreateGoombaSideDeathSprite()
        {
            return new GoombaSideDeathSprite(enemyGoombaSpriteSheetFlipped);
        }

        public ISprite CreateDeadKoopaSprite()
        {
            return new DeadKoopaSprite(enemyKoopaSpriteSheet);
        }

        public ISprite CreateKoopaSideDeathSprite()
        {
            return new KoopaSideDeathSprite(enemyKoopaSpriteSheet);
        }

        public ISprite CreateHorseRightSprite()
        {
            return new HorseRightSprite(horseSpriteSheetR);
        }
        public ISprite CreateHorseLeftSprite()
        {
            return new HorseLeftSprite(horseSpriteSheetL);
        }
        public ISprite CreateDeadHorseSprite()
        {
            return new HorseDeadSprite(horseExplosion);
        }
    }
}
