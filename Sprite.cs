using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Sprite
    {
        public Texture2D texture;
        public Vector2 position;
        public float speed = 0f;

        public Sprite(Texture2D texture)
        {
            this.texture = texture;
        }

        public void Update()
        {
            if (speed <= 0) return;
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                position.Y -= speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                position.Y += speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                position.X -= speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                position.X += speed;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture,position,Color.White);
        }


        //Check Collision
        public bool checkLeftSide(Sprite sprite)
        {
            return this.position.X < sprite.position.X + sprite.texture.Width &&
                this.position.Y < sprite.position.Y + sprite.texture.Height &&
                this.position.Y + texture.Height > sprite.position.Y;
        }

        public bool checkRightSide(Sprite sprite)
        {
            return this.position.X + texture.Width > sprite.position.X &&
                this.position.Y < sprite.position.Y + sprite.texture.Height &&
                this.position.Y + texture.Height > sprite.position.Y;
        }

        public bool checkTopSide(Sprite sprite)
        {
            return this.position.Y < sprite.position.Y + sprite.texture.Height &&
                this.position.X < sprite.position.X + sprite.texture.Width &&
                this.position.X + texture.Width > sprite.position.X;
        }

        public bool checkBottomSide(Sprite sprite)
        {
            return this.position.Y + texture.Height > sprite.position.Y &&
                this.position.X < sprite.position.X + sprite.texture.Width &&
                this.position.X + texture.Width > sprite.position.X;
        }

        public bool checkCollision(Sprite sprite)
        {
            return (checkBottomSide(sprite) && checkLeftSide(sprite) && checkRightSide(sprite) && checkTopSide(sprite));
        }
    }
}
