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

namespace Lab16
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        const int WINDOW_WIDTH = 800;
        const int WINDOW_HEIGHT = 600;

        AudioEngine audioEngine;
        WaveBank waveBank;
        SoundBank soundBank;

        bool startMouseClick = false;

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

            // Load the audio engine
            audioEngine = new AudioEngine(@"Content\Lab16Audio.xgs");
            // Load the wave bank
            waveBank = new WaveBank(audioEngine, @"Content\Wave bank.xwb");
            // Load the sound bank content
            soundBank = new SoundBank(audioEngine, @"Content\Sound bank.xsb");
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

            // Add code to get the current mouse state
            MouseState currentMouseState = Mouse.GetState();
            //Point currentMouseState = new Point(Mouse.GetState().X, Mouse.GetState().Y);
            
            // Add na if statement to check whether the left mouse button is pressed
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                // play the appropriate cue based on which quadrant the mouse is in
                if ((currentMouseState.X <= WINDOW_WIDTH / 2) &&
                    (currentMouseState.Y >= WINDOW_HEIGHT / 2))
                {
                    while (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        soundBank.PlayCue("upperLeft");
                    }
                }
                else if ((currentMouseState.X <= WINDOW_WIDTH / 2) &&
                    (currentMouseState.Y <= WINDOW_HEIGHT / 2))
                {
                    while (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        soundBank.PlayCue("lowerLeft");
                    }
                }
                else if ((currentMouseState.X >= WINDOW_WIDTH / 2) &&
                    (currentMouseState.Y <= WINDOW_HEIGHT / 2))
                {
                    while (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        soundBank.PlayCue("upperRight");
                    }
                }
                else if ((currentMouseState.X >= WINDOW_WIDTH / 2) &&
                    (currentMouseState.Y >= WINDOW_HEIGHT / 2))
                {
                    while (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        soundBank.PlayCue("lowerRight");
                    }
                }
            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
