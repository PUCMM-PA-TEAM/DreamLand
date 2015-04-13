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
        Vector2 Position;
        int Health;
        int FrameHeight;
        int HitPoints =200;
        Rectangle rectangle;

       public HealthBar(Texture2D _sprite, Vector2 _position, int _health, int _frameHeight )
        {
            Sprite = _sprite;
            Position = _position;
            Health = _health;
            FrameHeight = _frameHeight;
            rectangle = new Rectangle(Sprite.Width, Sprite.Height, Health, FrameHeight);

        }
        public void Update(GameTime gameTime)
        {
            Damaged(1);
            rectangle = new Rectangle(Sprite.Width, Sprite.Height, Health, FrameHeight);
        }

        public void Damaged(int damage)
        {
            Health-= damage;
        }
         public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite,rectangle,Color.White);
        }




         public int hitPoint { get; set; }
    }
}
