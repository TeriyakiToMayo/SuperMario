using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint1Game.Animation;
using Sprint1Game.Camera;
using Sprint1Game.CollisionHandling;
using Sprint1Game.Commands;
using Sprint1Game.DisplayPanel;
using Sprint1Game.GameObjects.ItemGameObjects;
using Sprint1Game.HeadsUp;
using Sprint1Game.Interfaces;
using Sprint1Game.Spawning;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint1Game.Controllers.GamePadController;
using static Sprint1Game.KeyboardController;

namespace Sprint1Game.GameObjects
{
    public class TheGameObjectManager
    {
        private ICollisionHandler collisionHandler;
        private Collection<IGameObject> blockList;
        private Collection<IGameObject> enemyList;
        private Collection<IGameObject> itemList;
        private Collection<IGameObject> pipeList;
        private Collection<IGameObject> spawnerList;
        private Collection<IGameObject> fireBallList;
        private Collection<IGameObject> fireBallList2;
        private Collection<IGameObject> backgroundList;
        
        private Collection<IAnimationInGame> animationList;
        private IMario[] marios;
        private IAnimation victoryAnimation;
        private IController keyboardPlayer1;
        private IController keyboardPlayer2;
        private IGamePadController gamePad1;
        private IGamePadController gamePad2;
        private ISpawnManager spawnManager;

        private IDisplayPanel titleDisplayPanel;
        private IDisplayPanel marioLifeDisplayPanel;
        private IDisplayPanel gameOverDisplayPanel;
        private IDisplayPanel headsUpDisplayPanel;
        private IDisplayPanel competitivePreparingDisplayPanel;
        private IDisplayPanel competitiveHeadsUpDisplayPanel;
        private IDisplayPanel competitiveEndingDisplayPanel;
        private PlayerNameDisplayPanel player1NameDisplayPanel;
        private PlayerNameDisplayPanel player2NameDisplayPanel;
        private bool isLevelComplete = false;
        private bool isSinglePlayerGame;
        private int[] transitionTime = { 0, 0 };
        private bool[] isMarioTransition = { false, false };
        private MarioState.MarioShapeEnums[] curShape;
        private MarioState.MarioShapeEnums[] nextShape_;
        private const int BufferSize = 32;
        private const int Players = 2;

        public IMario MarioPlayer1 { get { return marios[GameUtilities.Player1]; } }
        public IMario MarioPlayer2 { get { return marios[GameUtilities.Player2]; } }
        public long FireBallListLongCount { get { return fireBallList.LongCount(); } }

        public long FireBallList2LongCount { get { return fireBallList2.LongCount(); } }

        public long EnemyListLongCount {
            get {
                int enemyNum = 0;
                foreach(IEnemy obj in enemyList)
                {
                    if(obj.Location.X > GameUtilities.UndergroundEndLine &&
                        obj.Location.X < GameUtilities.Competitive2EndLine)
                    {
                        enemyNum++;
                    }
                }
                return enemyNum;
            }
        }

        public IDisplayPanel TitlePanel
        {
            get
            {
                return titleDisplayPanel;
            }
        }

