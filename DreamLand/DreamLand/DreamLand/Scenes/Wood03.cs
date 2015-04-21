using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DreamLand.GameObject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DreamLand.Scenes {
    class Wood03 : Scene, IGameObject{
        private Player _player;
        Rectangle DoorRect;
        Rectangle PlayerRect;
        private Game1 game;

        public Game1 GameProperty
        {
            get { return game; }
            set { game = value; }
        }


        public void Initalize(){

        }

        public override void Awake() {
            DoorRect = new Rectangle(300, 360, 150, 320);
            
        }

        public override void Update(GameTime gameTime) {

            PlayerRect = new Rectangle(
                (int)_player.Position.X + 128 / 2,
                (int) _player.Position.Y + 128 / 2, 128, 128);
            
            if(PlayerRect.Intersects(DoorRect) && Keyboard.GetState().IsKeyDown(Keys.Up)){
                GameProperty.showDungeon = true;
            }
            else{
                GameProperty.showDungeon = false;
            }
           
        }

        public override void Draw(SpriteBatch spriteBatch) {

        }

        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }
    }
}
