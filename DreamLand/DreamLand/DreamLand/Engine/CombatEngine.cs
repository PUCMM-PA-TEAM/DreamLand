using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DreamLand.Classes;
using DreamLand.GameObject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DreamLand.Engine {
    class CombatEngine {
        private SpriteFont _defaultFont;
        private Player _player;
        private Enemy _enemy;

        //private List<Enemy> _enemy;
        private Rectangle rect1;
        private Rectangle rect2;

        private bool _canHit = false;

        private KeyboardState _currentKeyboardState;
        private KeyboardState _previousKeyboardState;

        private int enemyHealth = 100;
        private int playerHealth = 100;

        private int elapsedTime;
        private int coldDownTime;

        public void Initialize(Player player, Enemy enemy, SpriteFont font) {
            _player = player;
            _player.Strength = 50;
            _player.Defense = 10;

            _enemy = enemy;
            _enemy.Strength = 30;
            _enemy.Defense = 3;

            _defaultFont = font;

            elapsedTime = 0;
            coldDownTime = 250;
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
                if (_canHit && tryToHit(_player)) {
                    enemyHealth -= ComputeDamage(_player, _enemy);
                }
            }

            if (_canHit && tryToHit(_enemy)) {

                playerHealth -= ComputeDamage(_enemy, _player);
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
            spriteBatch.DrawString(_defaultFont, "Enemy Health: " + enemyHealth, new Vector2(0, 0), Color.Yellow);

            spriteBatch.DrawString(_defaultFont, "Player Health: " + playerHealth, new Vector2(400, 0), Color.Yellow);
        }
    }
}
