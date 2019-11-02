#region using
using System;
using System.Collections.Generic;
using System.Linq;
using NLua;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media; 
#endregion

namespace pacman_atari
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static Game1 instance;

        private Vector2 scoreShow;
        public int ghostsPursuing;

        public static readonly int screenWidth = 320;
        public static readonly int screenHeight = 164 + 30;

        //SpriteFont spriteFont;

        Color bgColor = new Color(45, 50, 184);

        Lua luaPacman;
        Lua luaGhostGreen;
        Lua luaGhostLemonade;
        Lua luaGhostWhiteGreen;
        Lua luaGhostYellow;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            instance = this;
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;

            luaPacman = new Lua();
            luaGhostGreen = new Lua();
            luaGhostLemonade = new Lua();
            luaGhostWhiteGreen = new Lua();
            luaGhostYellow = new Lua();

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

            luaPacman.RegisterFunction("Left", Items.pacman, Items.pacman.GetType().GetMethod("Left"));
            luaPacman.RegisterFunction("Up", Items.pacman, Items.pacman.GetType().GetMethod("Up"));
            luaPacman.RegisterFunction("Right", Items.pacman, Items.pacman.GetType().GetMethod("Right"));
            luaPacman.RegisterFunction("Down", Items.pacman, Items.pacman.GetType().GetMethod("Down"));

            luaGhostGreen.RegisterFunction("Left", Items.ghostGreen, Items.ghostGreen.GetType().GetMethod("Left"));
            luaGhostGreen.RegisterFunction("Up", Items.ghostGreen, Items.ghostGreen.GetType().GetMethod("Up"));
            luaGhostGreen.RegisterFunction("Right", Items.ghostGreen, Items.ghostGreen.GetType().GetMethod("Right"));
            luaGhostGreen.RegisterFunction("Down", Items.ghostGreen, Items.ghostGreen.GetType().GetMethod("Down"));

            luaGhostLemonade.RegisterFunction("Left", Items.ghostLemonade, Items.ghostLemonade.GetType().GetMethod("Left"));
            luaGhostLemonade.RegisterFunction("Up", Items.ghostLemonade, Items.ghostLemonade.GetType().GetMethod("Up"));
            luaGhostLemonade.RegisterFunction("Right", Items.ghostLemonade, Items.ghostLemonade.GetType().GetMethod("Right"));
            luaGhostLemonade.RegisterFunction("Down", Items.ghostLemonade, Items.ghostLemonade.GetType().GetMethod("Down"));

            luaGhostWhiteGreen.RegisterFunction("Left", Items.ghostWhiteGreen, Items.ghostWhiteGreen.GetType().GetMethod("Left"));
            luaGhostWhiteGreen.RegisterFunction("Up", Items.ghostWhiteGreen, Items.ghostWhiteGreen.GetType().GetMethod("Up"));
            luaGhostWhiteGreen.RegisterFunction("Right", Items.ghostWhiteGreen, Items.ghostWhiteGreen.GetType().GetMethod("Right"));
            luaGhostWhiteGreen.RegisterFunction("Down", Items.ghostWhiteGreen, Items.ghostWhiteGreen.GetType().GetMethod("Down"));

            luaGhostYellow.RegisterFunction("Left", Items.ghostYellow, Items.ghostYellow.GetType().GetMethod("Left"));
            luaGhostYellow.RegisterFunction("Up", Items.ghostYellow, Items.ghostYellow.GetType().GetMethod("Up"));
            luaGhostYellow.RegisterFunction("Right", Items.ghostYellow, Items.ghostYellow.GetType().GetMethod("Right"));
            luaGhostYellow.RegisterFunction("Down", Items.ghostYellow, Items.ghostYellow.GetType().GetMethod("Down"));

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

            try
            {
                luaPacman["ghostsPursuing"] = ghostsPursuing;
                luaPacman["position"] = Items.pacman.position;
                luaPacman.DoFile("pacman.lua");

                luaGhostGreen["pacmanPosition"] = Items.pacman.position;
                luaGhostGreen["position"] = Items.ghostGreen.position;
                luaGhostGreen["isAlive"] = Items.ghostGreen.IsAlive();
                luaGhostGreen.DoFile("ghost-green.lua");

                luaGhostLemonade["pacmanPosition"] = Items.pacman.position;
                luaGhostLemonade["position"] = Items.ghostLemonade.position;
                luaGhostLemonade["isAlive"] = Items.ghostLemonade.IsAlive();
                luaGhostLemonade.DoFile("ghost-lemonade.lua");

                luaGhostWhiteGreen["pacmanPosition"] = Items.pacman.position;
                luaGhostWhiteGreen["position"] = Items.ghostWhiteGreen.position;
                luaGhostWhiteGreen["isAlive"] = Items.ghostWhiteGreen.IsAlive();
                luaGhostWhiteGreen.DoFile("ghost-white_green.lua");

                luaGhostYellow["pacmanPosition"] = Items.pacman.position;
                luaGhostYellow["position"] = Items.ghostYellow.position;
                luaGhostYellow["isAlive"] = Items.ghostYellow.IsAlive();
                luaGhostYellow.DoFile("ghost-yellow.lua");
            }
            catch (Exception e) { }

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
