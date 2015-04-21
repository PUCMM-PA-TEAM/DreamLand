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
        private Vector2 _position;
        private Animation _animationController;
        private HealthBar _bar;
        public List<Projectile> Projectiles;
        public ContentManager Content {
            get { return _content; }
            set { _content = value; }
        }

        private Animation _idleAnim;
        private Animation _walkingAnim;
        private Animation JumpingAnim;
        private ContentManager _content;

        private int elapsedTime;
        private int coldDownTime;

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

            elapsedTime = 0;
           coldDownTime= 3000;

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
            Projectiles = new List<Projectile>();
        }

        public void Awake() {
        }

        public void Update(GameTime gameTime) {            
             // _animationController = _idleAnim;

            _animationController.Position = Position;
            _animationController.Update(gameTime);

            _bar.Position = new Vector2(Position.X - 100, Position.Y - 100);
            //Bar.Update(gameTime);
            Bar.UpdateHealth(Health);

            if (Health <= 0)
                IsAlive = false;

            elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsedTime > coldDownTime) {
                elapsedTime = 0;
                AddProjectile();
            }

            UpdateProjectiles(gameTime);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _animationController.Draw(spriteBatch);
            Bar.Draw(spriteBatch);
            for (int i = 0; i < Projectiles.Count; i++) {
                Projectiles[i].Draw(spriteBatch);
            }
        }

        public HealthBar Bar {
            get { return _bar; }
            set { _bar = value; }
        }

        public void Damaged(int damage) {
            Health -= damage;
        }

        private void UpdateProjectiles(GameTime gameTime) {
            for (int i = 0; i < Projectiles.Count; i++) {
                Projectiles[i].Update(gameTime);
                if (Projectiles[i].isActive == false)
                    Projectiles.RemoveAt(i);
            }
        }

        public void AddProjectile() {
            Projectile fireball = new Projectile();
            fireball = new Projectile();
            fireball.Sprite = new Sprite(Content.Load<Texture2D>("fireblast"));
            fireball.Position = Position;
            if (AnimationController.Effect == SpriteEffects.None)
                fireball.Direction = -1;
            else{
                fireball.Direction = 1;
            }

            Projectiles.Add(fireball);
        }
    }

  
}
