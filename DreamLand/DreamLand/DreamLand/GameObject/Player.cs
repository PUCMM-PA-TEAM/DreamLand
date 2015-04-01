using DreamLand.Classes;
using DreamLand.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


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
        public Sprite Sprite { get; set; }
        private Vector2 _Position;
        private PlayerState _PlayerState;
        private Animation _AnimationController;        

        private Animation IdleAnim;
        private Animation WalkingAnim;
    
        public bool IsAlive { get; set; }

        public Vector2 Position
        {
            get { return _Position; }
            set { _Position = value; }
        }

        public Animation AnimationController
        {
            get { return _AnimationController; }
            set { _AnimationController = value; }
        }

        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;

        public Player(Sprite sprite, Vector2 position)
        {
            Sprite = sprite;
            _Position = position;
            IsAlive = true;
            Health = 100;
            _PlayerState = PlayerState.Idle;
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

            _AnimationController = IdleAnim;
        }

        public void Initalize() {
        }

        public void Update(GameTime gameTime) {            
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            // Play Left Animation
            if (currentKeyboardState.IsKeyDown(Keys.Left))
            {
                _Position.X -= Speed;
                IdleAnim.Effect = SpriteEffects.None;
                WalkingAnim.Effect = SpriteEffects.None;
                _AnimationController = WalkingAnim;
            }

            // Play Right Animation
            else if (currentKeyboardState.IsKeyDown(Keys.Right))
            {
                _Position.X += Speed;
                IdleAnim.Effect = SpriteEffects.FlipHorizontally;
                WalkingAnim.Effect = SpriteEffects.FlipHorizontally;

                _AnimationController = WalkingAnim;
            }

            else
                _AnimationController = IdleAnim;

            _AnimationController.Position = Position;
            _AnimationController.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _AnimationController.Draw(spriteBatch);
            //spriteBatch.Draw(Sprite.Texture, Position, 
            //    new Rectangle(0,128*8, 128, 128),
            //    Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}
