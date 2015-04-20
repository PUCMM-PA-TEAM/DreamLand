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
    class Wood02 : Scene {
        private Player _player;
        private Enemy _enemy;

        public Wood02() {
        }

        public override void Awake() {

        }

        public override void Update(GameTime gameTime) {
            if (SourceRect.X >= 800) {

                if (_enemy.IsAlive) {
                    Vector2 position = _player.Position;
                    position.X = MathHelper.Clamp(_player.Position.X, 0, 600);
                    _player.Position = position;
                    CheckPlayerProjectileCollision();
                    CheckEnemyProjectileCollision();
                    CheckProjectilesCollision();

                    _enemy.Update(gameTime);
                }

            }
        }

        public void CheckPlayerProjectileCollision() {
            Rectangle rect2 = new Rectangle((int)_enemy.Position.X - 128 / 2,
            (int)_enemy.Position.Y - 128 / 2,
            128, 128);

            for (int i = 0; i < _player.Projectiles.Count; i++) {
                Projectile projectile = _player.Projectiles[i];

                Rectangle rect1 = new Rectangle((int)projectile.Position.X - 100 / 2,
                    (int)projectile.Position.Y - 100 / 2,
                    100, 100);

                if (rect1.Intersects(rect2)) {
                    _enemy.Damaged(projectile.Damage);
                    _player.Projectiles[i].isActive = false;
                }
            }
        }

        public void CheckEnemyProjectileCollision() {
            Rectangle rect2 = new Rectangle((int)_player.Position.X - 128 / 2,
            (int)_player.Position.Y - 128 / 2,
            128, 128);

            for (int i = 0; i < _enemy.Projectiles.Count; i++) {
                Projectile projectile = _enemy.Projectiles[i];

                Rectangle rect1 = new Rectangle((int)projectile.Position.X - 100 / 2,
                    (int)projectile.Position.Y - 100 / 2,
                    100, 100);

                if (rect1.Intersects(rect2)) {
                    _player.Damaged(projectile.Damage);
                    _enemy.Projectiles[i].isActive = false;
                }
            }
        }

        public void CheckProjectilesCollision() {
            for (int i = 0; i < _enemy.Projectiles.Count; i++) {
                Projectile enemyProjectile = _enemy.Projectiles[i];

                for (int j = 0; j < _player.Projectiles.Count; j++) {
                    Projectile playerProjectile = _player.Projectiles[i];

                    Rectangle rect1 = new Rectangle((int)playerProjectile.Position.X,
                    (int)playerProjectile.Position.Y,
                    100, 100);

                    Rectangle rect2 = new Rectangle((int)_player.Position.X,
                    (int)_player.Position.Y,
                    100, 100);

                    if (rect1.Intersects(rect2)) {
                        _player.Projectiles.RemoveAt(j);
                        _enemy.Projectiles.RemoveAt(i);
                    }

                }



            }
        }

        public override void Draw(SpriteBatch spriteBatch) {

            if (SourceRect.X >= 800) {
                if (Enemy.IsAlive)
                    Enemy.Draw(spriteBatch);
            }
        }

        public Enemy Enemy {
            get { return _enemy; }
            set { _enemy = value; }
        }

        public Player Player {
            get { return _player; }
            set { _player = value; }
        }
    }
}
