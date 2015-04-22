using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace DreamLand.GameObject
{
    class Status
    {

        Texture2D texture;
        Rectangle rectangle;
        private SpriteFont _defaultFont;
        Player _player;



        public void Initialize()
        {
            _defaultFont= Content.Load<SpriteFont>("Courier New");
            texture = Content.Load<Texture2D>("StatusBack");
            rectangle = new Rectangle(0, 0, texture.Width, texture.Height);
        }

        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
            spriteBatch.DrawString(_defaultFont, "" + _player.Health, new Vector2(220, 223), Color.Yellow);
            spriteBatch.DrawString(_defaultFont, "" + _player.Defense, new Vector2(260, 268), Color.Yellow);
            spriteBatch.DrawString(_defaultFont, "" + _player.Speed, new Vector2(220, 312), Color.Yellow);
            spriteBatch.DrawString(_defaultFont, "" + _player.Level, new Vector2(210, 363), Color.Yellow);
            spriteBatch.DrawString(_defaultFont, "" + _player.Strength, new Vector2(620,221), Color.Yellow);
            spriteBatch.DrawString(_defaultFont, "" + _player.Strength, new Vector2(620, 271), Color.Yellow);
            spriteBatch.DrawString(_defaultFont, "" + _player.Magic, new Vector2(570, 312), Color.Yellow);


        }

        private ContentManager content;

        public ContentManager Content
        {
            get { return content; }
            set { content = value; }
        }

        public Player Player
        {
            get { return _player; }
            set { _player = value; }

        }
    }
}
