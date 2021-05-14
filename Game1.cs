using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game4
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        List<BackroundSprite> BackroundSpriteRow = new List<BackroundSprite>();
        List<List<BackroundSprite>> BackroundSpriteRows = new List<List<BackroundSprite>>();
        BackroundSprite BackroundSymbol;
        Color backroundsymbols_color = new Color(255, 168, 210);
        Song song;
        public Vector2 dimentions_of_img = new Vector2(119, 62);
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.PreferredBackBufferWidth = 720;
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            var xadd = 119f;
            for (int i = 0; i < 21; i++)
            {
                BackroundSpriteRow.Add(new BackroundSprite(new Vector2(dimentions_of_img.X += xadd, dimentions_of_img.Y)));
                xadd += 119f;
            }
            for (int i = 0; i < 21; i++)
            {
                foreach (var newBackroundSprite in BackroundSpriteRow)
                {
                    newBackroundSprite.position.Y += 62f;
                }
                BackroundSpriteRows.Add(BackroundSpriteRow);
            }
            foreach (List<BackroundSprite> BackroundRow in BackroundSpriteRows)
            {
                foreach (BackroundSprite backroundSprite in BackroundRow)
                {
                    backroundSprite.Initialize();
                }
            }
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //BackroundSprite(Texture2D newtexture, Vector2 newvector2_startingpos, Vector2 newvector2_velcity, int newincrement, Color newcolor)
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            song = Content.Load<Song>("SWOONBATTLE/2021-05-01 02-13-54");
            foreach (List<BackroundSprite> BackroundRow in BackroundSpriteRows)
            {
                foreach (BackroundSprite backroundSprite in BackroundRow)
                {
                    backroundSprite.LoadContent(this.Content);
                }
            }
            // TODO: use this.Content to load your game content here
            //backroundsymbols dimentions are 119 62
        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            foreach (List<BackroundSprite> BackroundRow in BackroundSpriteRows)
            {
                foreach (BackroundSprite backroundSprite in BackroundRow)
                {
                    backroundSprite.Update();
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(138, 61, 98));
            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            foreach (List<BackroundSprite> BackroundRow in BackroundSpriteRows)
            {
                foreach (BackroundSprite backroundSprite in BackroundRow)
                {
                    backroundSprite.Draw(_spriteBatch);
                }
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
