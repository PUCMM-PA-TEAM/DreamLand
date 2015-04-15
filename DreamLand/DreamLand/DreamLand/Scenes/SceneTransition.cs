using System;
using System.Collections.Generic;
using DreamLand.GameObject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DreamLand.Scenes {
    class SceneTransition
    {
        public List<Scene> Scenes = new List<Scene>(); 
        private static int LEFT_BORDER = 0;
        private static int RIGHT_BORDER = 800;
        private static int SCENE_WIDTH = 800;

        Rectangle _sourceRect = new Rectangle(0, 0, SCENE_WIDTH, 600);
        Rectangle _destionationRect = new Rectangle(0, 0, SCENE_WIDTH, 540);
        private Texture2D _currentSprite;
        private int _currentScene = 0;

        public SceneTransition()
        {
            //Initalize();
        }

        public void Initalize()
        {
            _currentSprite = Scenes[0].Sprite;
            Scenes[0].Init();
        }


        public void Update(GameTime gameTime, Player player)
        {
   
            if (player.Position.X > RIGHT_BORDER) {

                player.Position = new Vector2(100, 350);
                _sourceRect.X += SCENE_WIDTH;

                if (_sourceRect.X >= Scenes[_currentScene].Sprite.Width && _currentScene < Scenes.Count)
                {
                    _currentScene++;
                    _sourceRect.X = 0;
                }      
            }

            if (player.Position.X < LEFT_BORDER)
            {
                player.Position = new Vector2(600, 350);
                _sourceRect.X -= SCENE_WIDTH;

                if (_sourceRect.X < 0 && _currentScene > 0) {
                    _currentScene--;
                    _sourceRect.X = SCENE_WIDTH;
                }
            }

            _currentSprite = Scenes[_currentScene].Sprite;
            Scenes[_currentScene].Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_currentSprite, _destionationRect, _sourceRect, Color.White);
            Scenes[_currentScene].Draw(spriteBatch);
        }
    }
}
