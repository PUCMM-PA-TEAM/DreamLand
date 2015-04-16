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

namespace DreamLand
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player _player;
        private Enemy _enemy;
        HealthBar _playerHealth;

        SceneTransition _world = new SceneTransition();
        CombatEngine _combatEngine = new CombatEngine(); 

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //  Load Player assets
            Texture2D healthbar = Content.Load<Texture2D>("health");
            Texture2D playerSprite = Content.Load<Texture2D>("Girl");
            Texture2D enemySprite = Content.Load<Texture2D>("Boss Dragon");

            _world.Scenes.Add(new Wood01()
            {
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

            //enemy = new Enemy(new Sprite(enemySprite),
            //    new Vector2(600, 350));
         
           _playerHealth = new HealthBar(healthbar, new Vector2(100, 200),200, 20);
           

//            _combatEngine.Initialize(_player, _enemy, Content.Load<SpriteFont>("Courier New"));

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            _world.Update(gameTime, _player);

            _player.Update(gameTime);
            //enemy.Update(gameTime);
           
   
           // _combatEngine.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();


           // spriteBatch.Draw(background, destionationRect, sourceRect, Color.White);
            _world.Draw(spriteBatch);
            //enemy.Draw(spriteBatch);
            _player.Draw(spriteBatch);

            //combatEngine.Draw(spriteBatch);
            //player_health.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
