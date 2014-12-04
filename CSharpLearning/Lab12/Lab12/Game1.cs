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

namespace Lab12
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        const int WINDOW_HEIGHT = 600;
        const int WINDOW_WIDTH = 800;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        TeddyBear teddyBear, newTeddyBear;
        Explosion explosion;

        Random rand = new Random();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;

            IsMouseVisible = true;
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

            // Create a new teddy bear object
            int x_velocity = rand.Next(1, 2);
            int y_velocity = rand.Next(1, 2);
            int x_rand = rand.Next(0, WINDOW_WIDTH);
            int y_rand = rand.Next(0, WINDOW_HEIGHT);

            teddyBear = new TeddyBear(Content, WINDOW_WIDTH, WINDOW_HEIGHT, "teddybear", x_rand, y_rand, new Vector2(x_velocity, y_velocity));
            // Create a new explosion object
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed)
            {
                // Create a new teddy bear object
                int x_velocity = rand.Next(1, 2);
                int y_velocity = rand.Next(1, 2);
                int x_rand = rand.Next(0, WINDOW_WIDTH);
                int y_rand = rand.Next(0, WINDOW_HEIGHT);
                
                teddyBear.Active = true;
                
                teddyBear = new TeddyBear(Content, WINDOW_WIDTH, WINDOW_HEIGHT, "teddybear", x_rand, y_rand, new Vector2(x_velocity, y_velocity));
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
            {
                explosion.Play((teddyBear.DrawRectangle.X + teddyBear.DrawRectangle.Width/2), (teddyBear.DrawRectangle.Y + teddyBear.DrawRectangle.Height/2));
                teddyBear.Active = false;
            }
          

            teddyBear.Update();
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

            spriteBatch.Begin();

            teddyBear.Draw(spriteBatch);
            explosion.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
