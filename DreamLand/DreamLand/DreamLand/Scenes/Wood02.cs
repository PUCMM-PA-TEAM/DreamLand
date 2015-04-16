using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using DreamLand.GameObject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DreamLand.Scenes {
    class Wood02 : Scene
    {
        private Enemy _enemy;

        public override void Init() {
    
        }

        public override void Update(GameTime gameTime) {

            if (SourceRect.X >= 800) {
                _enemy.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch) {

            if (SourceRect.X >= 800) {
                Enemy.Draw(spriteBatch);
            }
        }

        public Enemy Enemy
        {
            get { return _enemy; }
            set { _enemy = value; }
        }


    }
}
