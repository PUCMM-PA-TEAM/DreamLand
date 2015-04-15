using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DreamLand.Scenes {
    abstract class Scene
    {
        private Texture2D _texture2D;

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
    }
}
