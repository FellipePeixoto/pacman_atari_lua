#region using
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
#endregion

namespace Pacman_Atari
{
    class Ghost : Object
    {
        private Animation animation;

        public Ghost(Vector2 position, float speed, String textureName)
        {
            this.position = position;
            this.speed = speed;
            this.textureName = textureName;
            this.isAlive = true;

            this.scale = 1;

            animation = new Animation();
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);

            animation.Inatialize(texture, position, 16, 16, 6, 200, Color.White, scale, true, 0);
            center = new Vector2(animation.frameWidth / 2, animation.frameHeight / 2);
        }

        public override void Update(GameTime gameTime)
        {
            if (!isAlive)
                return;

            animation.position = position;
            animation.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isAlive)
            {
                animation.Draw(spriteBatch, center, true);
            }
        }
    }
}
