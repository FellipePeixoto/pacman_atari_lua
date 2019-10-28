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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Vector2 scoreShow;

        public static readonly int screenWidth = 320;
        public static readonly int screenHeight = 164 + 30;

        //SpriteFont spriteFont;

        Color bgColor = new Color(45, 50, 184);

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;

            scoreShow = new Vector2(screenWidth - 100, screenHeight - 27);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            Items.Initialize();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //spriteFont = Content.Load<SpriteFont>("Fonts/SpriteFont");

            foreach (Object i in Items.objList)
            {
                i.LoadContent(Content);
            }

            foreach (ObjectStatic i in Items.objMovList)
            {
                i.LoadContent(Content);
            }

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            foreach (Object i in Items.objList)
            {
                i.Update(gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(bgColor);

            spriteBatch.Begin();

            // TODO: Add your drawing code here

            foreach (ObjectStatic i in Items.objMovList)
            {
                if (i!=null)
                    i.Draw(spriteBatch);
            }

            foreach (Object i in Items.objList)
            {
                i.Draw(spriteBatch);
            }

            //spriteBatch.DrawString(spriteFont, Pacman.score.ToString(), scoreShow, Color.Red);

            spriteBatch.End();
        }
    }
}
