using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DreamLand.GameObject {
    class Projectile : IGameObject{

        private Sprite _sprite;
        private bool _active;
        private int _damage;
        private float _speed;
        private Vector2 _position;
        private int elapsedTime;
        private int spawnTime;
        private int _direction;

        public int Direction {
            get { return _direction; }
            set { _direction = value; }
        }


        public Projectile(){
            _active = true;
            _damage = 10;
            _speed = 10f;
            elapsedTime = 0;
            spawnTime = 2500;
            _direction = 1;
        }

        public void Awake(){
           
        }

        public void Update(GameTime gameTime){
            _position.X += _direction*_speed;

            elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsedTime > spawnTime){
                elapsedTime = 0;
                isActive = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(Sprite.Texture, Position, null, Color.White, 0f, new Vector2(0, 300), 0.05f, SpriteEffects.None, 0f);
        }

        public Sprite Sprite{
            get { return _sprite; }
            set { _sprite = value; }
        }

        public bool isActive {
            get { return _active; }
            set { _active = value; }
        }

        public int Damage {
            get { return _damage; }
            set { _damage = value; }
        }

        public Vector2 Position {
            get { return _position; }
            set { _position = value; }
        }
    }
}
