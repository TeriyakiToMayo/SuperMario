using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint1Game;
using Sprint1Game.Interfaces;
using Sprint1Game.SpriteFactories;
using Sprint1Game.Commands;
using Sprint1Game.CollisionCommands;
using System;
using System.Collections.Generic;
using static Sprint1Game.CollisionHandling.CollisionSide;
using static Sprint1Game.GameObjects.GameObjectType;
using Sprint1Game.GameObjects;
using System.Threading;

namespace TestingSuite2
{
    public class GameTest : AbstractGame
    {
        SpriteBatch spriteBatch;

        public GameTest()
        {
            GraphicsManager = new GraphicsDeviceManager(this);
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
            BackgroundSpriteFactory.Instance.LoadAllTextures(Content);
            SpriteUtilities.Game = this;
                        
            TestMarioBlockCollisions();
            TestMarioEnemyCollisionsKoopa();
            TestMarioEnemyCollisionsGoomba();
        }

        protected override void UnloadContent()
        {
            // Not used for testing purposes
        }

        protected override void Update(GameTime gameTime)
        {
            // Not used for testing purposes
        }

        protected override void Draw(GameTime gameTime)
        {
            // Not used for testing purposes
        }

        private bool TestCollisionSide(string outputDetails, Object2Side actualCollision, Object2Side expectedCollision)
        {
            bool isCorrectSide = actualCollision == expectedCollision;
            Console.WriteLine(outputDetails + isCorrectSide);
            return isCorrectSide;
        }

