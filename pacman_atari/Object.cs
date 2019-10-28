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
    class Object
    {
        protected Texture2D texture;

        protected String textureName;

        protected Vector2 position;

        protected float scale;

        protected Vector2 center;

        protected float speed;

        protected Rectangle colliderDetection;

        protected bool isAlive = false;

        protected String debugTextureName = String.Empty;

        protected Texture2D debugTexture;

        #region XNA framework methods
        public virtual void LoadContent(ContentManager content)
        {
            // load da textura
            this.texture = content.Load<Texture2D>(textureName);
            if (debugTextureName != String.Empty)
                this.debugTexture = content.Load<Texture2D>(debugTextureName);
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
        #endregion
    }
}
