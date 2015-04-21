using DreamLand.GameObject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DreamLand.Scenes
{
    class Castle01 : Scene, IGameObject{
        private Player _player;
        private Game1 _game;

        public Game1 GameProperty {
            get { return _game; }
            set { _game = value; }
        }

        public void Initalize()
        {
            //throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            if (_player.Position.X <= 0){
                _game.showDungeon = false;
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {

        }

        public Player Player {
            get { return _player; }
            set { _player = value; }
        }
       
    }
}
