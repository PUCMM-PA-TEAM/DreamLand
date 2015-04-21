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
        Rectangle rectangle;

        SceneTransition _world;

        public void Initalize(){
            throw new NotImplementedException();
        }


        public override void Awake() {

        }

        public override void Update(GameTime gameTime) {

            rectangle = new Rectangle(300, 360, 150, 320);

            //if( || Keyboard.GetState().IsKeyDown(Keys.Up))
            //{
            //    _world.Scenes.Add(new Castle01()
            //    {

            //        Sprite = Content.Load<Texture2D>("dungeon 03"),
            //        Content = this.Content
            //    }
            //    );
            //    _world.Scenes.Add(new Castle02()
            //    {

            //        Sprite = Content.Load<Texture2D>("dungeon 02"),
            //        Content = this.Content
            //    }
            //       );
            //    _world.Scenes.Add(new Castle03()
            //    {

            //        Sprite = Content.Load<Texture2D>("dungeon 01"),
            //        Content = this.Content
            //    }
            //      );
            //}
            

        }

        public override void Draw(SpriteBatch spriteBatch) {

        }

        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        public SceneTransition SceneTransition
        {
            get { return _world; }
            set { _world = value; }
        }
    }
}
