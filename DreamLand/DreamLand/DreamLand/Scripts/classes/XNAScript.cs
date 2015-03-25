using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DreamLand.Scripts.classes {
    interface XNAScript
    {
        void Init();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);

    }
}