        public bool TestMarioBlockCollisions()
        {
            IGameObject marioLeftBlock = new Mario(new Vector2(40, 52));
            IGameObject leftBlock = new BrickBlock(new Vector2(50, 50));
            IGameObject marioTopBlock = new Mario(new Vector2(101, 90));
            IGameObject topBlock = new BrickBlock(new Vector2(100, 100));
            IGameObject marioRightBlock = new Mario(new Vector2(160, 153));
            IGameObject rightBlock = new BrickBlock(new Vector2(150, 150));
            IGameObject marioBottomBlock = new Mario(new Vector2(200, 210));
            IGameObject bottomBlock = new BrickBlock(new Vector2(200, 200));
            IGameObject marioNoBlock = new Mario(new Vector2(0, 100));
            IGameObject noCollisionBlock = new BrickBlock(new Vector2(0, 0));
                       
            Dictionary<Tuple<ObjectType, ObjectType, Object2Side>, ICollisionCommand> testDictionary = new Dictionary<Tuple<ObjectType, ObjectType, Object2Side>, ICollisionCommand>
            {
                { new Tuple<ObjectType, ObjectType, Object2Side>(ObjectType.Mario, ObjectType.Block, Object2Side.Top), new MarioBlockCollisionTopCommand()},
                { new Tuple<ObjectType, ObjectType, Object2Side>(ObjectType.Mario, ObjectType.Block, Object2Side.Right), new MarioBlockCollisionRightCommand()},
                { new Tuple<ObjectType, ObjectType, Object2Side>(ObjectType.Mario, ObjectType.Block, Object2Side.Bottom), new MarioBlockCollisionBottomCommand()},
                { new Tuple<ObjectType, ObjectType, Object2Side>(ObjectType.Mario, ObjectType.Block, Object2Side.Left), new MarioBlockCollisionLeftCommand()}
            };
            AllCollisionHandler testHandler = new AllCollisionHandler(testDictionary);

            Console.WriteLine("Tests for collision side of Mario-Brick collisions.");
            string leftOutputDetails = "Succesful recognition of left side of block collision: ";
            bool leftCollision = TestCollisionSide(leftOutputDetails, AllCollisionHandler.DetermineCollisionSide(marioLeftBlock.Destination, leftBlock.Destination), Object2Side.Left);
            string topOutputDetails = "Succesful recognition of top side of block collision: ";
            bool topCollision = TestCollisionSide(topOutputDetails, AllCollisionHandler.DetermineCollisionSide(marioTopBlock.Destination, topBlock.Destination), Object2Side.Top);
            string rightOutputDetails = "Succesful recognition of right side of block collision: ";
            bool rightCollision = TestCollisionSide(rightOutputDetails, AllCollisionHandler.DetermineCollisionSide(marioRightBlock.Destination, rightBlock.Destination), Object2Side.Right);
            string bottomOutputDetails = "Succesful recognition of bottom side of block collision: ";
            bool bottomCollision = TestCollisionSide(bottomOutputDetails, AllCollisionHandler.DetermineCollisionSide(marioBottomBlock.Destination, bottomBlock.Destination), Object2Side.Bottom);
            string noCollisionOutputDetails = "Succesful recognition of no block collision: ";
            bool noCollision = TestCollisionSide(noCollisionOutputDetails, AllCollisionHandler.DetermineCollisionSide(marioNoBlock.Destination, noCollisionBlock.Destination), Object2Side.NoCollision);
            Console.WriteLine();

            bool areCollisionsSuccessful = leftCollision && topCollision && rightCollision && bottomCollision && noCollision;

            testHandler.HandleCollision(marioLeftBlock, leftBlock);
            testHandler.HandleCollision(marioRightBlock, rightBlock);
            testHandler.HandleCollision(marioBottomBlock, bottomBlock);
            testHandler.HandleCollision(marioTopBlock, topBlock);
            testHandler.HandleCollision(marioNoBlock, noCollisionBlock);

            Console.WriteLine("Tests for collision side of handled Mario-Brick collisions (No collisions).");
            string leftHandledOutputDetails = "Succesful handling of left side of block collision: ";
            bool leftHandled = TestCollisionSide(leftHandledOutputDetails, AllCollisionHandler.DetermineCollisionSide(marioLeftBlock.Destination, leftBlock.Destination), Object2Side.NoCollision);
            string topHandledOutputDetails = "Succesful handling of top side of block collision: ";
            bool topHandled = TestCollisionSide(topHandledOutputDetails, AllCollisionHandler.DetermineCollisionSide(marioTopBlock.Destination, topBlock.Destination), Object2Side.NoCollision);
            string rightHandledOutputDetails = "Succesful handling of right side of block collision: ";
            bool rightHandled = TestCollisionSide(rightHandledOutputDetails, AllCollisionHandler.DetermineCollisionSide(marioRightBlock.Destination, rightBlock.Destination), Object2Side.NoCollision);
            string bottomHandledOutputDetails = "Succesful handling of bottom side of block collision: ";
            bool bottomHandled = TestCollisionSide(bottomHandledOutputDetails, AllCollisionHandler.DetermineCollisionSide(marioBottomBlock.Destination, bottomBlock.Destination), Object2Side.NoCollision);
            string noCollisionHandledOutputDetails = "Succesful handling of no block collision: ";
            bool noCollisionHandled = TestCollisionSide(noCollisionHandledOutputDetails, AllCollisionHandler.DetermineCollisionSide(marioNoBlock.Destination, noCollisionBlock.Destination), Object2Side.NoCollision);
            Console.WriteLine();

            bool areHandlingsSuccessful = leftHandled && topHandled && rightHandled && bottomHandled && noCollisionHandled;

            marioLeftBlock.Draw(spriteBatch);
            leftBlock.Draw(spriteBatch);
            marioTopBlock.Draw(spriteBatch);
            topBlock.Draw(spriteBatch);
            marioRightBlock.Draw(spriteBatch);
            rightBlock.Draw(spriteBatch);
            marioBottomBlock.Draw(spriteBatch);
            bottomBlock.Draw(spriteBatch);
            marioNoBlock.Draw(spriteBatch);
            noCollisionBlock.Draw(spriteBatch);

            return areCollisionsSuccessful && areHandlingsSuccessful;
        }

