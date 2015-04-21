using DreamLand.Classes;
using DreamLand.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;


namespace DreamLand.GameObject
{
    enum PlayerState
    {
        Idle,
        Walking,
        Dead
    }

    class Player : Character, IGameObject
    {
        Texture2D GameOverTexture;
        Rectangle GameOverRectangle;

        public Sprite Sprite { get; set; }
        private ContentManager _content;
        private Vector2 _position;
        private PlayerState _playerState;
        private Animation _animationController;        

        private Animation IdleAnim;
        private Animation WalkingAnim;
        private Animation JumpingAnim;
        private HealthBar _bar;

        public List<Projectile> Projectiles;
        private TimeSpan fireTime;
        private TimeSpan previousFireTime;

        private bool canShoot;
        public bool IsAlive { get; set; }

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public HealthBar Bar
        {
            get { return _bar;}
            set { _bar = value; }
        }

        public Animation AnimationController
        {
            get { return _animationController; }
            set { _animationController = value; }
        }

        public ContentManager Content{
            get { return _content; }
            set { _content = value; } 
        }

        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;

        bool hasJumped;

        
        public Player(Sprite sprite, Vector2 position)
        {
            
            Sprite = sprite;
            _position = position;
            IsAlive = true;
            Health = 100;
            _playerState = PlayerState.Idle;
            Speed = 5;

            int FrameWidth = 128;
            int FrameHeigth = 128;

            

            IdleAnim = new Animation();
            IdleAnim.Initialize(Sprite.Texture,
                Vector2.Zero, FrameWidth, FrameHeigth, 1, 60, Color.White, 1f, true);
            IdleAnim.Frames.Add(FrameHeigth * 8);

            WalkingAnim = new Animation();
            WalkingAnim.Initialize(Sprite.Texture,
                Vector2.Zero, FrameWidth, FrameHeigth, 3, 60, Color.White, 1f, true);
            WalkingAnim.Frames.Add(FrameHeigth * 4);
            WalkingAnim.Frames.Add(FrameHeigth * 5);
            WalkingAnim.Frames.Add(FrameHeigth * 6);

            JumpingAnim = new Animation();
            JumpingAnim.Initialize(Sprite.Texture,
                 Vector2.Zero, FrameWidth, FrameHeigth, 1, 60, Color.White, 1f, true);
            JumpingAnim.Frames.Add(FrameHeigth * 2);

            _animationController = IdleAnim;
        }

       

        public void Awake() {
            Projectiles = new List<Projectile>();
            fireTime = TimeSpan.FromSeconds(0.15f);
            canShoot = true;

            GameOverTexture = Content.Load<Texture2D>("GameOver");
            GameOverRectangle = new Rectangle(0, 0, GameOverTexture.Width, GameOverTexture.Height);
        }

        public void Update(GameTime gameTime){
            if (Health <= 0)
                IsAlive = false;
           
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            // Play Left Animation
            if (currentKeyboardState.IsKeyDown(Keys.Left))
            {
                _position.X -= Speed;
                IdleAnim.Effect = SpriteEffects.None;
                WalkingAnim.Effect = SpriteEffects.None;

                _animationController = WalkingAnim;
            }

            // Play Right Animation
            else if (currentKeyboardState.IsKeyDown(Keys.Right))
            {
                _position.X += Speed;
                IdleAnim.Effect = SpriteEffects.FlipHorizontally;
                WalkingAnim.Effect = SpriteEffects.FlipHorizontally;

                _animationController = WalkingAnim;
            } 

            else
                _animationController = IdleAnim;

            _animationController.Position = Position;
            _animationController.Update(gameTime);
            
            if (currentKeyboardState.IsKeyDown(Keys.Space) && hasJumped == false) {
               
                _position.Y -= 100f;
                
                hasJumped = true;
                _animationController = JumpingAnim;
            }
            else if(hasJumped == true)
            {
                float i=20;
                _position.Y += 0.15f * i;
            
            }

            if (_position.Y > 350)
            {
                hasJumped = false;
            }

            if (currentKeyboardState.IsKeyDown(Keys.X) && canShoot == true){
                AddProjectile();
                canShoot = false;
            }

            if (gameTime.TotalGameTime - previousFireTime > fireTime){
                previousFireTime = gameTime.TotalGameTime;
                canShoot = true;
            }

            UpdateProjectiles(gameTime);
            _bar.UpdateHealth(Health);
        }

        private void UpdateProjectiles(GameTime gameTime){
            for (int i = 0; i < Projectiles.Count; i++){
                Projectiles[i].Update(gameTime);
                if(Projectiles[i].isActive == false)
                    Projectiles.RemoveAt(i);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _animationController.Draw(spriteBatch);
            _bar.Draw(spriteBatch);
            if(IsAlive == false)
            {
                spriteBatch.Draw(GameOverTexture, GameOverRectangle, Color.White);
            }
            for (int i = 0; i < Projectiles.Count; i++){
                Projectiles[i].Draw(spriteBatch);
            }
        }

        public void Damaged(int damage) {
            Health -= damage;
        }

        public void AddProjectile(){
            Projectile fireball = new Projectile();
            fireball = new Projectile();
            fireball.Sprite = new Sprite(Content.Load<Texture2D>("fireblast"));
            fireball.Position = Position;
            Projectiles.Add(fireball);
        }
    }
}