        public ISpawnManager SpawnManager
        {
            get
            {
                return spawnManager;
            }
        }
        public TheGameObjectManager()
        {
            marios = new IMario[Players];
            blockList = new Collection<IGameObject>();
            itemList = new Collection<IGameObject>();
            enemyList = new Collection<IGameObject>();
            pipeList = new Collection<IGameObject>();
            spawnerList = new Collection<IGameObject>();
            fireBallList = new Collection<IGameObject>();
            fireBallList2 = new Collection<IGameObject>();
            backgroundList = new Collection<IGameObject>();
            animationList = new Collection<IAnimationInGame>();
            collisionHandler = new AllCollisionHandler();
            isSinglePlayerGame = true;
            curShape = new MarioState.MarioShapeEnums[Players];
            nextShape_ = new MarioState.MarioShapeEnums[Players];
            titleDisplayPanel = new TitleDisplayPanel();
            marioLifeDisplayPanel = new MarioLifeDisplayPanel();
            gameOverDisplayPanel = new GameOverDisplayPanel();
            headsUpDisplayPanel = new HeadsUpDisplayPanel();
            competitivePreparingDisplayPanel = new CompetitivePreparingDisplayPanel();
            competitiveHeadsUpDisplayPanel = new CompetitiveHeadsUpDisplayPanel();
            competitiveEndingDisplayPanel = new CompetitiveEndingDisplayPanel();
            player1NameDisplayPanel = new PlayerNameDisplayPanel();
            player1NameDisplayPanel.PlayerName.Text = "P1";
            player2NameDisplayPanel = new PlayerNameDisplayPanel();
            player2NameDisplayPanel.PlayerName.Text = "P2";

            spawnManager = new SpawnManager();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        public void Update()
        {
            bool updateHUD = true;
            if (GamePlayable())
                updateHUD = UpdateGameObjects();
            if (updateHUD)
            {
                titleDisplayPanel.Update();
                marioLifeDisplayPanel.Update();
                gameOverDisplayPanel.Update();
                headsUpDisplayPanel.Update();
                competitivePreparingDisplayPanel.Update();
                competitiveHeadsUpDisplayPanel.Update();
                competitiveEndingDisplayPanel.Update();
                UpdateCompetitiveModePlayerNames();
                SetMariosEnemyHitThisIterationToFalse();
            }
        }

        public void MarioTransition(MarioState.MarioShapeEnums curShapePara, MarioState.MarioShapeEnums nextShape, IMario mario)
        {
            keyboardPlayer1.IsFunctionKeysEnable = false;
            isMarioTransition[mario.Player] = true;
            this.curShape[mario.Player] = curShapePara;
            this.nextShape_[mario.Player] = nextShape;
            transitionTime[mario.Player] = 30;
        }
        
        public void MarioTransitionUpdate(int player)
        {
            if (transitionTime[player] == 0)
            {
                keyboardPlayer1.IsFunctionKeysEnable = true;
                isMarioTransition[player] = false;
            }
            if (transitionTime[player] % 10 == 0)
            {
                marios[player].State.MarioShapeChange(nextShape_[player]);
            }
            else if (transitionTime[player] % 5 == 0)
            {
                marios[player].State.MarioShapeChange(curShape[player]);
            }
            transitionTime[player]--;
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
           
            foreach (IGameObject obj in backgroundList)
            {
                if (IsInViewBackground(obj))
                    obj.Draw(spriteBatch);
            }
            foreach (IGameObject obj in itemList)
            {
                obj.Draw(spriteBatch);
            }
            foreach (IGameObject obj in blockList)
            {
                if (IsInView(obj))
                    obj.Draw(spriteBatch);
            }
            foreach (IGameObject obj in pipeList)
            {
                if (IsInView(obj))
                    obj.Draw(spriteBatch);
            }
            foreach (IGameObject obj in enemyList)
            {
                if (IsInView(obj))
                    obj.Draw(spriteBatch);
            }
            foreach (IAnimationInGame obj in animationList)
            {
                if (obj.State == AnimationState.IsPlaying)
                    obj.Draw(spriteBatch);
            }
            foreach (IGameObject obj in fireBallList)
            {
                obj.Draw(spriteBatch);
            }
            foreach (IGameObject obj in fireBallList2)
            {
                obj.Draw(spriteBatch);
            }
            foreach (IGameObject obj in spawnerList)
            {
                obj.Draw(spriteBatch);
            }
            marios[GameUtilities.Player1].Draw(spriteBatch);

            if(marios[GameUtilities.Player2] != null)
            {
                marios[GameUtilities.Player2].Draw(spriteBatch);
            }

            titleDisplayPanel.Draw(spriteBatch);
            marioLifeDisplayPanel.Draw(spriteBatch);
            gameOverDisplayPanel.Draw(spriteBatch);
            headsUpDisplayPanel.Draw(spriteBatch);
            competitivePreparingDisplayPanel.Draw(spriteBatch);
            competitiveEndingDisplayPanel.Draw(spriteBatch);
            competitiveHeadsUpDisplayPanel.Draw(spriteBatch);
            player1NameDisplayPanel.Draw(spriteBatch);
            player2NameDisplayPanel.Draw(spriteBatch);
        }

        public void AddBlock(IGameObject block)
        {
            blockList.Add(block);
        }

        public void AddItem(IGameObject item)
        {
            itemList.Add(item);
        }

        public void AddPipe(IGameObject pipe)
        {
            pipeList.Add(pipe);
        }

        public void AddSpawner(IGameObject spawner)
        {
            spawnerList.Add(spawner);
            spawnManager.AddSpawner((ISpawner)spawner);
        }

        public void AddEnemy(IGameObject enemy)
        {
            enemyList.Add(enemy);
        }

        public void AddBackgroundItem(IGameObject item)
        {
            backgroundList.Add(item);
        }

        public void AddFireBall(IProjectile fireBall)
        {
            fireBallList.Add(fireBall);
        }

        public void AddFireBall2(IProjectile fireBall)
        {
            fireBallList2.Add(fireBall);
        }

        public void AddAnimation(IAnimationInGame animation)
        {
            animationList.Add(animation);
        }

        public void SetMarioPlayer1(IMario newMario)
        {
            this.marios[GameUtilities.Player1] = newMario;
            AddContorllerCommandsForPlayer1(this.keyboardPlayer1);
            AddGamePadCommands(marios[GameUtilities.Player1], this.gamePad1);
        }

        public void SetMarioPlayer2(IMario newMario)
        {
            this.marios[GameUtilities.Player2] = newMario;
            AddContorllerCommandsForPlayer2(this.keyboardPlayer2);
            AddGamePadCommands(marios[GameUtilities.Player2], this.gamePad2);
        }

        public void AddKeyboardControllerCommands(IController keyboard1, IController keyboard2)
        {
            this.keyboardPlayer1 = keyboard1;
            this.keyboardPlayer2 = keyboard2;
            AddContorllerCommandsForPlayer1(keyboard1);
            AddContorllerCommandsForPlayer2(keyboard2);
        }

        public void AddGamePadControllerCommands(IGamePadController gamePad1_, IGamePadController gamePad2_)
        {
            this.gamePad1 = gamePad1_;
            this.gamePad2 = gamePad2_;
            AddGamePadCommands(marios[GameUtilities.Player1], this.gamePad1);
            AddGamePadCommands(marios[GameUtilities.Player2], this.gamePad2);
        }

        private void UpdateCompetitiveModePlayerNames()
        {
            if (GameUtilities.Game.State.Type == GameStates.Competitive && marios[GameUtilities.Player2] != null)
            {
                int player1NameX = marios[GameUtilities.Player1].Destination.X + marios[GameUtilities.Player1].Destination.Width / 2 - player1NameDisplayPanel.PlayerName.MakeDestinationRectangle(Vector2.Zero).Width / 2;
                float player1NameY = marios[GameUtilities.Player1].Destination.Y - player1NameDisplayPanel.PlayerName.MakeDestinationRectangle(Vector2.Zero).Height * 1.5f;
                player1NameDisplayPanel.Location = new Vector2(player1NameX, player1NameY);
                int player2MidPos = marios[GameUtilities.Player2].Destination.X + marios[GameUtilities.Player2].Destination.Width / 2 - player2NameDisplayPanel.PlayerName.MakeDestinationRectangle(Vector2.Zero).Width / 2;
                float player2NameY = marios[GameUtilities.Player2].Destination.Y - player2NameDisplayPanel.PlayerName.MakeDestinationRectangle(Vector2.Zero).Height * 1.5f;
                player2NameDisplayPanel.Location = new Vector2(player2MidPos, player2NameY);
            }
        }

        private void SetMariosEnemyHitThisIterationToFalse()
        {
            ScoringSystem.PlayerScore(GameUtilities.Player1).SetMarioEnemyHitThisIterationToFalse();
            if (marios[GameUtilities.Player2] != null)
                ScoringSystem.PlayerScore(GameUtilities.Player2).SetMarioEnemyHitThisIterationToFalse();
        }

        private static bool IsInView(IGameObject obj)
        {
            return (obj.Location.X >= Camera2D.CameraX - BufferSize) && 
                (obj.Location.X <= Camera2D.CameraX + 2 * Camera2D.CenterOfScreen) &&
                (obj.Location.Y <= GameUtilities.ScreenHeight);
        }

        private static bool IsAboveSeaLevel(IGameObject obj)
        {
            return obj.Location.Y <= GameUtilities.ScreenHeight;
        }

        private static bool IsInViewBackground(IGameObject obj)
        {
            return obj.Location.X >= Camera2D.CameraX - 2.5 * BufferSize && obj.Location.X <= Camera2D.CameraX + 2 * Camera2D.CenterOfScreen + 2.5 * BufferSize;
        }

        private void HandleCollisions()
        {
            HandleObjectCollisions.HandleCollisions(collisionHandler, marios, blockList, enemyList, itemList, pipeList, fireBallList, fireBallList2);
        }

        private static bool GamePlayable()
        {
            return GameUtilities.Game.State.Type == GameStates.Playing || 
                GameUtilities.Game.State.Type == GameStates.LevelComplete ||
                GameUtilities.Game.State.Type == GameStates.Competitive;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        private bool UpdateGameObjects()
        {
            spawnManager.Update();
            if (isMarioTransition[GameUtilities.Player1])
            {
                MarioTransitionUpdate(GameUtilities.Player1);
                return false;
            }
            if (isMarioTransition[GameUtilities.Player2])
            {
                MarioTransitionUpdate(GameUtilities.Player2);
                return false;
            }
            for (int i = 0; i < animationList.Count; i++)
            {
                animationList[i].Update();
            }
            foreach (IGameObject obj in backgroundList)
            {
                if (IsInViewBackground(obj))
                    obj.Update();
            }
            foreach (IGameObject obj in blockList)
            {
                if (IsInView(obj))
                    obj.Update();
            }

            Collection<IGameObject> tempEnemyList = new Collection<IGameObject>();
            foreach (IEnemy obj in enemyList)
            {
                if (IsInView(obj) || obj.CanUpdate || !obj.Alive)
                    obj.Update();
                if (IsAboveSeaLevel(obj))
                    tempEnemyList.Add(obj);
            }
            enemyList = tempEnemyList;

            foreach (IGameObject obj in itemList)
            {
                obj.Update();
            }
            foreach (IGameObject obj in pipeList)
            {
                if (IsInView(obj))
                    obj.Update();
            }
            foreach (ISpawner obj in spawnerList)
            {
                if (GameUtilities.Game.State.Type == GameStates.Competitive && IsInView(obj))
                    obj.Update();
            }

            Collection<IGameObject> tempFireBallList = new Collection<IGameObject>();
            foreach (IGameObject obj in fireBallList)
            {
                obj.Update();
                FireBallProjectile fireBall = (FireBallProjectile)obj;
                if (!fireBall.Used)
                    tempFireBallList.Add(obj);
            }
            fireBallList = tempFireBallList;

            tempFireBallList = new Collection<IGameObject>();
            foreach (IGameObject obj in fireBallList2)
            {
                obj.Update();
                FireBallProjectile fireBall = (FireBallProjectile)obj;
                if (!fireBall.Used)
                    tempFireBallList.Add(obj);
            }
            fireBallList2 = tempFireBallList;

            marios[GameUtilities.Player1].Update();
            marios[GameUtilities.Player1].IsInAir = true;

            if (marios[GameUtilities.Player2] != null)
            {
                marios[GameUtilities.Player2].Update();
                marios[GameUtilities.Player2].IsInAir = true;
            }

            HandleCollisions();
            if (isSinglePlayerGame)
                CheckAndStartSinglePlayerEndGame();

            return true;
        }

        private void CheckAndStartSinglePlayerEndGame()
        {
            if (!isLevelComplete)
            {
                if (IsEndGame())
                {
                    GameUtilities.Game.State.Proceed();
                    MarioAttributes.StopTimer();
                    isLevelComplete = true;
                    ScoringSystem.Player1Score.AddPointsForFinalPole(marios[GameUtilities.Player1].Destination);
                    IItem flag_ = null;
                    foreach (IGameObject obj in itemList)
                    {
                        if (obj.GetType() == typeof(Flag))
                            flag_ = (IItem)obj;
                    }
                    victoryAnimation = new VictoryAnimation(marios[GameUtilities.Player1], flag_);
                    victoryAnimation.State = AnimationState.IsPlaying;
                }
            }
            else
            {
                victoryAnimation.Update();
            }
        }

        private bool IsEndGame()
        {
            return marios[GameUtilities.Player1].Destination.X + marios[GameUtilities.Player1].Destination.Width >= GameUtilities.FlagLine * GameUtilities.BlockSize - GameUtilities.BlockSize / 2 &&
                   marios[GameUtilities.Player1].Destination.X + marios[GameUtilities.Player1].Destination.Width <= (GameUtilities.FlagLine + 1) * GameUtilities.BlockSize;
        }

        private void AddContorllerCommandsForPlayer1(IController keyboard)
        {
            keyboard.RegisterMario(marios[GameUtilities.Player1]);
            keyboard.ClearAllCommandDicts();
            keyboard.RegisterCommand(KeyboardKeys.Start, Keys.Enter, new EnterCommand((Game1)GameUtilities.Game));
            keyboard.RegisterCommand(KeyboardKeys.Left, Keys.Left, new LeftMarioCommand(marios[GameUtilities.Player1]));
            keyboard.RegisterCommand(KeyboardKeys.A, Keys.Up, new MarioUpCommand(marios[GameUtilities.Player1]));
            keyboard.RegisterCommand(KeyboardKeys.B, Keys.RightControl, new MarioAcceCommand(marios[GameUtilities.Player1], GameUtilities.Player1));
            keyboard.RegisterCommand(KeyboardKeys.Right, Keys.Right, new RightMarioCommand(marios[GameUtilities.Player1]));
            keyboard.RegisterCommand(KeyboardKeys.Down, Keys.Down, new MarioDownCommand(marios[GameUtilities.Player1]));
            keyboard.RegisterReleasedCommand(KeyboardKeys.Left, Keys.Left, new ReleasedLeftMarioCommand(marios[GameUtilities.Player1]));
            keyboard.RegisterReleasedCommand(KeyboardKeys.Right, Keys.Right, new ReleasedRightMarioCommand(marios[GameUtilities.Player1]));
            keyboard.RegisterReleasedCommand(KeyboardKeys.Down, Keys.Down, new ReleasedDownMarioCommand(marios[GameUtilities.Player1]));
            keyboard.RegisterReleasedCommand(KeyboardKeys.B, Keys.RightControl, new ReleasedAcceMarioCommand(marios[GameUtilities.Player1]));
            keyboard.RegisterReleasedCommand(KeyboardKeys.A, Keys.Up, new ReleasedUpMarioCommand(marios[GameUtilities.Player1]));
        }

        private void AddContorllerCommandsForPlayer2(IController keyboard)
        {
            keyboard.RegisterMario(marios[GameUtilities.Player2]);
            keyboard.ClearAllCommandDicts();
            keyboard.RegisterCommand(KeyboardKeys.Start, Keys.Escape, new EnterCommand((Game1)GameUtilities.Game));
            keyboard.RegisterCommand(KeyboardKeys.Left, Keys.A, new LeftMarioCommand(marios[GameUtilities.Player2]));
            keyboard.RegisterCommand(KeyboardKeys.A, Keys.W, new MarioUpCommand(marios[GameUtilities.Player2]));
            keyboard.RegisterCommand(KeyboardKeys.B, Keys.Space, new MarioAcceCommand(marios[GameUtilities.Player2], GameUtilities.Player2));
            keyboard.RegisterCommand(KeyboardKeys.Right, Keys.D, new RightMarioCommand(marios[GameUtilities.Player2]));
            keyboard.RegisterCommand(KeyboardKeys.Down, Keys.S, new MarioDownCommand(marios[GameUtilities.Player2]));
            keyboard.RegisterReleasedCommand(KeyboardKeys.Left, Keys.A, new ReleasedLeftMarioCommand(marios[GameUtilities.Player2]));
            keyboard.RegisterReleasedCommand(KeyboardKeys.Right, Keys.D, new ReleasedRightMarioCommand(marios[GameUtilities.Player2]));
            keyboard.RegisterReleasedCommand(KeyboardKeys.Down, Keys.S, new ReleasedDownMarioCommand(marios[GameUtilities.Player2]));
            keyboard.RegisterReleasedCommand(KeyboardKeys.B, Keys.Space, new ReleasedAcceMarioCommand(marios[GameUtilities.Player2]));
            keyboard.RegisterReleasedCommand(KeyboardKeys.A, Keys.W, new ReleasedUpMarioCommand(marios[GameUtilities.Player2]));
        }


        private static void AddGamePadCommands(IMario mario, IGamePadController keyboard)
        {
            if (mario == null)
            {
                return;
            }

            keyboard.RegisterMario(mario);
            keyboard.ClearAllCommandDicts();
            keyboard.RegisterCommand(KeyboardKeys2.Start, Buttons.Start, new EnterCommand((Game1)GameUtilities.Game));
            keyboard.RegisterCommand(KeyboardKeys2.Left, Buttons.DPadLeft, new LeftMarioCommand(mario));
            keyboard.RegisterCommand(KeyboardKeys2.A, Buttons.A, new MarioUpCommand(mario));
            keyboard.RegisterCommand(KeyboardKeys2.B, Buttons.B, new MarioAcceCommand(mario, mario.Player));
            keyboard.RegisterCommand(KeyboardKeys2.Right, Buttons.DPadRight, new RightMarioCommand(mario));
            keyboard.RegisterCommand(KeyboardKeys2.Down, Buttons.DPadDown, new MarioDownCommand(mario));
            keyboard.RegisterReleasedCommand(KeyboardKeys2.Left, Buttons.DPadLeft, new ReleasedLeftMarioCommand(mario));
            keyboard.RegisterReleasedCommand(KeyboardKeys2.Right, Buttons.DPadRight, new ReleasedRightMarioCommand(mario));
            keyboard.RegisterReleasedCommand(KeyboardKeys2.Down, Buttons.DPadDown, new ReleasedDownMarioCommand(mario));
            keyboard.RegisterReleasedCommand(KeyboardKeys2.B, Buttons.A, new ReleasedAcceMarioCommand(mario));
            keyboard.RegisterReleasedCommand(KeyboardKeys2.A, Buttons.B, new ReleasedUpMarioCommand(mario));
        }
    }
}