        public bool TestMarioEnemyCollisionsKoopa()
        {
            bool isSuccess = true;

            IGameObject marioLeftKoopa = new Mario(new Vector2(40, 52));
            IGameObject leftKoopa = new Koopa2(new Vector2(50, 50));
            IGameObject marioTopKoopa = new Mario(new Vector2(101, 90));
            IGameObject topKoopa = new Koopa2(new Vector2(100, 100));
            IGameObject marioRightKoopa = new Mario(new Vector2(160, 153));
            IGameObject rightKoopa = new Koopa2(new Vector2(150, 150));
            IGameObject marioBottomKoopa = new Mario(new Vector2(200, 210));
            IGameObject bottomKoopa = new Koopa2(new Vector2(200, 200));
            IGameObject marioNoKoopa = new Mario(new Vector2(0, 100));
            IEnemy noCollisionKoopa = new Koopa2(new Vector2(0, 0));

            Dictionary<Tuple<ObjectType, ObjectType, Object2Side>, ICollisionCommand> testDictionary = new Dictionary<Tuple<ObjectType, ObjectType, Object2Side>, ICollisionCommand>
            {
                { new Tuple<ObjectType, ObjectType, Object2Side>(ObjectType.Mario, ObjectType.Koopa, Object2Side.Top), new MarioKoopaCollisionTop()},
                { new Tuple<ObjectType, ObjectType, Object2Side>(ObjectType.Mario, ObjectType.Koopa, Object2Side.Right), new MarioKoopaCollisionRight()},
                { new Tuple<ObjectType, ObjectType, Object2Side>(ObjectType.Mario, ObjectType.Koopa, Object2Side.Bottom), new MarioKoopaCollisionBottom()},
                { new Tuple<ObjectType, ObjectType, Object2Side>(ObjectType.Mario, ObjectType.Koopa, Object2Side.Left), new MarioKoopaCollisionLeft()}
            };
            AllCollisionHandler testHandler = new AllCollisionHandler(testDictionary);

            Console.WriteLine("Tests for collision side of Mario-Koopa collisions.");
            Console.Write("Succesful recognition of left side of Koopa collision: ");
            Console.WriteLine(AllCollisionHandler.DetermineCollisionSide(marioLeftKoopa.Destination, leftKoopa.Destination) == Object2Side.Left);
            Console.Write("Succesful recognition of top side of Koopa collision: ");
            Console.WriteLine(AllCollisionHandler.DetermineCollisionSide(marioTopKoopa.Destination, topKoopa.Destination) == Object2Side.Top);
            Console.Write("Succesful recognition of right side of Koopa collision: ");
            Console.WriteLine(AllCollisionHandler.DetermineCollisionSide(marioRightKoopa.Destination, rightKoopa.Destination) == Object2Side.Right);
            Console.Write("Succesful recognition of bottom side of Koopa collision: ");
            Console.WriteLine(AllCollisionHandler.DetermineCollisionSide(marioBottomKoopa.Destination, bottomKoopa.Destination) == Object2Side.Bottom);
            Console.Write("Succesful recognition of no Koopa collision: ");
            Console.WriteLine(AllCollisionHandler.DetermineCollisionSide(marioNoKoopa.Destination, noCollisionKoopa.Destination) == Object2Side.NoCollision);
            Console.WriteLine();

            testHandler.HandleCollision(marioLeftKoopa, leftKoopa);
            testHandler.HandleCollision(marioRightKoopa, rightKoopa);
            testHandler.HandleCollision(marioBottomKoopa, bottomKoopa);
            testHandler.HandleCollision(marioTopKoopa, topKoopa);
            testHandler.HandleCollision(marioNoKoopa, noCollisionKoopa);

            /*Vector2 leftCollisionResult = new Vector2(50 - 12, 52);
            Vector2 topCollisionResult = new Vector2(101, 100 - 15);
            Vector2 rightCollisionResult = new Vector2(150 + 16, 153);
            Vector2 bottomCollisionResult = new Vector2(200, 200 + 16);
            Vector2 noCollisionResult = new Vector2(0, 100);

            Console.WriteLine("Tests for Mario-Koopa collisions.");
            Console.Write("Succesful left side of Koopa collision: (38, 52) = (");
            Console.Write(marioLeftKoopa.Destination.X);
            Console.Write(", ");
            Console.Write(marioLeftKoopa.Destination.Y);
            Console.WriteLine(")");
            isSuccess = isSuccess && (marioLeftKoopa.Destination.X == (int)leftCollisionResult.X && marioLeftKoopa.Destination.Y == (int)leftCollisionResult.Y);
            Console.Write("Succesful top side of Koopa collision: (101, 85) = (");
            Console.Write(marioTopKoopa.Destination.X);
            Console.Write(", ");
            Console.Write(marioTopKoopa.Destination.Y);
            Console.WriteLine(")");
            isSuccess = isSuccess && (marioTopKoopa.Destination.X == (int)topCollisionResult.X && marioTopKoopa.Destination.Y == (int)topCollisionResult.Y);
            Console.Write("Succesful right side of Koopa collision: (166, 153) = (");
            Console.Write(marioRightKoopa.Destination.X);
            Console.Write(", ");
            Console.Write(marioRightKoopa.Destination.Y);
            Console.WriteLine(")");
            isSuccess = isSuccess && (marioRightKoopa.Destination.X == (int)rightCollisionResult.X && marioRightKoopa.Destination.Y == (int)rightCollisionResult.Y);
            Console.Write("Succesful bottom side of Koopa collision: (200, 216) = (");
            Console.Write(marioBottomKoopa.Destination.X);
            Console.Write(", ");
            Console.Write(marioBottomKoopa.Destination.Y);
            Console.WriteLine(")");
            isSuccess = isSuccess && (marioBottomKoopa.Destination.X == (int)bottomCollisionResult.X && marioBottomKoopa.Destination.Y == (int)bottomCollisionResult.Y);
            Console.Write("Succesful no Koopa collision: (0, 100) = (");
            Console.Write(marioNoKoopa.Destination.X);
            Console.Write(", ");
            Console.Write(marioNoKoopa.Destination.Y);
            Console.WriteLine(")");
            isSuccess = isSuccess && (marioNoKoopa.Destination.X == (int)noCollisionResult.X && marioNoKoopa.Destination.Y == (int)noCollisionResult.Y);
            Console.WriteLine();
            Console.Write("Mario-Koopa collision tests are successful: ");
            Console.WriteLine(isSuccess);
            Console.WriteLine();

            marioLeftKoopa.Draw(spriteBatch);
            leftKoopa.Draw(spriteBatch);
            marioTopKoopa.Draw(spriteBatch);
            topKoopa.Draw(spriteBatch);
            marioRightKoopa.Draw(spriteBatch);
            rightKoopa.Draw(spriteBatch);
            marioBottomKoopa.Draw(spriteBatch);
            bottomKoopa.Draw(spriteBatch);
            marioNoKoopa.Draw(spriteBatch);
            noCollisionKoopa.Draw(spriteBatch);*/

            return isSuccess;
        }

