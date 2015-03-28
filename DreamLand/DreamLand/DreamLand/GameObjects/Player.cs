using System;
using DreamLand.Scripts;
using DreamLand.Scripts.classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DreamLand.GameObjects {
    class Player : GameObject{

        Sprite Sprite { get; set; }
        private KeyboardInputController _inputController;
        private float _speed;
        private float _direction;

        public override void Init()
        {
            _speed = 5f;
            Transform = new Transform();
            Transform.Position = new Vector2(300, 200);
            _inputController = new KeyboardInputController(ref _direction);
        }

        public override void LoadContent(ContentManager content, string texturePath)
        {
           Sprite = new Sprite(content.Load<Texture2D>(texturePath));
        }

        public override void Update(GameTime gameTime)
        {
            _inputController.Update(ref _direction);
            Transform.Position.X += _speed * _direction;
        }

        public override void Draw(SpriteBatch spriteBatch) {
            
            spriteBatch.Draw(Sprite.Texture, Transform.Position, new Rectangle(0,128*5, 128, 128), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}
