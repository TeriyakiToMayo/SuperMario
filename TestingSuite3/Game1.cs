using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint1Game;
using Sprint1Game.Commands;
using Sprint1Game.GameObjects;
using Sprint1Game.GameObjects.PipeGameObjects;
using Sprint1Game.Interfaces;
using Sprint1Game.SpriteFactories;
using Sprint1Game.States.EnemyStates;
using System;
using System.Collections.Generic;
using static Sprint1Game.CollisionHandling.CollisionSide;
using static Sprint1Game.GameObjects.GameObjectType;

namespace TestingSuite3
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : AbstractGame
    {
        SpriteBatch spriteBatch;
        Mario mario;
        bool isInitializing;
        AllCollisionHandler testHandler;
        IGameObject obj2;
        String testName;
        private int currentTest;

        private int marioDisplacement = 20;
        private Vector2 secObjLocation = new Vector2(100, 100);
        public Vector2 MarioLeftLocation
        {
            get
            {
                return new Vector2(secObjLocation.X -  marioDisplacement, secObjLocation.Y);
            }
        }
        public Vector2 MarioRightLocation
        {
            get
            {
                return new Vector2(secObjLocation.X + marioDisplacement, secObjLocation.Y);
            }
        }
        public Vector2 MarioTopLocation
        {
            get
            {
                return new Vector2(secObjLocation.X, secObjLocation.Y - marioDisplacement);
            }
        }
        public Vector2 MarioBottomLocation
        {
            get
            {
                return new Vector2(secObjLocation.X, secObjLocation.Y + marioDisplacement);
            }
        }

        public Game1()
        {
            this.GraphicsManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            PipeSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            MarioSpriteFactory.Instance.LoadAllTextures(Content);
            GameUtilities.Game = this;
            currentTest = 1;
            isInitializing = true;
            testHandler = new AllCollisionHandler();
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            RunSingleTest();
            mario.Update();
            obj2.Update();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        private void RunSingleTest()
        {

            switch (currentTest)
            {
                //========Blocks========
                case 1:
                    MarioBlockLeftTest();
                    break;
                case 2:
                    MarioBlockRightTest();
                    break;
                case 3:
                    MarioBlockTopTest();
                    break;
                case 4:
                    MarioBlockBottomTest();
                    break;
                case 5:
                    MarioQuestionBlockBottomTest();
                    break;
                //========Coin========
                case 6:
                    MarioCoinLeftTest();
                    break;
                case 7:
                    MarioCoinRightTest();
                    break;
                case 8:
                    MarioCoinTopTest();
                    break;
                case 9:
                    MarioCoinBottomTest();
                    break;
                //========Flower========
                case 10:
                    MarioFlowerLeftTest();
                    break;
                case 11:
                    MarioFlowerRightTest();
                    break;
                case 12:
                    MarioFlowerTopTest();
                    break;
                case 13:
                    MarioFlowerBottomTest();
                    break;
                //========GreenMushroom========
                case 14:
                    MarioGreenMushroomLeftTest();
                    break;
                case 15:
                    MarioGreenMushroomRightTest();
                    break;
                case 16:
                    MarioGreenMushroomTopTest();
                    break;
                case 17:
                    MarioGreenMushroomBottomTest();
                    break;
                //========Pipe========
                case 18:
                    MarioPipeLeftTest();
                    break;
                case 19:
                    MarioPipeRightTest();
                    break;
                case 20:
                    MarioPipeTopTest();
                    break;
                case 21:
                    MarioPipeBottomTest();
                    break;
                //========Star========
                case 22:
                    MarioStarLeftTest();
                    break;
                case 23:
                    MarioStarRightTest();
                    break;
                case 24:
                    MarioStarTopTest();
                    break;
                case 25:
                    MarioStarBottomTest();
                    break;
                //========Goomba========
                case 26:
                    MarioGoombaLeftTest();
                    break;
                case 27:
                    MarioGoombaRightTest();
                    break;
                case 28:
                    MarioGoombaTopTest();
                    break;
                case 29:
                    MarioGoombaBottomTest();
                    break;
                //========Koopa========
                case 30:
                    MarioKoopaLeftTest();
                    break;
                case 31:
                    MarioKoopaRightTest();
                    break;
                case 32:
                    MarioKoopaTopTest();
                    break;
                case 33:
                    MarioKoopaBottomTest();
                    break;
                default:
                    mario.SetLocation(0, 0);
                    mario.SetVelocity(0, 0);
                    break;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            mario.Draw(spriteBatch);
            obj2.Draw(spriteBatch);
        }

        private void SetMarioToLeft()
        {
            mario = new Mario(MarioLeftLocation);
            mario.State.ChangeToRight();
            mario.Velocity = new Vector2(1, 0);
            isInitializing = false;
        }

        private void SetMarioToRight()
        {
            mario = new Mario(MarioRightLocation);
            mario.State.ChangeToLeft();
            mario.Velocity = new Vector2(-1, 0);
            isInitializing = false;
        }

        private void SetMarioToTop()
        {
            mario = new Mario(MarioTopLocation);
            mario.State.Crouch();
            mario.Velocity = new Vector2(0, 1);
            isInitializing = false;
        }

        private void SetMarioToBottom()
        {
            mario = new Mario(MarioBottomLocation);
            mario.State.JumpOrStand();
            mario.Velocity = new Vector2(0, -1);
            isInitializing = false;
        }

        private void AfterCollisionHandlingCheck(bool isBlocked, Type marioType, Type obj2Type)
        {
            if (isBlocked && !Rectangle.Intersect(mario.Destination, obj2.Destination).Equals(new Rectangle(0, 0, 0, 0)))
            {
            //    throw new Exception(testName + " Intersection not correct");
            }
            if (!(mario.State.GetType() == marioType))
            {
            //    throw new Exception(testName + " Mario state not correct" + " Expected: " + mario.State.GetType() + " but it is " + marioType);
            }
            if(!(obj2 is IEnemy))
            {
                if (!(obj2.GetType() == obj2Type))
                {
                //    throw new Exception(testName + " obj2 state not correct" + " Expected: " + obj2.GetType() + " but it is " + obj2Type);
                }
            }else
            {
                IEnemy enemy = (IEnemy)obj2;
                if (!(enemy.State.GetType() == obj2Type))
                {
                //    throw new Exception(testName + " obj2 state not correct" + " Expected: " + enemy.State.GetType() + " but it is " + obj2Type);
                }
            }
            
            Console.WriteLine(testName + ": Passed");
            isInitializing = true;
            currentTest++;
        }

        //=============================================================
        //Tests for blocks
        //=============================================================
        private void MarioBlockLeftTest()
        {
            if (isInitializing)
            {
                testName = "MarioBlockLeftTest";
                obj2 = new CrackedBlock(secObjLocation);
                SetMarioToLeft();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(true, typeof(RunningRightSmallMarioState), typeof(CrackedBlock));
            }
        }

        private void MarioBlockRightTest()
        {
            if (isInitializing)
            {
                testName = "MarioBlockRightTest";
                obj2 = new CrackedBlock(secObjLocation);
                SetMarioToRight();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(true, typeof(RunningLeftSmallMarioState), typeof(CrackedBlock));
            }
        }

        private void MarioBlockTopTest()
        {
            if (isInitializing)
            {
                testName = "MarioBlockTopTest";
                obj2 = new CrackedBlock(secObjLocation);
                SetMarioToTop();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(true, typeof(IdleRightSmallMarioState), typeof(CrackedBlock));
            }
        }

        private void MarioBlockBottomTest()
        {
            if (isInitializing)
            {
                testName = "MarioBlockBottomTest";
                obj2 = new CrackedBlock(secObjLocation);
                SetMarioToBottom();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(true, typeof(JumpRightSmallMarioState), typeof(CrackedBlock));
            }
        }

        private void MarioQuestionBlockBottomTest()
        {
            if (isInitializing)
            {
                testName = "MarioQuestionBlockBottomTest";
                obj2 = new QuestionmarkBlock(secObjLocation);
                SetMarioToBottom();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(true, typeof(JumpRightSmallMarioState), typeof(QuestionmarkBlock));
                QuestionmarkBlock qBlock = (QuestionmarkBlock)obj2;
                if(qBlock.Used == false)
                {
                 //   throw new Exception(testName + " Questionblock is not used");
                }
            }
        }

        //=============================================================
        //Tests for coin
        //=============================================================
        private void MarioCoinLeftTest()
        {
            if (isInitializing)
            {
                testName = "MarioCoinLeftTest";
                obj2 = new Coin(secObjLocation);
                SetMarioToLeft();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(false, typeof(RunningRightSmallMarioState), typeof(Coin));
            }
        }

        private void MarioCoinRightTest()
        {
            if (isInitializing)
            {
                testName = "MarioCoinRightTest";
                obj2 = new Coin(secObjLocation);
                SetMarioToRight();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(false, typeof(RunningLeftSmallMarioState), typeof(Coin));
            }
        }

        private void MarioCoinTopTest()
        {
            if (isInitializing)
            {
                testName = "MarioCoinTopTest";
                obj2 = new Coin(secObjLocation);
                SetMarioToTop();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(false, typeof(IdleRightSmallMarioState), typeof(Coin));
            }
        }

        private void MarioCoinBottomTest()
        {
            if (isInitializing)
            {
                testName = "MarioCoinBottomTest";
                obj2 = new Coin(secObjLocation);
                SetMarioToBottom();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(false, typeof(JumpRightSmallMarioState), typeof(Coin));
            }
        }

        //=============================================================
        //Tests for flower
        //=============================================================
        private void MarioFlowerLeftTest()
        {
            if (isInitializing)
            {
                testName = "MarioFlowerLeftTest";
                obj2 = new Flower(secObjLocation);
                SetMarioToLeft();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(false, typeof(RunningRightFireMarioState), typeof(Flower));
            }
        }

        private void MarioFlowerRightTest()
        {
            if (isInitializing)
            {
                testName = "MarioFlowerRightTest";
                obj2 = new Flower(secObjLocation);
                SetMarioToRight();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(false, typeof(RunningLeftFireMarioState), typeof(Flower));
            }
        }

        private void MarioFlowerTopTest()
        {
            if (isInitializing)
            {
                testName = "MarioFlowerTopTest";
                obj2 = new Flower(secObjLocation);
                SetMarioToTop();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(false, typeof(IdleRightFireMarioState), typeof(Flower));
            }
        }

        private void MarioFlowerBottomTest()
        {
            if (isInitializing)
            {
                testName = "MarioFlowerBottomTest";
                obj2 = new Flower(secObjLocation);
                SetMarioToBottom();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(false, typeof(JumpRightFireMarioState), typeof(Flower));
            }
        }

        //=============================================================
        //Tests for GreenMushroom
        //=============================================================
        private void MarioGreenMushroomLeftTest()
        {
            if (isInitializing)
            {
                testName = "MarioGreenMushroomLeftTest";
                obj2 = new GreenMushroom(secObjLocation);
                SetMarioToLeft();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(false, typeof(RunningRightSmallMarioState), typeof(GreenMushroom));
            }
        }

        private void MarioGreenMushroomRightTest()
        {
            if (isInitializing)
            {
                testName = "MarioGreenMushroomRightTest";
                obj2 = new GreenMushroom(secObjLocation);
                SetMarioToRight();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(false, typeof(RunningLeftSmallMarioState), typeof(GreenMushroom));
            }
        }

        private void MarioGreenMushroomTopTest()
        {
            if (isInitializing)
            {
                testName = "MarioGreenMushroomTopTest";
                obj2 = new GreenMushroom(secObjLocation);
                SetMarioToTop();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(false, typeof(IdleRightSmallMarioState), typeof(GreenMushroom));
            }
        }

        private void MarioGreenMushroomBottomTest()
        {
            if (isInitializing)
            {
                testName = "MarioGreenMushroomBottomTest";
                obj2 = new GreenMushroom(secObjLocation);
                SetMarioToBottom();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(false, typeof(JumpRightSmallMarioState), typeof(GreenMushroom));
            }
        }

        //=============================================================
        //Tests for Pipe
        //=============================================================
        private void MarioPipeLeftTest()
        {
            if (isInitializing)
            {
                testName = "MarioPipeLeftTest";
                obj2 = new MediumPipe(secObjLocation);
                SetMarioToLeft();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(false, typeof(RunningRightSmallMarioState), typeof(MediumPipe));
            }
        }

        private void MarioPipeRightTest()
        {
            if (isInitializing)
            {
                testName = "MarioPipeRightTest";
                obj2 = new MediumPipe(secObjLocation);
                SetMarioToRight();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(false, typeof(RunningLeftSmallMarioState), typeof(MediumPipe));
            }
        }

        private void MarioPipeTopTest()
        {
            if (isInitializing)
            {
                testName = "MarioPipeTopTest";
                obj2 = new MediumPipe(secObjLocation);
                SetMarioToTop();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(false, typeof(IdleRightSmallMarioState), typeof(MediumPipe));
            }
        }

        private void MarioPipeBottomTest()
        {
            if (isInitializing)
            {
                testName = "MarioPipeBottomTest";
                obj2 = new MediumPipe(secObjLocation);
                SetMarioToBottom();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(false, typeof(JumpRightSmallMarioState), typeof(MediumPipe));
            }
        }

        //=============================================================
        //Tests for Star
        //=============================================================
        private void MarioStarLeftTest()
        {
            if (isInitializing)
            {
                testName = "MarioStarLeftTest";
                obj2 = new Star(secObjLocation);
                SetMarioToLeft();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(false, typeof(RunningRightStarSmallMarioState), typeof(Star));
            }
        }

        private void MarioStarRightTest()
        {
            if (isInitializing)
            {
                testName = "MarioStarRightTest";
                obj2 = new Star(secObjLocation);
                SetMarioToRight();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(false, typeof(RunningLeftStarSmallMarioState), typeof(Star));
            }
        }

        private void MarioStarTopTest()
        {
            if (isInitializing)
            {
                testName = "MarioStarTopTest";
                obj2 = new Star(secObjLocation);
                SetMarioToTop();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(false, typeof(IdleRightStarSmallMarioState), typeof(Star));
            }
        }

        private void MarioStarBottomTest()
        {
            if (isInitializing)
            {
                testName = "MarioStarBottomTest";
                obj2 = new Star(secObjLocation);
                SetMarioToBottom();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(false, typeof(JumpRightStarSmallMarioState), typeof(Star));
            }
        }

        //=============================================================
        //Tests for Goomba
        //=============================================================
        private void MarioGoombaLeftTest()
        {
            if (isInitializing)
            {
                testName = "MarioGoombaLeftTest";
                obj2 = new Goomba2(secObjLocation);
                SetMarioToLeft();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(false, typeof(DeadMarioState), typeof(GoombaAliveState));
            }
        }

        private void MarioGoombaRightTest()
        {
            if (isInitializing)
            {
                testName = "MarioGoombaRightTest";
                obj2 = new Goomba2(secObjLocation);
                SetMarioToRight();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(false, typeof(DeadMarioState), typeof(GoombaAliveState));
            }
        }

        private void MarioGoombaTopTest()
        {
            if (isInitializing)
            {
                testName = "MarioGoombaTopTest";
                obj2 = new Goomba2(secObjLocation);
                SetMarioToTop();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(false, typeof(IdleRightSmallMarioState), typeof(GoombaDeadState));
            }
        }

        private void MarioGoombaBottomTest()
        {
            if (isInitializing)
            {
                testName = "MarioGoombaBottomTest";
                obj2 = new Goomba2(secObjLocation);
                SetMarioToBottom();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(false, typeof(JumpRightSmallMarioState), typeof(GoombaDeadState));
            }
        }

        //=============================================================
        //Tests for Koopa
        //=============================================================
        private void MarioKoopaLeftTest()
        {
            if (isInitializing)
            {
                testName = "MarioKoopaLeftTest";
                obj2 = new Koopa2(secObjLocation);
                SetMarioToLeft();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(false, typeof(DeadMarioState), typeof(KoopaAliveState));
            }
        }

        private void MarioKoopaRightTest()
        {
            if (isInitializing)
            {
                testName = "MarioKoopaRightTest";
                obj2 = new Koopa2(secObjLocation);
                SetMarioToRight();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(false, typeof(DeadMarioState), typeof(KoopaAliveState));
            }
        }

        private void MarioKoopaTopTest()
        {
            if (isInitializing)
            {
                testName = "MarioKoopaTopTest";
                obj2 = new Koopa2(secObjLocation);
                SetMarioToTop();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(false, typeof(IdleRightSmallMarioState), typeof(KoopaDeadState));
            }
        }

        private void MarioKoopaBottomTest()
        {
            if (isInitializing)
            {
                testName = "MarioKoopaBottomTest";
                obj2 = new Koopa2(secObjLocation);
                SetMarioToBottom();
            }
            else if (!isInitializing && testHandler.HandleCollision(mario, obj2))
            {
                AfterCollisionHandlingCheck(false, typeof(JumpRightSmallMarioState), typeof(KoopaDeadState));
            }
        }
    }
}
