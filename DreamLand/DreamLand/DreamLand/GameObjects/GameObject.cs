using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using DreamLand.Scripts.classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DreamLand.GameObjects {
    class GameObject{
        public Transform Transform { get; set; }

        public virtual void Init()
        {
            
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            
        }

        public virtual void LoadContent(ContentManager content, string texturePath)
        {
            
        }
    }
}
