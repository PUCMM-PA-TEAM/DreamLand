using System;
using Microsoft.Xna.Framework.Graphics;

namespace DreamLand.Scripts {
    class Sprite
    {
        public Texture2D Texture { get; set; }
        public int Width { get { return Texture.Width; } }
        public int Heigth { get { return Texture.Height; } }

        public Sprite(Texture2D texture)
        {
            Texture = texture;
        }
    }
}
