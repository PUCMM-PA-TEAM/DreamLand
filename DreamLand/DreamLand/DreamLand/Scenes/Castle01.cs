using DreamLand.GameObject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DreamLand.Engine;

namespace DreamLand.Scenes
{
    class Castle01 : Scene, IGameObject{
        private Player _player;
        private Game1 _game;
        public Enemy Orc1;
        private CombatSystem combatSystem;

        public Game1 GameProperty {
            get { return _game; }
            set { _game = value; }
        }

        public override void Awake(){
            combatSystem = new CombatSystem();
            combatSystem.Content = Content;
            //combatSystem.explosionTexture = Content.Load<Texture2D>("explosion");
            combatSystem.Initialize(_player, Orc1);
        }

        public override void Update(GameTime gameTime)
        {
            if (_player.Position.X <= 0){
                _game.showDungeon = false;
            }

            //First Sceen
            if (SourceRect.X <= 600){
                if (Orc1.IsAlive){
                    Orc1.Update(gameTime);

                    combatSystem.Update(gameTime);
                    //CheckPlayerProjectileCollision();
                    //CheckEnemyProjectileCollision();
                    //CheckProjectilesCollision();
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (SourceRect.X <= 800) {
                if (Orc1.IsAlive){
                    Orc1.Draw(spriteBatch);
                    combatSystem.Draw(spriteBatch);
                }

            }
        }

        public Player Player {
            get { return _player; }
            set { _player = value; }
        }

        //public void CheckPlayerProjectileCollision() {
        //    Rectangle rect2 = new Rectangle((int)Orc1.Position.X - 128 / 2,
        //    (int)Orc1.Position.Y - 128 / 2,
        //    128, 128);


        //    for (int i = 0; i < _player.Projectiles.Count; i++) {
        //        Projectile projectile = _player.Projectiles[i];

        //        Rectangle rect1 = new Rectangle((int)projectile.Position.X - 100 / 2,
        //            (int)projectile.Position.Y - 100 / 2,
        //            100, 100);

        //        if (rect1.Intersects(rect2)) {
        //            Orc1.Damaged(projectile.Damage);
        //            _player.Projectiles[i].isActive = false;
        //        }
        //    }
        //}

        //public void CheckEnemyProjectileCollision() {
        //    Rectangle rect2 = new Rectangle((int)_player.Position.X - 128 / 2,
        //    (int)_player.Position.Y - 128 / 2,
        //    128, 128);

        //    for (int i = 0; i < Orc1.Projectiles.Count; i++) {
        //        Projectile projectile = Orc1.Projectiles[i];

        //        Rectangle rect1 = new Rectangle((int)projectile.Position.X - 100 / 2,
        //            (int)projectile.Position.Y - 100 / 2,
        //            100, 100);

        //        if (rect1.Intersects(rect2)) {
        //            _player.Damaged(projectile.Damage);
        //            Orc1.Projectiles[i].isActive = false;
        //        }

        //    }
        //}

        //public void CheckProjectilesCollision() {

        //    for (int i = 0; i < Orc1.Projectiles.Count; i++) {
        //        Projectile enemyProjectile = Orc1.Projectiles[i];

        //        for (int j = 0; j < _player.Projectiles.Count; j++) {
        //            Projectile playerProjectile = _player.Projectiles[i];

        //            Rectangle rect1 = new Rectangle((int)playerProjectile.Position.X,
        //            (int)playerProjectile.Position.Y,
        //            100, 100);

        //            Rectangle rect2 = new Rectangle((int)enemyProjectile.Position.X,
        //            (int)enemyProjectile.Position.Y,
        //            100, 100);

        //            if (rect1.Intersects(rect2)) {
        //                _player.Projectiles.RemoveAt(j);
        //                Orc1.Projectiles.RemoveAt(i);
        //            }
        //        }
        //    }
   
        //}
    }
}
