using System;
using System.Collections.Generic;
using System.Linq;
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

        Player player;
        private Enemy enemy;
        private Enemy enemy_2;
        Texture2D background;
        HealthBar player_health;

        HealthBar enemy_health;
        
       

        Rectangle sourceRect = new Rectangle(0, 0, 800, 540);
        Rectangle destionationRect = new Rectangle(0, 0, 800, 540);

        private int LEFT_BORDER;
        private int RIGHT_BORDER;
        Scene intoTheWoods = new Scene();
        

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
            LEFT_BORDER = 0;
            RIGHT_BORDER = GraphicsDevice.Viewport.Width;
            //player.Initalize();
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
            Texture2D enemy2Sprite = Content.Load<Texture2D>("Boss Dragon");
           background = Content.Load<Texture2D>("Gothic");

            intoTheWoods.Stages.Add(Content.Load<Texture2D>("Fantasy"));
            intoTheWoods.Stages.Add(Content.Load<Texture2D>("Fantasy"));
            intoTheWoods.Stages.Add(Content.Load<Texture2D>("Fantasy"));
            //intoTheWoods.Stages.Add(Content.Load<Texture2D>("Woods 02"));
            //intoTheWoods.Stages.Add(Content.Load<Texture2D>("Woods 03"));
            intoTheWoods.Initalize();
            player = new Player(new Sprite(playerSprite),
                new Vector2(100, 350));

            enemy = new Enemy(new Sprite(enemySprite),
                new Vector2(600, 350));

            enemy_2 = new Enemy(new Sprite(enemy2Sprite), new Vector2(500,350));
           
          

           player_health = new HealthBar(healthbar, new Vector2(100, 200),200, 20);
           
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
            //if (player.Position.X > RIGHT_BORDER) {
            //    player.Position = new Vector2(100, 350);
            //    sourceRect.X += 600;
            //}

            //if (player.Position.X < LEFT_BORDER) {
            //    player.Position = new Vector2(600, 350);
            //    sourceRect.X -= 600;
            //}
            intoTheWoods.Update(gameTime, player);

            player.Update(gameTime);
            enemy.Update(gameTime);
            enemy_2.Update(gameTime);

           

            
            player_health.Update(gameTime);
           
            

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

            spriteBatch.Draw(background, destionationRect, sourceRect, Color.White);
           // intoTheWoods.Draw(spriteBatch);
            enemy.Draw(spriteBatch);
            player.Draw(spriteBatch);
            enemy_2.Draw(spriteBatch);
           player_health.Draw(spriteBatch);
           
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
