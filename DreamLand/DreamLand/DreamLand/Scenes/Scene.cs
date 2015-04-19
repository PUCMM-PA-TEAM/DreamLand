using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DreamLand.Scenes {
    abstract class Scene
    {
        private Rectangle _sourceRect;
        private Texture2D _texture2D;
        private ContentManager _content;

        public Texture2D Sprite
        {
            get { return _texture2D;}
            set { _texture2D = value; }
        }

        public virtual void Init()
        {
            
        }

        public virtual void Update(GameTime gameTime)
        {
            
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            
        }

        public Rectangle SourceRect {
            get { return _sourceRect; }
            set { _sourceRect = value; }
        }

        public ContentManager Content
        {
            get { return _content;}
            set { _content = value; }
        }
    }
}
