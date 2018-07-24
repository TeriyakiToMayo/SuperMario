using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint1Game.Controllers;
using Sprint1Game.GameObjects;
using Sprint1Game.Interfaces;
using Sprint1Game.LevelSpecification;
using Sprint1Game.SpriteFactories;
using Sprint1Game.Camera;
using System;
using Sprint1Game.States.GameStates;
using Sprint1Game.Sound;
using System.Collections.Generic;
using Sprint1Game.Commands;

namespace Sprint1Game
{
    public class Game1 : AbstractGame
    {
        SpriteBatch spriteBatch;
        IController keyboardPlayer1;
        IController keyboardPlayer2;
        IGamePadController gamePad1;
        IGamePadController gamePad2;
        TheGameObjectManager allObjectsManager;
        Camera2D camera;

        public Game1()
        {
            this.GraphicsManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            State = new TitleState(this);
        }
        
        protected override void Initialize()
        {
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            loadSpriteFactories();
            SoundManager.Instance.LoadAllSounds(Content);
            allObjectsManager = new TheGameObjectManager();
            GameUtilities.GameObjectManager = allObjectsManager;
            spriteBatch = new SpriteBatch(GraphicsDevice);
            GameUtilities.Game = this;
            int width = GraphicsDevice.Viewport.Bounds.Width;
            int height = GraphicsDevice.Viewport.Bounds.Height;
            LoadLevel loader = new LoadLevel(width, height, allObjectsManager);
            InitializeControllers();
            loader.loadTheLevel();

            camera = new Camera2D();
            Camera2D.LimitationList.Add(GameUtilities.LevelEndLine * GameUtilities.BlockSize);
            Camera2D.LimitationList.Add(GameUtilities.UndergroundEndLine * GameUtilities.BlockSize);
            Camera2D.LimitationList.Add(GameUtilities.Competitive1EndLine * GameUtilities.BlockSize);
            Camera2D.LimitationList.Add(GameUtilities.Competitive2EndLine * GameUtilities.BlockSize);
        }

        protected override void UnloadContent() { }
        
        protected override void Update(GameTime gameTime)
        {
            if (IsControllerEnable)
            {
                keyboardPlayer1.Update();
                keyboardPlayer2.Update();
                gamePad1.Update();
                gamePad2.Update();
            }
            
            if (!(State.Type == GameStates.Pause || State.Type == GameStates.CompetitivePause))
            {
                allObjectsManager.Update();
            }
            
            Camera2D.Move(allObjectsManager.MarioPlayer1);
            MarioAttributes.tick(gameTime);
            HurrySoundManager.Instance.CheckForHurry();
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            var screenScale = GetScreenScale;
            var viewMatrix = camera.GetTransform;
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied,
                                       null, null, null, null, viewMatrix * Matrix.CreateScale(screenScale));
            GraphicsDevice.Clear(Color.CornflowerBlue);
            allObjectsManager.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        
        private void InitializeControllers()
        {
            keyboardPlayer1 = new KeyboardController();
            keyboardPlayer2 = new KeyboardController();
            gamePad1 = new GamePadController();
            gamePad2 = new GamePadController();
            allObjectsManager.AddKeyboardControllerCommands(keyboardPlayer1, keyboardPlayer2);
            allObjectsManager.AddGamePadControllerCommands(gamePad1, gamePad2);
        }

        public void Reset()
        {
            LoadContent();
            Camera2D.ResetCamera();
            MarioAttributes.ResetTimer();
            MarioAttributes.StartTimer();
        }

        void loadSpriteFactories()
        {
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            PipeSpriteFactory.Instance.LoadAllTextures(Content);
            ProjectileSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            MarioSpriteFactory.Instance.LoadAllTextures(Content);
            BackgroundSpriteFactory.Instance.LoadAllTextures(Content);
            TextSpriteFactory.Instance.LoadAllTextures(Content);
        }
        public Vector3 GetScreenScale
        {
            get {
                var scaleX = (float)GraphicsDevice.Viewport.Width / (float)GameUtilities.ScreenWidth;
                var scaleY = (float)GraphicsDevice.Viewport.Height / (float)GameUtilities.ScreenHeight;
                return new Vector3(scaleX, scaleY, 1.0f);
            }
        }
    }
}