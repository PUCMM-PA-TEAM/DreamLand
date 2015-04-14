using System;
using System.Collections.Generic;
using DreamLand.GameObject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DreamLand.Scenes {
    class Scene
    {
        public List<Texture2D> Stages = new List<Texture2D>();
        private int LEFT_BORDER = 0;
        private int RIGHT_BORDER = 800;

        Rectangle sourceRect = new Rectangle(0, 0, 800, 600);
        Rectangle destionationRect = new Rectangle(0, 0, 800, 540);
        private Texture2D currentStage;

        private int currentFrame = 0;

        public Scene()
        {
            //Initalize();
        }

        public void Initalize()
        {
            currentStage = Stages[0];
        }


        public void Update(GameTime gameTime, Player player)
        {
            if (player.Position.X > RIGHT_BORDER) {
                player.Position = new Vector2(100, 350);
                sourceRect.X += 600;

                if (sourceRect.X > Stages[currentFrame].Width && currentFrame < Stages.Count)
                {
                    currentFrame++;
                    sourceRect.X = 0;
                }
                    
            }

            if (player.Position.X < LEFT_BORDER && currentFrame > 0) {
                player.Position = new Vector2(600, 350);
                sourceRect.X -= 600;

                //if (sourceRect.X > Stages[currentFrame].Width)
                //    currentFrame--;
            }

            currentStage = Stages[currentFrame];
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(currentStage, destionationRect, sourceRect, Color.White);
        }
    }
}