        public bool TestMarioEnemyCollisionsGoomba()
        {
            bool isSuccess = true;

            IGameObject marioLeftGoomba = new Mario(new Vector2(40, 52));
            IGameObject leftGoomba = new Goomba2(new Vector2(50, 50));
            IGameObject marioTopGoomba = new Mario(new Vector2(101, 90));
            IGameObject topGoomba = new Goomba2(new Vector2(100, 100));
            IGameObject marioRightGoomba = new Mario(new Vector2(160, 153));
            IGameObject rightGoomba = new Goomba2(new Vector2(150, 150));
            IGameObject marioBottomGoomba = new Mario(new Vector2(200, 210));
            IGameObject bottomGoomba = new Goomba2(new Vector2(200, 200));
            IGameObject marioNoGoomba = new Mario(new Vector2(0, 100));
            IEnemy noCollisionGoomba = new Goomba2(new Vector2(0, 0));

            Dictionary<Tuple<ObjectType, ObjectType, Object2Side>, ICollisionCommand> testDictionary = new Dictionary<Tuple<ObjectType, ObjectType, Object2Side>, ICollisionCommand>
            {
                { new Tuple<ObjectType, ObjectType, Object2Side>(ObjectType.Mario, ObjectType.Goomba, Object2Side.Top), new MarioKoopaCollisionTop()},
                { new Tuple<ObjectType, ObjectType, Object2Side>(ObjectType.Mario, ObjectType.Goomba, Object2Side.Right), new MarioKoopaCollisionRight()},
                { new Tuple<ObjectType, ObjectType, Object2Side>(ObjectType.Mario, ObjectType.Goomba, Object2Side.Bottom), new MarioKoopaCollisionBottom()},
                { new Tuple<ObjectType, ObjectType, Object2Side>(ObjectType.Mario, ObjectType.Goomba, Object2Side.Left), new MarioKoopaCollisionLeft()}
            };
            AllCollisionHandler testHandler = new AllCollisionHandler(testDictionary);

            Console.WriteLine("Tests for collision side of Mario-Goomba collisions.");
            Console.Write("Succesful recognition of left side of Goomba collision: ");
            Console.WriteLine(AllCollisionHandler.DetermineCollisionSide(marioLeftGoomba.Destination, leftGoomba.Destination) == Object2Side.Left);
            Console.Write("Succesful recognition of top side of Goomba collision: ");
            Console.WriteLine(AllCollisionHandler.DetermineCollisionSide(marioTopGoomba.Destination, topGoomba.Destination) == Object2Side.Top);
            Console.Write("Succesful recognition of right side of Goomba collision: ");
            Console.WriteLine(AllCollisionHandler.DetermineCollisionSide(marioRightGoomba.Destination, rightGoomba.Destination) == Object2Side.Right);
            Console.Write("Succesful recognition of bottom side of Goomba collision: ");
            Console.WriteLine(AllCollisionHandler.DetermineCollisionSide(marioBottomGoomba.Destination, bottomGoomba.Destination) == Object2Side.Bottom);
            Console.Write("Succesful recognition of no Goomba collision: ");
            Console.WriteLine(AllCollisionHandler.DetermineCollisionSide(marioNoGoomba.Destination, noCollisionGoomba.Destination) == Object2Side.NoCollision);
            Console.WriteLine();

            testHandler.HandleCollision(marioLeftGoomba, leftGoomba);
            testHandler.HandleCollision(marioRightGoomba, rightGoomba);
            testHandler.HandleCollision(marioBottomGoomba, bottomGoomba);
            testHandler.HandleCollision(marioTopGoomba, topGoomba);
            testHandler.HandleCollision(marioNoGoomba, noCollisionGoomba);

            /*Vector2 leftCollisionResult = new Vector2(50 - 12, 52);
            Vector2 topCollisionResult = new Vector2(101, 100 - 15);
            Vector2 rightCollisionResult = new Vector2(150 + 16, 153);
            Vector2 bottomCollisionResult = new Vector2(200, 200 + 16);
            Vector2 noCollisionResult = new Vector2(0, 100);

            Console.WriteLine("Tests for Mario-Goomba collisions.");
            Console.Write("Succesful left side of Goomba collision: (38, 52) = (");
            Console.Write(marioLeftGoomba.Location.X);
            Console.Write(", ");
            Console.Write(marioLeftGoomba.Location.Y);
            Console.WriteLine(")");
            isSuccess = isSuccess && (marioLeftGoomba.Destination.X == (int)leftCollisionResult.X && marioLeftGoomba.Destination.Y == (int)leftCollisionResult.Y);
            Console.Write("Succesful top side of Goomba collision: (101, 85) = (");
            Console.Write(marioTopGoomba.Location.X);
            Console.Write(", ");
            Console.Write(marioTopGoomba.Location.Y);
            Console.WriteLine(")");
            isSuccess = isSuccess && (marioTopGoomba.Destination.X == (int)topCollisionResult.X && marioTopGoomba.Destination.Y == (int)topCollisionResult.Y);
            Console.Write("Succesful right side of Goomba collision: (166, 153) = (");
            Console.Write(marioRightGoomba.Location.X);
            Console.Write(", ");
            Console.Write(marioRightGoomba.Location.Y);
            Console.WriteLine(")");
            isSuccess = isSuccess && (marioRightGoomba.Destination.X == (int)rightCollisionResult.X && marioRightGoomba.Destination.Y == (int)rightCollisionResult.Y);
            Console.Write("Succesful bottom side of Goomba collision: (200, 216) = (");
            Console.Write(marioBottomGoomba.Location.X);
            Console.Write(", ");
            Console.Write(marioBottomGoomba.Location.Y);
            Console.WriteLine(")");
            isSuccess = isSuccess && (marioBottomGoomba.Destination.X == (int)bottomCollisionResult.X && marioBottomGoomba.Destination.Y == (int)bottomCollisionResult.Y);
            Console.Write("Succesful no Koopa collision: (0, 100) = (");
            Console.Write(marioNoGoomba.Location.X);
            Console.Write(", ");
            Console.Write(marioNoGoomba.Location.Y);
            Console.WriteLine(")");
            isSuccess = isSuccess && (marioNoGoomba.Destination.X == (int)noCollisionResult.X && marioNoGoomba.Destination.Y == (int)noCollisionResult.Y);
            Console.WriteLine();
            Console.Write("Mario-Goomba collision tests are successful: ");
            Console.WriteLine(isSuccess);
            Console.WriteLine();

            marioLeftGoomba.Draw(spriteBatch);
            leftGoomba.Draw(spriteBatch);
            marioTopGoomba.Draw(spriteBatch);
            topGoomba.Draw(spriteBatch);
            marioRightGoomba.Draw(spriteBatch);
            rightGoomba.Draw(spriteBatch);
            marioBottomGoomba.Draw(spriteBatch);
            bottomGoomba.Draw(spriteBatch);
            marioNoGoomba.Draw(spriteBatch);
            noCollisionGoomba.Draw(spriteBatch); */

            return isSuccess;
        }

