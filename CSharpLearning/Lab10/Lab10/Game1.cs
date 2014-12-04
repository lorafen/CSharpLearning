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

using ExplodingTeddies;

namespace Lab10
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        const int WINDOW_WIDTH = 800;
        const int WINDOW_HEIGHT = 600;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        TeddyBear teddyBear0;
        TeddyBear teddyBear1;
        
        Explosion explosion;

        public Game1()
        {
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

            // Creating two new teddy bear object
            teddyBear0 = new TeddyBear(Content, WINDOW_WIDTH, WINDOW_HEIGHT, "teddybear0", 10, 100, new Vector2(1, 0));
            teddyBear1 = new TeddyBear(Content, WINDOW_WIDTH, WINDOW_HEIGHT, "teddybear1", 0, 10, new Vector2(1, 1));

            // Creating an explosion object
            explosion = new Explosion(Content);


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

            // Updating  the two teddy bears
            teddyBear0.Update();
            teddyBear1.Update();

            // Explode the teddy bears when they collide
            Rectangle teddyBearRectangle0 = teddyBear0.DrawRectangle;
            Rectangle teddyBearRectangle1 = teddyBear1.DrawRectangle;

            if ((teddyBearRectangle0.X / 2 == teddyBearRectangle1.X / 2) &&
               (teddyBearRectangle0.Y / 2 == teddyBearRectangle1.Y / 2))
            {
                // If there is a collision, teddy bears active is false
                teddyBear0.Active = false;
                teddyBear1.Active = false;
                // Play explosion after collision
                explosion.Play(teddyBearRectangle0.Location.X + 5, teddyBearRectangle0.Location.Y + 5);
                
            }
            explosion.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Drawing teddy bears
            spriteBatch.Begin();

            teddyBear0.Draw(spriteBatch);
            teddyBear1.Draw(spriteBatch);
            explosion.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
