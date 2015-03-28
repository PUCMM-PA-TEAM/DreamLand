using System;
using Microsoft.Xna.Framework.Input;
using DreamLand.Scripts.classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DreamLand.Scripts {
    class KeyboardInputController {

        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;

        public void Update(ref float modifier) {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            // Play Left Animation
            if (currentKeyboardState.IsKeyDown(Keys.Left)) {
                modifier = -1;
            }

            // Play Right Animation
            else if (currentKeyboardState.IsKeyDown(Keys.Right)) {
                modifier = 1;
            }

            // Play
            else {
                modifier = 0;
            }
        }
    }
}
