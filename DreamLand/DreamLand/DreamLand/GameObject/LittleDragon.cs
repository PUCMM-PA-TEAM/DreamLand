using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DreamLand.GameObject {
    class LittleDragon : Enemy{

        public List<Projectile> Projectiles;

        public LittleDragon(Sprite sprite, Vector2 position) : base(sprite, position){
            Projectiles = new List<Projectile>();

            elapsedTime = 0;
            coldDownTime = 3000;
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsedTime > coldDownTime) {
                elapsedTime = 0;
                AddProjectile();
            }

            UpdateProjectiles(gameTime);
        }

        private void UpdateProjectiles(GameTime gameTime) {
            for (int i = 0; i < Projectiles.Count; i++) {
                Projectiles[i].Update(gameTime);
                if (Projectiles[i].isActive == false)
                    Projectiles.RemoveAt(i);
            }
        }

        public void AddProjectile() {
            Projectile fireball = new Projectile();
            fireball = new Projectile();
            fireball.Sprite = new Sprite(Content.Load<Texture2D>("fireblast"));
            fireball.Position = Position;
            if (AnimationController.Effect == SpriteEffects.None)
                fireball.Direction = -1;
            else {
                fireball.Direction = 1;
            }

            Projectiles.Add(fireball);
        }

        public override void Draw(SpriteBatch spriteBatch){
            base.Draw(spriteBatch);

            for (int i = 0; i < Projectiles.Count; i++) {
                Projectiles[i].Draw(spriteBatch);
            }
        }
    }
}
