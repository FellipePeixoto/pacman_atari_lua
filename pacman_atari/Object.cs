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
    class Object
    {
        public Vector2 position;
        protected Texture2D texture;
        protected Texture2D debugTexture;
        protected Vector2 center;
        protected string debugTextureName;
        protected string textureName;
        protected float scale;
        protected float speed;
        protected bool isAlive;

        #region XNA framework methods
        public virtual void LoadContent(ContentManager content)
        {
            // load da textura
            this.texture = content.Load<Texture2D>(textureName);
            if (debugTextureName != string.Empty)
                debugTexture = content.Load<Texture2D>(debugTextureName);
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public bool IsAlive()
        {
            return isAlive;
        }
        #endregion
    }
}
