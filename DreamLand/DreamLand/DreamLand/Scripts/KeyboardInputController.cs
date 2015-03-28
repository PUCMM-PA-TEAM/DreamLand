using System;
using Microsoft.Xna.Framework.Input;
using DreamLand.Scripts.classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DreamLand.Scripts {
    class KeyboardInputController : XNAScript {
        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;

        private float _moveHorizontal;

        public KeyboardInputController(ref float moveHorizontal) {
            _moveHorizontal = moveHorizontal;
        }

        public void Init() {
            //_moveHorizontal = 0;
            throw new NotImplementedException();
        }

        public void Update(ref float speed) {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            // Play Left Animation
            if (currentKeyboardState.IsKeyDown(Keys.Left)) {
                //_moveHorizontal = -1;
                speed = -1;
            }

            // Play Right Animation
            else if (currentKeyboardState.IsKeyDown(Keys.Right)) {
                //_moveHorizontal = 1;
                speed = 1;
            }

            // Play
            else {
                _moveHorizontal = 0;
                speed = 0;
            }
        }

        public void Update(GameTime gameTime) {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            // Play Left Animation
            if (currentKeyboardState.IsKeyDown(Keys.Left)) {
                _moveHorizontal = -1;
            }

            // Play Right Animation
            else if (currentKeyboardState.IsKeyDown(Keys.Right)) {
                _moveHorizontal = 1;
            }

            // Play
            else {
                _moveHorizontal = 0;
            }


        }

        public void Draw(SpriteBatch spriteBatch) {
            throw new NotImplementedException();
        }
    }
}
