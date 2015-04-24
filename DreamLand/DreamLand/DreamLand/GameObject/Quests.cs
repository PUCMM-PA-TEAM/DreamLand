using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DreamLand.GameObject
{
    class Quests
    {

        Texture2D texture;
        Rectangle rectangle;
        private SpriteFont _defaultFont;

        Player _player;


        public void Initialize()
        {
            _defaultFont = Content.Load<SpriteFont>("Courier New");
            texture = Content.Load<Texture2D>("QuestScreen");
            rectangle = new Rectangle(0, 0, texture.Width, texture.Height);
        }

        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
            spriteBatch.DrawString(_defaultFont, "Obtain the Sacred Gem", new Vector2(160, 223), Color.Yellow);
            spriteBatch.DrawString(_defaultFont, "Kill 5 enemies", new Vector2(160, 268), Color.Yellow);
            spriteBatch.DrawString(_defaultFont, "Reach the town", new Vector2(160, 312), Color.Yellow);
            spriteBatch.DrawString(_defaultFont, "[ ]", new Vector2(700, 223), Color.Yellow);
            spriteBatch.DrawString(_defaultFont, "[ ]", new Vector2(700, 268), Color.Yellow);
            spriteBatch.DrawString(_defaultFont, "[ ]", new Vector2(700, 312), Color.Yellow);
     
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
