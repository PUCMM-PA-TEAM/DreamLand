using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace DreamLand.Scripts
{
    class HAnimation
    {
        private Texture2D SpriteSheet;
        float _scale;
        int _elapsedTime;
        int _frameTime;
        int _frameCount;
        int _currentFrame;
        Color _color;
        Rectangle _sourceRect = new Rectangle();
        Rectangle _destinationRect = new Rectangle();
        public int FrameWidth;
        public int FrameHeight;
        public bool Active;
        public bool Looping;
        public Vector2 Position;

        public void Initialize(Texture2D texture, Vector2 position,
                                int frameWidth, int frameHeight, int frameCount,
                                int frametime, Color color, float scale, bool looping)
        {
            _color = color;
            FrameWidth = frameWidth;
            FrameHeight = frameHeight;
            _frameCount = frameCount;
            _frameTime = frametime;
            _scale = scale;

            Looping = looping;
            Position = position;
            SpriteSheet = texture;

            _elapsedTime = 0;
            _currentFrame = 0;

            Active = true;
        }

        public void Update(GameTime gameTime)
        {
            if (Active == false)
                return;

            _elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (_elapsedTime > _frameTime)
            {
                _currentFrame++;
                if (_currentFrame == _frameCount)
                {
                    _currentFrame = 0;
                    if (Looping == false)
                        Active = false;
                }
                _elapsedTime = 0;
            }
            // Grab the correct frame in the image strip by multiplying the _currentFrame index by the frame width
            _sourceRect = new Rectangle(_currentFrame * FrameWidth, 0, FrameWidth, FrameHeight);

            // Grab the correct frame in the image strip by multiplying the _currentFrame index by the frame width
            _destinationRect = new Rectangle((int)Position.X - (int)(FrameWidth * _scale) / 2,
            (int)Position.Y - (int)(FrameHeight * _scale) / 2,
            (int)(FrameWidth * _scale),
            (int)(FrameHeight * _scale));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Active)
            {
                spriteBatch.Draw(SpriteSheet, _destinationRect, _sourceRect, _color);
                //spriteBatch.Draw(
                //    SpriteSheet,
                //    _destinationRect, 
                //    _sourceRect, 
                //    _color, 
                //    0f, 
                //    Vector2.Zero, 
                //    Effect,
                //    0f);
                //spriteBatch.Draw(SpriteSheet, _destinationRect, _sourceRect, _color);
  
            }
        }

    }
}
