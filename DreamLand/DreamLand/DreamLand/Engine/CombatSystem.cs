using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DreamLand.Classes;
using DreamLand.GameObject;
using DreamLand.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DreamLand.Engine {
    class CombatSystem {
        private SpriteFont _defaultFont;
        private Player _player;
        private Enemy _enemy;
        private List<HAnimation> explosions; 
        //private List<Enemy> _enemy;
        private Rectangle rect1;
        private Rectangle rect2;
        public ContentManager Content { get; set; }
        private bool _canHit = false;

        private KeyboardState _currentKeyboardState;
        private KeyboardState _previousKeyboardState;

        private int elapsedTime;
        private int coldDownTime;

        public void Initialize(Player player, Enemy enemy) {
            _player = player;
            _player.Strength = 50;
            _player.Defense = 10;

            _enemy = enemy;
            _enemy.Strength = 30;
            _enemy.Defense = 3;

            elapsedTime = 0;
            coldDownTime = 250;
            explosions = new List<HAnimation>();
        }

        private void PlayerAttack() {

        }

        private void playerMissed() {

        }

        private void EnemyAttack() {

        }

        private bool tryToHit(Character character) {
            Random random = new Random();
            int attack1 = random.Next(1, 100);
            int defense1 = random.Next(1, 100);

            return (attack1 < character.Strength && defense1 > character.Defense);
        }

        public void Update(GameTime gameTime) {
            _previousKeyboardState = _currentKeyboardState;
            _currentKeyboardState = Keyboard.GetState();

            rect1 = new Rectangle(
                (int)_player.Position.X,
                (int)_player.Position.Y,
                _player.AnimationController.FrameHeight,
                _player.AnimationController.FrameHeight);

            rect2 = new Rectangle(
                (int)_enemy.Position.X,
                (int)_enemy.Position.Y,
                _enemy.AnimationController.FrameHeight,
                _enemy.AnimationController.FrameHeight);

            elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsedTime > coldDownTime && rect1.Intersects(rect2)) {
                _canHit = true;
                elapsedTime = 0;
            } else
                _canHit = false;

            // Player Attack
            if (_currentKeyboardState.IsKeyDown(Keys.X)) {
                if (_canHit && tryToHit(_player) && _enemy.IsAlive) {
                   // _enemy.Health -= ComputeDamage(_player, _enemy);
                    _enemy.Damaged(ComputeDamage(_player, _enemy));
                    AddExplosion(_enemy.Position);
                }
            }

            if (_canHit && tryToHit(_enemy) && _enemy.IsAlive) {

                _player.Damaged(ComputeDamage(_enemy, _player));
                AddExplosion(_player.Position);
               // _player.Damaged(ComputeDamage(_enemy, _player));
            }

            if (_enemy.Health < 0)
                _enemy.IsAlive = false;

            UpdateExplosions(gameTime);
 }
        private void AddExplosion(Vector2 position) {
            HAnimation explosion = new HAnimation();

            explosion.Initialize(explosionTexture, position, 134, 134, 12, 45, Color.White, 1f, false);
            explosions.Add(explosion);
        }

        public Texture2D explosionTexture { get; set; }

        private void UpdateExplosions(GameTime gameTime) {
            for (int i = explosions.Count - 1; i >= 0; i--) {
                explosions[i].Update(gameTime);
                if (explosions[i].Active == false) {
                    explosions.RemoveAt(i);
                }
            }
        }
        private int ComputeDamage(Character attacker, Character other) {
            Random random = new Random();
            int strength = random.Next(
                (int)(attacker.Strength - (attacker.Strength * 0.05f)),
                (int)(attacker.Strength + (attacker.Strength * 0.05f)));

            int defense = random.Next(
                (int)(other.Defense - (other.Defense * 0.05f)),
                (int)(other.Defense + (other.Defense * 0.05f)));

            return (strength - defense);
        }

        public void Draw(SpriteBatch spriteBatch) {
            //spriteBatch.DrawString(_defaultFont, "Enemy Health: " + enemyHealth, new Vector2(0, 0), Color.Yellow);

            //spriteBatch.DrawString(_defaultFont, "Player Health: " + playerHealth, new Vector2(400, 0), Color.Yellow);
            for (int i = 0; i < explosions.Count; i++){
                explosions[i].Draw(spriteBatch);
            }
        }
    }
}
