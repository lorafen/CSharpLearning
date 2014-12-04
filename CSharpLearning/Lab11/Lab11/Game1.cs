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

namespace Lab11
{
    /// <summary>
    /// XNA Mouse Input
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        const int WINDOW_HEIGHT = 600;
        const int WINDOW_WIDTH = 800;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        TeddyBear teddyBear;

        Explosion explosion;

        Random random = new Random();

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
            teddyBear = new TeddyBear(Content, WINDOW_WIDTH, WINDOW_HEIGHT, "teddybear", 50, 50, new Vector2(random.Next(1,2), random.Next(1,2)));

            // Create an Explosion object
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

            teddyBear.Update();
            // X = x - w/2; 
            int teddyBearLocationX = teddyBear.DrawRectangle.X + teddyBear.DrawRectangle.Width;
            int teddyBearLocationY = teddyBear.DrawRectangle.Y + teddyBear.DrawRectangle.Height;



            if ((Mouse.GetState().X > teddyBear.DrawRectangle.X) &&
                (Mouse.GetState().X < teddyBearLocationX) &&
                (Mouse.GetState().Y > teddyBear.DrawRectangle.Y) &&
                (Mouse.GetState().Y < teddyBearLocationY) &&
                (Mouse.GetState().LeftButton == ButtonState.Pressed))
            {
                teddyBear.Active = false;
                explosion.Play(teddyBearLocationX, teddyBearLocationY);
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

            spriteBatch.Begin();

            teddyBear.Draw(spriteBatch);
            explosion.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
