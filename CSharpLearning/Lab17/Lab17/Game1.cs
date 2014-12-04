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

namespace Lab17
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

        const int MOVE_ON_UPDATE = 10;

        Texture2D texture;
        Rectangle drawRectangle;

        // keep track of how many times the player moves off the screen
        int offScreenCount = 0;

        SpriteFont fontSprite;
        Vector2 textPosition = new Vector2(50, 50);


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

            // Load the texture
            texture = Content.Load<Texture2D>("teddybear");
            // Create an appropriate Rectangle object
            drawRectangle = new Rectangle(0, 0, texture.Width, texture.Height);

            // Load the Sprite Font
            fontSprite = Content.Load<SpriteFont>("Arial");
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

            // Get the current keyboard state and put it in a variable
            KeyboardState currentKeyboardState = Keyboard.GetState();

            if ( (currentKeyboardState.IsKeyDown(Keys.A)) || (currentKeyboardState.IsKeyDown(Keys.Left)) )
            {
                if (drawRectangle.Center.X <= texture.Width/2)
                {
                    drawRectangle.X -= 0;
                    offScreenCount += 1;
                }
                else
                {
                    drawRectangle.X -= MOVE_ON_UPDATE;
                }
                
            }
            else if ((currentKeyboardState.IsKeyDown(Keys.W)) || (currentKeyboardState.IsKeyDown(Keys.Up)))
            {
                if (drawRectangle.Center.Y <= texture.Height/2)
                {
                    drawRectangle.Y -= 0;
                    offScreenCount += 1;
                }
                else
                {
                    drawRectangle.Y -= MOVE_ON_UPDATE;
                }
            }
            else if ((currentKeyboardState.IsKeyDown(Keys.S)) || (currentKeyboardState.IsKeyDown(Keys.Down)))
            {
                if (drawRectangle.Center.Y >= (WINDOW_HEIGHT - texture.Height/2))
                {
                    drawRectangle.Y += 0;
                    offScreenCount += 1;
                }
                else
                {
                    drawRectangle.Y += MOVE_ON_UPDATE;
                }
            }
            else if ((currentKeyboardState.IsKeyDown(Keys.D)) || (currentKeyboardState.IsKeyDown(Keys.Right)))
            {
                if (drawRectangle.Center.X >= (WINDOW_WIDTH - texture.Width/2))
                {
                    drawRectangle.X += 0;
                }
                else
                {
                    drawRectangle.X += MOVE_ON_UPDATE;
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

            spriteBatch.Begin();

            spriteBatch.Draw(texture, drawRectangle, Color.White);
            spriteBatch.DrawString(fontSprite, "Number of times off the screen: " + offScreenCount, textPosition, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
