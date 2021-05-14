using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Text;

namespace Game4
{
    class BackroundSprite
    {
        Vector2 distance;
        Texture2D image;
        Vector2 firstpos;
        public Vector2 position;
        Color colorz = new Color(255, 168, 210);
        const float _speed = 0.5f;
        //  new Vector2(((backroundsymbols_position.X) + backroundsymbols_velocity.X), backroundsymbols_velocity.Y), backroundsymbols_color)
        //  backroundsymbols_position = new Vector2(-119, 62);
        public BackroundSprite(Vector2 position)
        {
            this.position =  position;
        }
        public void Initialize()
        {
            firstpos = position;
            distance = new Vector2((firstpos.X + 119) + (119 + 720), (firstpos.Y + 62) + (62 + 720));
        }
        public void Update()
        {
            if (position.Y >= distance.Y)
            {
                position = new Vector2(firstpos.X, firstpos.Y);
            }
        }
        public void LoadContent(ContentManager Content)
        {
            image = Content.Load<Texture2D>("SWOONBATTLE/francis_swoon_btl_4itemsymbol");
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(image, position, colorz);
        }
    }
}
