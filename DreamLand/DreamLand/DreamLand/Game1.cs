using System;
using System.Collections.Generic;
using System.Linq;
using DreamLand.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using DreamLand.GameObject;
using DreamLand.Scripts;
using DreamLand.Scenes;
using DreamLand.Classes;

namespace DreamLand {
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        enum GameState
        {
            MainMenu,
            Options,
            Playing,
            Exit,
            LoadGame
        }

        GameState CurrentGameState = GameState.MainMenu;

        cButton btnPlay;
        cButton btnExit;
        cButton btnLoad;
        int screenWidth = 800, 
            screenHeight = 600;

        Player _player;
        private Enemy _enemy;

        SceneTransition _world = new SceneTransition();

        CombatEngine _combatEngine = new CombatEngine();

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here



            //Start Game Button
            btnPlay = new cButton(Content.Load<Texture2D>("StartGame"), graphics.GraphicsDevice);
            btnPlay.setPosition(new Vector2(290, 250));
            //Load  Button
            btnLoad = new cButton(Content.Load<Texture2D>("LoadGame"), graphics.GraphicsDevice);
            btnLoad.setPosition(new Vector2(290, 300));

            //Exit Button
            btnExit = new cButton(Content.Load<Texture2D>("ExitGame"), graphics.GraphicsDevice);
            btnExit.setPosition(new Vector2(290, 350));
            //Screen
            //graphics.PreferredBackBufferWidth = screenWidth;
            //graphics.PreferredBackBufferHeight = screenHeight;
            //graphics.ApplyChanges();
            IsMouseVisible = true;


            //Load Player assets
            Texture2D healthbar = Content.Load<Texture2D>("health");
            Texture2D playerSprite = Content.Load<Texture2D>("Girl");
            Texture2D enemySprite = Content.Load<Texture2D>("Boss Dragon");

            _world.Scenes.Add(new Wood01() {
                Sprite = Content.Load<Texture2D>("wood 01")
            });

            _world.Scenes.Add(new Wood02() {
                Sprite = Content.Load<Texture2D>("wood 02"),
                Enemy = new Enemy(new Sprite(enemySprite), new Vector2(700, 300))
            });

            _world.Scenes.Add(new Wood01() {
                Sprite = Content.Load<Texture2D>("Background")
            });

            _world.Initalize();
            _player = new Player(new Sprite(playerSprite),
                                  new Vector2(100, 360));
            HealthBar _playerBar;
            int offset = 10;
            _playerBar = new HealthBar(healthbar,
                new Vector2(0 + offset, 0 + offset), 200, 20);
            _player.Bar = _playerBar;

            Enemy enemy = ((Wood02)_world.Scenes[1]).Enemy;

            HealthBar _enemyBar;
            _enemyBar = new HealthBar(healthbar,
                new Vector2(enemy.Position.X, enemy.Position.Y - 100), 200, 20);
            enemy.Bar = _enemyBar;

            ((Wood02) _world.Scenes[1]).Player = _player;

            foreach (Scene scene in _world.Scenes) {
                scene.Init();
            }

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit

            MouseState mouse = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            btnPlay.Update(mouse);
            btnLoad.Update(mouse);
            btnExit.Update(mouse);

            switch (CurrentGameState)
            {

                case GameState.MainMenu:
                    if (btnPlay.isClicked == true)
                    {
                        CurrentGameState = GameState.Playing;
                        btnPlay.Update(mouse);
                    }
                    if (btnLoad.isClicked == true)
                    {
                        CurrentGameState = GameState.LoadGame;
                        btnLoad.Update(mouse);
                    }
                    if (btnExit.isClicked == true)
                    {
                        CurrentGameState = GameState.Exit;
                        btnExit.Update(mouse);
                    }

                    break;
                case GameState.Playing:
                    {
                        _world.Update(gameTime, _player);

                        _player.Update(gameTime);
                        break;
                    }
                case GameState.LoadGame:
                    {
                        CurrentGameState = GameState.Playing;
                        break;
                    }
                case GameState.Exit:
                    {
                        this.Exit();
                        break;
                    }

                    // TODO: Add your update logic here
                    //_world.Update(gameTime, _player);

                    //_player.Update(gameTime);

                    base.Update(gameTime);
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

             switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    spriteBatch.Draw(Content.Load<Texture2D>("DreamLand"),new Rectangle(0,0,screenWidth,screenHeight),Color.White);
                    btnPlay.Draw(spriteBatch);
                    btnExit.Draw(spriteBatch);
                    btnLoad.Draw(spriteBatch);
                    break;
                case GameState.Playing:
                    {
                       _world.Draw(spriteBatch);
                      _player.Draw(spriteBatch);

                        break;
                    }
                case GameState.LoadGame:
                    {
                    
                        break;
                    }
                case GameState.Exit:
                    
                    break;
            }

            //_world.Draw(spriteBatch);
            //_player.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
