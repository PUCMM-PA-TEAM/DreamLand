using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DreamLand.Scripts
{
    class Name
    {

        private SpriteFont _defaultFont;
        Texture2D texture;
        Rectangle rectangle;

        private ContentManager content;

        public ContentManager Content
        {
            get { return content; }
            set { content = value; }
        }



        public void Initialize()
        {
            _defaultFont = Content.Load<SpriteFont>("Courier New");
            texture = Content.Load<Texture2D>("CharacterName");
            rectangle = new Rectangle(0, 0, texture.Width, texture.Height);
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBach)
        {
            spriteBach.Draw(texture, rectangle, Color.White);
            spriteBach.DrawString(_defaultFont, "Before starting your journey, name you character:", new Vector2(290, 250), Color.Yellow);


        }
    }
}
