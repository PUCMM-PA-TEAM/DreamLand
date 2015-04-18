using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DreamLand.GameObject
{
    class HealthBar
    {
        Texture2D Sprite;
        Vector2 _position;
        int Health;
        int FrameHeight;
        int HitPoints = 200;
        private Rectangle _sourceRect;

       public HealthBar(Texture2D _sprite, Vector2 _position, int _health, int _frameHeight)
        {
            Sprite = _sprite;
            this._position = _position;
            Health = _health;
            FrameHeight = _frameHeight;
            _sourceRect = new Rectangle(Sprite.Width, Sprite.Height, Health, FrameHeight);

        }
        public void Update(GameTime gameTime)
        {
            //Damaged(1);
            _sourceRect = new Rectangle(Sprite.Width, Sprite.Height, Health, FrameHeight);
        }

        public void Damaged(int damage)
        {
            Health-= damage;
        }
         public void Draw(SpriteBatch spriteBatch)
        {
             spriteBatch.Draw(Sprite, _position, _sourceRect, Color.White);
        }

        public Vector2 Position
        {
             get { return _position; }
             set { _position = value; }
        }

         public int hitPoint { get; set; }
    }
}
