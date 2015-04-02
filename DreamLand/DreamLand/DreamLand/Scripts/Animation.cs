using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace DreamLand.Scripts
{
    class Animation
    {
        private Texture2D SpriteSheet;
        float Scale;
        int elapsedTime;
        int frameTime;
        int frameCount;
        int currentFrame;
        Color Color;
        Rectangle sourceRect = new Rectangle();
        Rectangle destinationRect = new Rectangle();
        public int FrameWidth;
        public int FrameHeight;
        public bool Active;
        public bool Looping;
        public Vector2 Position;

        public List<int> Frames = new List<int>();
        
        public SpriteEffects Effect = SpriteEffects.None;

        public void Initialize(Texture2D texture, Vector2 position,
                                int frameWidth, int frameHeight, int frameCount,
                                int frametime, Color color, float scale, bool looping)
        {
            this.Color = color;
            this.FrameWidth = frameWidth;
            this.FrameHeight = frameHeight;
            this.frameCount = frameCount;
            this.frameTime = frametime;
            this.Scale = scale;

            Looping = looping;
            Position = position;
            SpriteSheet = texture;

            elapsedTime = 0;
            currentFrame = 0;

            Active = true;
        }

        public void Update(GameTime gameTime)
        {
            if (Active == false)
                return;

            elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsedTime > frameTime)
            {
                currentFrame++;
                if (currentFrame == frameCount)
                {
                    currentFrame = 0;
                    if (Looping == false)
                        Active = false;
                }
                elapsedTime = 0;
            }

            sourceRect = new Rectangle(0, Frames[currentFrame], FrameWidth, FrameHeight);

            destinationRect = new Rectangle((int)Position.X - (int)(FrameWidth * Scale) / 2,
            (int)Position.Y - (int)(FrameHeight * Scale) / 2,
            (int)(FrameWidth * Scale),
            (int)(FrameHeight * Scale));

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Active)
            {
                spriteBatch.Draw(
                    SpriteSheet,
                    destinationRect, 
                    sourceRect, 
                    Color, 
                    0f, 
                    Vector2.Zero, 
                    Effect,
                    0f);
                //spriteBatch.Draw(SpriteSheet, destinationRect, sourceRect, Color);
  
            }
        }

    }
}
