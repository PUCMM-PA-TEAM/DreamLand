using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DreamLand.GameObject
{
    class Sprite
    {
        public Texture2D Texture { get; set; }
        
        public int Width {
            get { return Texture.Width; }
        }

        public int Height {
            get { return Texture.Height; }
        }

        public Sprite(Texture2D texture)
        {
            Texture = texture;
        }
    }
}