        public bool TestMarioCoinCollisions()
        {
            bool isSuccess = true;

            IGameObject marioLeftCoin = new Mario(new Vector2(40, 52));
            IGameObject leftCoin = new Coin(new Vector2(50, 50));
            IGameObject marioTopCoin = new Mario(new Vector2(101, 90));
            IGameObject topCoin = new Coin(new Vector2(100, 100));
            IGameObject marioRightCoin = new Mario(new Vector2(160, 153));
            IGameObject rightCoin = new Coin(new Vector2(150, 150));
            IGameObject marioBottomCoin = new Mario(new Vector2(200, 210));
            IGameObject bottomCoin = new Coin(new Vector2(200, 200));
            IGameObject marioNoCoin = new Mario(new Vector2(0, 100));
            IItem noCollisionCoin = new Coin(new Vector2(0, 0));

            Dictionary<Tuple<ObjectType, ObjectType, Object2Side>, ICollisionCommand> testDictionary = new Dictionary<Tuple<ObjectType, ObjectType, Object2Side>, ICollisionCommand>
            {
                { new Tuple<ObjectType, ObjectType, Object2Side>(ObjectType.Mario, ObjectType.Goomba, Object2Side.Top), new MarioCoinCollisionTop()},
                { new Tuple<ObjectType, ObjectType, Object2Side>(ObjectType.Mario, ObjectType.Goomba, Object2Side.Right), new MarioKoopaCollisionRight()},
                { new Tuple<ObjectType, ObjectType, Object2Side>(ObjectType.Mario, ObjectType.Goomba, Object2Side.Bottom), new MarioKoopaCollisionBottom()},
                { new Tuple<ObjectType, ObjectType, Object2Side>(ObjectType.Mario, ObjectType.Goomba, Object2Side.Left), new MarioKoopaCollisionLeft()}
            };
            AllCollisionHandler testHandler = new AllCollisionHandler(testDictionary);

            Console.WriteLine("Tests for collision side of Mario-Goomba collisions.");
            Console.Write("Succesful recognition of left side of Goomba collision: ");
            Console.WriteLine(AllCollisionHandler.DetermineCollisionSide(marioLeftCoin.Destination, leftCoin.Destination) == Object2Side.Left);
            Console.Write("Succesful recognition of top side of Goomba collision: ");
            Console.WriteLine(AllCollisionHandler.DetermineCollisionSide(marioTopCoin.Destination, topCoin.Destination) == Object2Side.Top);
            Console.Write("Succesful recognition of right side of Goomba collision: ");
            Console.WriteLine(AllCollisionHandler.DetermineCollisionSide(marioRightCoin.Destination, rightCoin.Destination) == Object2Side.Right);
            Console.Write("Succesful recognition of bottom side of Goomba collision: ");
            Console.WriteLine(AllCollisionHandler.DetermineCollisionSide(marioBottomCoin.Destination, bottomCoin.Destination) == Object2Side.Bottom);
            Console.Write("Succesful recognition of no Goomba collision: ");
            Console.WriteLine(AllCollisionHandler.DetermineCollisionSide(marioNoCoin.Destination, noCollisionCoin.Destination) == Object2Side.NoCollision);
            Console.WriteLine();

            testHandler.HandleCollision(marioLeftCoin, leftCoin);
            testHandler.HandleCollision(marioRightCoin, rightCoin);
            testHandler.HandleCollision(marioBottomCoin, bottomCoin);
            testHandler.HandleCollision(marioTopCoin, topCoin);
            testHandler.HandleCollision(marioNoCoin, noCollisionCoin);

            /*Vector2 leftCollisionResult = new Vector2(50, 52);
            Vector2 topCollisionResult = new Vector2(101, 100);
            Vector2 rightCollisionResult = new Vector2(150, 153);
            Vector2 bottomCollisionResult = new Vector2(200, 200);
            Vector2 noCollisionResult = new Vector2(0, 100);

            Console.WriteLine("Tests for Mario-Coin collisions.");
            Console.Write("Succesful left side of Coin collision: (50, 52) = (");
            Console.Write(marioLeftCoin.Location.X);
            Console.Write(", ");
            Console.Write(marioLeftCoin.Location.Y);
            Console.WriteLine(")");
            isSuccess = isSuccess && (marioLeftCoin.Destination.X == (int)leftCollisionResult.X && marioLeftCoin.Destination.Y == (int)leftCollisionResult.Y);
            Console.Write("Succesful top side of Coin collision: (101, 90) = (");
            Console.Write(marioTopCoin.Location.X);
            Console.Write(", ");
            Console.Write(marioTopCoin.Location.Y);
            Console.WriteLine(")");
            isSuccess = isSuccess && (marioTopGoomba.Destination.X == (int)topCollisionResult.X && marioTopGoomba.Destination.Y == (int)topCollisionResult.Y);
            Console.Write("Succesful right side of Coin collision: (150, 153) = (");
            Console.Write(marioRightCoin.Location.X);
            Console.Write(", ");
            Console.Write(marioRightCoin.Location.Y);
            Console.WriteLine(")");
            isSuccess = isSuccess && (marioRightCoin.Destination.X == (int)rightCollisionResult.X && marioRightCOin.Destination.Y == (int)rightCollisionResult.Y);
            Console.Write("Succesful bottom side of Coin collision: (200, 200) = (");
            Console.Write(marioBottomCoin.Location.X);
            Console.Write(", ");
            Console.Write(marioBottomCoin.Location.Y);
            Console.WriteLine(")");
            isSuccess = isSuccess && (marioBottomCoin.Destination.X == (int)bottomCollisionResult.X && marioBottomCoin.Destination.Y == (int)bottomCollisionResult.Y);
            Console.Write("Succesful no Coin collision: (0, 100) = (");
            Console.Write(marioNoCoin.Location.X);
            Console.Write(", ");
            Console.Write(marioNoCoin.Location.Y);
            Console.WriteLine(")");
            isSuccess = isSuccess && (marioNoCoin.Destination.X == (int)noCollisionResult.X && marioNoGoombaCoin.Destination.Y == (int)noCollisionResult.Y);
            Console.WriteLine();
            Console.Write("Mario-Coin collision tests are successful: ");
            Console.WriteLine(isSuccess);
            Console.WriteLine();

            marioLeftCoin.Draw(spriteBatch);
            leftCoin.Draw(spriteBatch);
            marioTopCoin.Draw(spriteBatch);
            topCoin.Draw(spriteBatch);
            marioRightCoin.Draw(spriteBatch);
            rightCoin.Draw(spriteBatch);
            marioBottomCoin.Draw(spriteBatch);
            bottomCoin.Draw(spriteBatch);
            marioNoCoin.Draw(spriteBatch);
            noCollisionCoin.Draw(spriteBatch);*/

            return isSuccess;
        }
    }
}
