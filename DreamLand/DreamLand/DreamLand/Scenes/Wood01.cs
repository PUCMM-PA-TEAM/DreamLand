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
        public override  void  Init () {
            //x.Sprite = new Sprite(Content.Load<Texture2D>("NPC"));
            _mage = new NPC(new Sprite(Content.Load<Texture2D>("Gandalf")),
                new Vector2(300, 360));
            
        }

        public override void  Update(GameTime gameTime) {

            _mage.Update(gameTime);

        }

        public override void  Draw (SpriteBatch spriteBatch) {

            _mage.Draw(spriteBatch);

        }
    }
}
