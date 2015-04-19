using DreamLand.Classes;
using DreamLand.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DreamLand.GameObject
{
    class NPC: Character ,IGameObject
    {
         public Sprite Sprite { get; set; }
        private Vector2 _position;
        private Animation _animationController;
        private HealthBar _bar;

        private Animation _idleAnim;
        private Animation _walkingAnim;
        private Animation JumpingAnim;
    
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

        public NPC(Sprite sprite, Vector2 position)
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

        public void Initalize() {
        }

        public void Update(GameTime gameTime) {            
             // _animationController = _idleAnim;

            _animationController.Position = Position;
            _animationController.Update(gameTime);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _animationController.Draw(spriteBatch);
           
        }

 
    }
}
