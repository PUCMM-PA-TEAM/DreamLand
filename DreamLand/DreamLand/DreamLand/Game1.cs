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
        
        enum GameState{
            MainMenu,
            Options,
            Playing,
            Exit,
            LoadGame,
            Historia
        }

        GameState CurrentGameState = GameState.MainMenu;

        cButton btnPlay;
        cButton btnExit;
        cButton btnLoad;
        cButton btnAbout;
        int screenWidth = 800, 
            screenHeight = 600;

        //Save Game
        SaveLoadGame Save;
        SaveLoadGame Load;
        Player _player;

        //Pause
        bool paused = false;
        public bool showDungeon = false;
        public bool isStatus = false;
        public bool isAbout = false;
        Texture2D pausedTexture;
        Rectangle pausedRectangle;
        cButton btnPlay2, btnQuit,btnSave,btnStatus;

        Texture2D aboutTexture;
        Rectangle aboutRectangle;


        //PLayer Status
        Status _playerStatus;
       
        
        SceneTransition _world = new SceneTransition();
        SceneTransition _dungeon = new SceneTransition();


        Name _characterName;

        //Main Menu Song
        Song song;
        Song forest;
        Song dead;
        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //Components.Add(new GamerServicesComponent(this)); 
            
   
            
                   
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
            song = Content.Load<Song>("Starting");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;

            forest = Content.Load<Song>("Forest");
            dead = Content.Load<Song>("Dead");
            
            // TODO: use this.Content to load your game content here
            //Start Menu

            //Start Game Button
            btnPlay = new cButton(Content.Load<Texture2D>("StartGame"), graphics.GraphicsDevice);
            btnPlay.setPosition(new Vector2(290, 250));
            //Load  Button
            btnLoad = new cButton(Content.Load<Texture2D>("LoadGame"), graphics.GraphicsDevice);
            btnLoad.setPosition(new Vector2(290, 300));
            //About button
            btnAbout = new cButton(Content.Load<Texture2D>("About"), graphics.GraphicsDevice);
            btnAbout.setPosition(new Vector2(290, 350));
            //Exit Button
            btnExit = new cButton(Content.Load<Texture2D>("ExitGame"), graphics.GraphicsDevice);
            btnExit.setPosition(new Vector2(290, 400));

            //Pause Menu
            pausedTexture = Content.Load<Texture2D>("Paused");
            pausedRectangle = new Rectangle(0, 0, pausedTexture.Width, pausedTexture.Height);
            btnPlay2 = new cButton(Content.Load<Texture2D>("Resume"),graphics.GraphicsDevice);
            btnPlay2.setPosition(new Vector2(290,250));
            btnStatus = new cButton(Content.Load<Texture2D>("Status"), graphics.GraphicsDevice);
            btnStatus.setPosition(new Vector2(290, 300));
            btnSave = new cButton(Content.Load<Texture2D>("SaveGame"), graphics.GraphicsDevice);
            btnSave.setPosition(new Vector2(290, 350));
            btnQuit = new cButton(Content.Load<Texture2D>("ExitGame2"),graphics.GraphicsDevice);
            btnQuit.setPosition(new Vector2(290,400));

            aboutTexture = Content.Load<Texture2D>("History");
            aboutRectangle = new Rectangle(0, 0, aboutTexture.Width, aboutTexture.Height);
            

           
            //Screen
            //graphics.PreferredBackBufferWidth = screenWidth;
            //graphics.PreferredBackBufferHeight = screenHeight;
            //graphics.ApplyChanges();
            IsMouseVisible = true;

            //Load Player assets
            Texture2D healthbar = Content.Load<Texture2D>("health");
            Texture2D playerSprite = Content.Load<Texture2D>("Girl");
            Texture2D enemySprite = Content.Load<Texture2D>("Boss Dragon");

            _player = new Player(new Sprite(playerSprite),
                      new Vector2(100, 360));
            _player.Content = Content;

            HealthBar _playerBar;
            int offset = 10;
            _playerBar = new HealthBar(healthbar,
                new Vector2(0 + offset, 0 + offset), 200, 20);
            _player.Bar = _playerBar;

            LittleDragon enemy = new LittleDragon(new Sprite(enemySprite), new Vector2(700, 350));
            enemy.Content = Content;

            HealthBar _enemyBar;
            _enemyBar = new HealthBar(healthbar,
                new Vector2(enemy.Position.X, enemy.Position.Y - 100), 200, 20);
            enemy.Bar = _enemyBar;

            _world.Scenes.Add(new Wood01() {
                Sprite = Content.Load<Texture2D>("wood 01"),
                Content = this.Content
            });

            _world.Scenes.Add(new Wood02() {
            
             Sprite = Content.Load<Texture2D>("wood 02"),
                Enemy = enemy,
                Player = _player,
                Content = this.Content
            });

            _world.Scenes.Add(new StarterTown() {
                Sprite = Content.Load<Texture2D>("Background"),
                Content = this.Content
            });

            _world.Scenes.Add(new Wood03() {
                Sprite = Content.Load<Texture2D>("wood 03"),
                Content = this.Content,
                GameProperty = this,
                Player =  _player
            });

            _dungeon.Scenes.Add(new Castle01(){

                Sprite = Content.Load<Texture2D>("dungeon 03"),
                Content = this.Content,
                GameProperty =  this,
                Player = _player,
                Orc1 =  new Enemy(new Sprite(Content.Load<Texture2D>("little Orco")), new Vector2(700, 360)){
                    Bar = new HealthBar(healthbar,
                new Vector2(700, 200 - 100), 200, 20),
                    Content =  Content
                },
                Orc2 = new Enemy(new Sprite(Content.Load<Texture2D>("little Orco")), new Vector2(300, 360))
                {
                    Bar = new HealthBar(healthbar, new Vector2(400,360-160),200,20),
                    Content = Content
                },
                Orc3 = new Enemy(new Sprite(Content.Load<Texture2D>("little Orco")), new Vector2(500, 360))
                {
                    Bar = new HealthBar(healthbar, new Vector2(400,200-100),200,20),
                    Content = Content
                }
             
            });

            _dungeon.Scenes.Add(new Castle02(){
                Sprite = Content.Load<Texture2D>("dungeon 02"),
                Content = this.Content
            });

            _dungeon.Scenes.Add(new Castle03(){
                Sprite = Content.Load<Texture2D>("dungeon 01"),
                Content = this.Content,
            });

            _dungeon.Initalize();
            _world.Initalize();
            _player.Awake();

            _playerStatus = new Status();
            _playerStatus.Player = _player;
            _playerStatus.Content = Content;
            _playerStatus.Initialize();


            _characterName = new Name();
            _characterName.Content = Content;
            _characterName.Initialize();

            
            Save = new SaveLoadGame();
            Load = new SaveLoadGame();
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
            btnAbout.Update(mouse);

            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    if (btnPlay.isClicked == true)
                    {
                        CurrentGameState = GameState.Playing;
                        btnPlay.Update(mouse);
                        MediaPlayer.IsRepeating = false;
                        MediaPlayer.Stop();
                        MediaPlayer.Play(forest);
                        MediaPlayer.IsRepeating = true;
                        
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
                    if(btnAbout.isClicked == true)
                    {
                        CurrentGameState = GameState.Historia;
                        isAbout = true;
                    }
                   

                    break;
                case GameState.Playing:
                    {
                        if (!paused){

                            
                            if(Keyboard.GetState().IsKeyDown(Keys.Enter)){
                                paused = true;
                                btnPlay2.isClicked = false;
                            }

                            if(!showDungeon)
                            _world.Update(gameTime, _player);
                            else{
                                _dungeon.Update(gameTime, _player);
                                
                            }
                            _player.Update(gameTime);
                            MediaPlayer.Resume();

                            
                        }
                        else if(paused)
                        {
                            MediaPlayer.Stop();
                            if (btnPlay2.isClicked)
                                paused = false;
                              
                            if (btnQuit.isClicked)
                                Exit();
                            if (btnSave.isClicked)
                                Save.InitiateSave();
                            if (btnStatus.isClicked)
                                isStatus = true;
                                
                             
                            btnPlay2.Update(mouse);
                            btnStatus.Update(mouse);
                            btnQuit.Update(mouse);
                            btnSave.Update(mouse);
                            
                        }
                        break;
                    }

                case GameState.LoadGame:
                    {
                        //CurrentGameState = GameState.Playing;     
                        Load.InitiateLoad();
                        break;
                    }
                

                case GameState.Exit:
                    {
                        this.Exit();
                        break;
                    }

                    // TODO: Add your update logic here  
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
                    btnAbout.Draw(spriteBatch);
                    break;
                case GameState.Playing:
                    {
                        
                        

                        if(!showDungeon)
                            _world.Draw(spriteBatch);
                        else{
                            _dungeon.Draw(spriteBatch);
                            
                        }
                      _player.Draw(spriteBatch);

                    if(paused)
                    {
                        spriteBatch.Draw(pausedTexture, pausedRectangle, Color.White);
                        btnPlay2.Draw(spriteBatch);
                        btnStatus.Draw(spriteBatch);
                        btnSave.Draw(spriteBatch);
                        btnQuit.Draw(spriteBatch);

                        if(isStatus == true)
                            _playerStatus.Draw(spriteBatch);
                            
                            isStatus = false;

                        
                    }
                    

                        break;
                    }
                case GameState.LoadGame:
                    {
                        
                    
                        break;
                    }

                case GameState.Historia:
                    {
              
                            spriteBatch.Draw(aboutTexture, aboutRectangle, Color.White);
                            isAbout = false;
                            CurrentGameState = GameState.MainMenu;

                        break;
                    }
                case GameState.Exit:
                    
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
