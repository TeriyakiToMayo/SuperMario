using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.GameObjects;
using Sprint1Game.GameObjects.BackgroundGameObjects;
using Sprint1Game.GameObjects.BlockGameObjects;
using Sprint1Game.GameObjects.ItemGameObjects;
using Sprint1Game.GameObjects.PipeGameObjects;
using Sprint1Game.GameObjects.EnemyGameObjects;
using Sprint1Game.HeadsUp;
using Sprint1Game.Spawning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint1Game.GameObjects.GameObjectType;


namespace Sprint1Game.LevelSpecification
{
    public class CSVWriter
    {
        private TheGameObjectManager allObjectsManager;
        public CSVWriter(TheGameObjectManager objectManager)
        {
            allObjectsManager = objectManager;
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("This part cannot be simplified", "CA1502:AvoidExcessiveComplexity")]
        public void writeObject(int x, int y, string s)
        {
            switch (s)
            {
                case "__":
                    break;
                case "bl":
                    allObjectsManager.AddBackgroundItem(new BlackBackground(new Vector2(x, y)));
                    break;
                case "bh":
                    allObjectsManager.AddBackgroundItem(new BigHill(new Vector2(x, y)));
                    break;
                case "sh":
                    allObjectsManager.AddBackgroundItem(new SmallHill(new Vector2(x, y)));
                    break;
                case "bb":
                    allObjectsManager.AddBackgroundItem(new BigBush(new Vector2(x, y)));
                    break;
                case "mb":
                    allObjectsManager.AddBackgroundItem(new MediumBush(new Vector2(x, y)));
                    break;
                case "sb":
                    allObjectsManager.AddBackgroundItem(new SmallBush(new Vector2(x, y)));
                    break;
                case "bc":
                    allObjectsManager.AddBackgroundItem(new BigCloud(new Vector2(x, y)));
                    break;
                case "mc":
                    allObjectsManager.AddBackgroundItem(new MediumCloud(new Vector2(x, y)));
                    break;
                case "sc":
                    allObjectsManager.AddBackgroundItem(new SmallCloud(new Vector2(x, y)));
                    break;
                case "ca":
                    allObjectsManager.AddBackgroundItem(new Castle(new Vector2(x, y)));
                    break;
                case "fb":
                    allObjectsManager.AddBlock(new CrackedBlock(new Vector2(x, y)));
                    break;
                case "qb":
                    allObjectsManager.AddBlock(new QuestionmarkBlock(new Vector2(x, y)));
                    break;
                case "qbr":
                    QuestionmarkBlock redMushroomBlock = new QuestionmarkBlock(new Vector2(x, y));
                    redMushroomBlock.QuestionmarkBlockType = QuestionmarkBlock.QuestionmarkBlockTypeEnums.RedMushroom;
                    allObjectsManager.AddBlock(redMushroomBlock);
                    break;
                case "qbg":
                    QuestionmarkBlock greenMushroomBlock = new QuestionmarkBlock(new Vector2(x, y));
                    greenMushroomBlock.QuestionmarkBlockType = QuestionmarkBlock.QuestionmarkBlockTypeEnums.GreenMushroom;
                    allObjectsManager.AddBlock(greenMushroomBlock);
                    break;
                case "qbf":
                    QuestionmarkBlock flowerBlock = new QuestionmarkBlock(new Vector2(x, y));
                    flowerBlock.QuestionmarkBlockType = QuestionmarkBlock.QuestionmarkBlockTypeEnums.Flower;
                    allObjectsManager.AddBlock(flowerBlock);
                    break;
                case "qbs":
                    QuestionmarkBlock starBlock = new QuestionmarkBlock(new Vector2(x, y));
                    starBlock.QuestionmarkBlockType = QuestionmarkBlock.QuestionmarkBlockTypeEnums.Star;
                    allObjectsManager.AddBlock(starBlock);
                    break;
                case "qb?":
                    Random ran = new Random();
                    int random = ran.Next(0, 30);
                    switch (random/10)
                    {
                        case 1:
                            QuestionmarkBlock redMushroomBlock2 = new QuestionmarkBlock(new Vector2(x, y));
                            redMushroomBlock2.QuestionmarkBlockType = QuestionmarkBlock.QuestionmarkBlockTypeEnums.RedMushroom;
                            allObjectsManager.AddBlock(redMushroomBlock2);
                            break;
                        default:
                            allObjectsManager.AddBlock(new QuestionmarkBlock(new Vector2(x, y)));
                            break;
                    }
                    break;
                case "rb":
                    allObjectsManager.AddBlock(new BrickBlock(new Vector2(x, y)));
                    break;
                case "crb":
                    allObjectsManager.AddBlock(new CoinBrickBlock(new Vector2(x, y)));
                    break;
                case "eb":
                    allObjectsManager.AddBlock(new StoneBlock(new Vector2(x, y)));
                    break;
                case "hb":
                    allObjectsManager.AddBlock(new HiddenBlock(new Vector2(x, y)));
                    break;
                case "urb":
                    allObjectsManager.AddBlock(new UndergroundBrickBlock(new Vector2(x, y)));
                    break;
                case "ufb":
                    allObjectsManager.AddBlock(new UndergroundCrackedBlock(new Vector2(x, y)));
                    break;
                case "sp":
                    allObjectsManager.AddPipe(new Pipe(new Vector2(x, y)));
                    break;
                case "mp":
                    allObjectsManager.AddPipe(new MediumPipe(new Vector2(x, y)));
                    break;
                case "bp":
                    allObjectsManager.AddPipe(new BigPipe(new Vector2(x, y)));
                    break;
                case "bpt":
                    allObjectsManager.AddPipe(new BigPipe(new Vector2(x, y), new Vector2(210 * GameUtilities.BlockSize, 0)));
                    break;
                case "lp":
                    allObjectsManager.AddPipe(new LPipe(new Vector2(x, y)));
                    break;
                case "lpb":
                    allObjectsManager.AddPipe(new LPipeBottom(new Vector2(x, y), new Vector2(164 * GameUtilities.BlockSize, 11 * GameUtilities.BlockSize)));
                    break;
                case "lpt":
                    allObjectsManager.AddPipe(new LPipeTop(new Vector2(x, y)));
                    break;
                case "ko":
                    allObjectsManager.AddEnemy(new Koopa2(new Vector2(x, y)));
                    break;
                case "go":
                    allObjectsManager.AddEnemy(new Goomba2(new Vector2(x, y)));
                    break;
                case "hrr":
                    allObjectsManager.AddEnemy(new Horse(new Vector2(x, y)));
                    break;
                case "ff":
                    allObjectsManager.AddItem(new Flower(new Vector2(x, y)));
                    break;
                case "cb":
                    allObjectsManager.AddItem(new Coin(new Vector2(x, y)));
                    break;
                case "rm":
                    allObjectsManager.AddItem(new RedMushroom(new Vector2(x, y)));
                    break;
                case "gm":
                    allObjectsManager.AddItem(new GreenMushroom(new Vector2(x, y)));
                    break;
                case "st":
                    allObjectsManager.AddItem(new Star(new Vector2(x, y)));
                    break;
                case "ma":
                    allObjectsManager.SetMarioPlayer1(new Mario(new Vector2(x, y), GameUtilities.Player1));
                    break;
                case "m2":
                    allObjectsManager.SetMarioPlayer2(new Mario(new Vector2(x, y), GameUtilities.Player2));
                    break;
                case "fg":
                    allObjectsManager.AddItem(new Flag(new Vector2(x, y)));
                    break;
                case "ft":
                    allObjectsManager.AddItem(new FlagTop(new Vector2(x, y)));
                    break;
                case "fp":
                    allObjectsManager.AddItem(ScoringSystem.Player1Score.RegisterPole(new FlagPole(new Vector2(x, y))));
                    break;
                case "lptl":
                    allObjectsManager.AddPipe(new LPipeTopLeft(new Vector2(x, y)));
                    break;
                case "lpbl":
                    allObjectsManager.AddSpawner(new Spawner(new Vector2(x,y), true));
                    allObjectsManager.AddPipe(new LPipeBottomLeft(new Vector2(x, y)));
                    break;
                case "lpbr":
                    allObjectsManager.AddSpawner(new Spawner(new Vector2(x,y), false));
                    allObjectsManager.AddPipe(new LPipeBottom(new Vector2(x, y)));
                    break;          
                default:
                    break;
            }
        }
    }
}
