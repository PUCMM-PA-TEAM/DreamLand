using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using DreamLand.Engine;
using DreamLand.GameObject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DreamLand.Scenes {
    class Wood02 : Scene
    {
        private Player _player;
        private Enemy _enemy;
        private CombatEngine _combat;

        public override void Init() {
            _combat = new CombatEngine();
            _combat.Initialize(_player, _enemy);
        }

        public override void Update(GameTime gameTime) {
            if (SourceRect.X >= 800) {

                if (_enemy.IsAlive){
                    Vector2 position = _player.Position;
                    position.X = MathHelper.Clamp(_player.Position.X, 0, 600);
                   _player.Position = position;
                }

                _enemy.Update(gameTime);
                _combat.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch) {

            if (SourceRect.X >= 800) {
                if(_enemy.Health > 0 && Enemy.IsAlive)
                Enemy.Draw(spriteBatch);
            }
        }

        public Enemy Enemy
        {
            get { return _enemy; }
            set { _enemy = value; }
        }

       public Player Player{
            get { return _player; }
            set { _player = value; }
        }
    }
}
