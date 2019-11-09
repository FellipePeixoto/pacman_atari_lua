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

namespace pacman_atari
{
    class Ghost : Moveable
    {
        private Vector2 diff = new Vector2(15, 15);
        private Animation animation;

        public Ghost(Vector2 position, float speed, String textureName)
        {
            this.isGhost = true;
            this.position = position;
            this.speed = speed;
            this.textureName = textureName;
            isAlive = true;

            debugTextureName = string.Empty;

            scale = 1;

            actualDirection = GlobalEnums.Direction.stopped;

            spriteEffects = SpriteEffects.None;

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

            CheckCollisionWithPacman();

            newPos = position - diff;

            Move();

            animation.position = position;
            animation.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isAlive)
            {
                animation.Draw(spriteBatch, center, true, spriteEffects);
            }
        }

        public void CheckCollisionWithPacman()
        {
            Rectangle pacman = new Rectangle((int)Items.pacman.position.X, (int)Items.pacman.position.Y, size, size);
            Rectangle ghost = new Rectangle((int)position.X,(int)position.Y,size,size);

            if (ghost.Intersects(pacman))
            {
                Game1.isRunning = false;
            }
        }
    }
}
