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
    class Animation
    {
        private float scale;
        private int elapsedTime;
        private int frameTime;
        private int currentFrame;
        private Color color;
        private Rectangle sourceRect = new Rectangle();

        public Rectangle destinationRect = new Rectangle();
        public Texture2D spriteTire;
        public int frameCount;
        public int frameWidth;
        public int frameHeight;
        public bool isActive;
        public bool isLooping;
        public Vector2 position;

        public void Inatialize(Texture2D texture, Vector2 position, int frameWidth, int frameHeight, 
            int frameCount, int frameTime, Color color, float scale, bool isLooping, int StartFrame)
        {
            this.spriteTire = texture;
            this.position = position;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.frameCount = frameCount;
            this.frameTime = frameTime;
            this.color = color;
            this.scale = scale;
            this.isLooping = isLooping;

            elapsedTime = 0;

            currentFrame = StartFrame;
            isActive = true;
        }

        public void Update(GameTime gameTime)
        {
            if (!isActive)
                return;

            elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (elapsedTime > frameTime)
            {
                currentFrame++;

                if (currentFrame == frameCount)
                {
                    currentFrame = 0;

                    if (!isLooping)
                        isActive = false;
                }

                elapsedTime = 0;
            }

            sourceRect = new Rectangle(currentFrame * frameWidth, 0, frameWidth, frameHeight);
            destinationRect = new Rectangle((int)position.X - (int)(frameWidth * scale) / 2,
                (int)position.Y - (int)(frameHeight * scale) / 2,
                (int)(frameWidth * scale),
                (int)(frameHeight * scale));
        }

        public void Draw(SpriteBatch spriteBacth, Vector2 orign, bool walking, SpriteEffects spriteEffects)
        {
            if (isActive)
            {
                if (!walking)
                    sourceRect = new Rectangle(0, 0, frameWidth, frameHeight);

                spriteBacth.Draw(spriteTire, destinationRect, sourceRect, color, 0, orign, spriteEffects, 0);
            }
        }
    }
}
