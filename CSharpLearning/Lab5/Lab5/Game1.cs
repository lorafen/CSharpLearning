using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Lab5
{
    /// <summary>
    /// XNA Basics
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D picture0;
        Texture2D picture1;
        Texture2D picture2;

        Rectangle drawRectangle0;
        Rectangle drawRectangle1;
        Rectangle drawRectangle2;

        public Game1()
        {
            const int WINDOW_WIDTH = 800;
            const int WINDOW_HEIGHT = 600;

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
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

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load the three sprites
            picture0 = Content.Load<Texture2D>("teddybear0");
            picture1 = Content.Load<Texture2D>("teddybear1");
            picture2 = Content.Load<Texture2D>("teddybear2");

            // Create the draw rectangles for each sprites
            drawRectangle0 = new Rectangle(0, 0, picture0.Width, picture0.Height);
            drawRectangle1 = new Rectangle(50, 50, picture1.Width, picture1.Height);
            drawRectangle2 = new Rectangle(100, 100, picture2.Width, picture2.Height);

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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Draw each of the sprites
            spriteBatch.Begin();

            spriteBatch.Draw(picture0, drawRectangle0, Color.White);
            spriteBatch.Draw(picture1, drawRectangle1, Color.White);
            spriteBatch.Draw(picture2, drawRectangle2, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
