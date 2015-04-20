using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DreamLand.GameObject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DreamLand.Scenes {
    class Wood01 : Scene
    {
        NPC _mage;
        public override  void  Awake ()
        {
            Sprite sprite = new Sprite(_content.Load<Texture2D>("Gandalf"));
            //x.Sprite = new Sprite(Content.Load<Texture2D>("NPC"));
            _mage = new NPC(sprite,
                new Vector2(300, 360));

        }

        public override void  Update(GameTime gameTime) {
            if(SourceRect.X < 800)
            _mage.Update(gameTime);

        }

        public override void  Draw (SpriteBatch spriteBatch) {
            if (SourceRect.X < 800)
            _mage.Draw(spriteBatch);

        }
    }
}
