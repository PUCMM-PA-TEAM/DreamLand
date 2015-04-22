using DreamLand.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DreamLand.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DreamLand.GameObject {
    class Enemy : Character, IGameObject{

        public Sprite Sprite { get; set; }
        protected Vector2 _position;
        protected Animation _animationController;
        protected HealthBar _bar;

        public ContentManager Content {
            get { return _content; }
            set { _content = value; }
        }

        protected Animation _idleAnim;
        protected Animation _walkingAnim;
        protected Animation JumpingAnim;
        protected ContentManager _content;

        protected int elapsedTime;
        protected int coldDownTime;

        public bool IsAlive { get; set; }

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Animation AnimationController
        {
            get { return _animationController; }
            set { _animationController = value; }
        }

        public Enemy(Sprite sprite, Vector2 position)
        {
            Sprite = sprite;
            _position = position;
            IsAlive = true;
            Health = 100;
            Speed = 5;

            int FrameWidth = 128;
            int FrameHeigth = 128;

            _idleAnim = new Animation();
            _idleAnim.Initialize(Sprite.Texture,
                Vector2.Zero, FrameWidth, FrameHeigth, 1, 60, Color.White, 1f, true);
            _idleAnim.Frames.Add(FrameHeigth * 8);

            _walkingAnim = new Animation();
            _walkingAnim.Initialize(Sprite.Texture,
                Vector2.Zero, FrameWidth, FrameHeigth, 3, 60, Color.White, 1f, true);
            _walkingAnim.Frames.Add(FrameHeigth * 4);
            _walkingAnim.Frames.Add(FrameHeigth * 5);
            _walkingAnim.Frames.Add(FrameHeigth * 6);

            _animationController = _walkingAnim;
        }

        public void Awake() {
        }

        public virtual void Update(GameTime gameTime) {            

            _animationController.Position = Position;
            _animationController.Update(gameTime);

            _bar.Position = new Vector2(Position.X - 100, Position.Y - 100);
            Bar.UpdateHealth(Health);

            if (Health <= 0)
                IsAlive = false;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            _animationController.Draw(spriteBatch);
            Bar.Draw(spriteBatch);
        }

        public HealthBar Bar {
            get { return _bar; }
            set { _bar = value; }
        }

        public void Damaged(int damage) {
            Health -= damage;
        }
    }

  
}
