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


namespace RubberChicken
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        const int WINDOW_HEIGHT = 600;
        const int WINDOW_WIDTH = 800;

        const int NUM_CHICKEN = 20;
        const int CHICKEN_DAMAGE = 50;

        // sprites saved for efficiancy
        Texture2D chickenSprite;
        Texture2D bearSprite;
        Texture2D explosionSpriteStrip;

        // game entitles
        List<RubberChicken> chickens = new List<RubberChicken>(NUM_CHICKEN);
        List<TeddyBear> bears = new List<TeddyBear>();
        List<Explosion> explosions = new List<Explosion>();

        // teddy bear spawn support
        const float TEDDY_BEAR_SPEED = 0.2F;
        const int TOTAL_SPAWN_MILLISECONDS = 2000;
        int elapsedSpawnMilliseconds = 0;
        Random rand = new Random();

        const int RUBBER_CHICKEN_DAMAGE = 100;

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

            // create rubber chicken
            //rubberChicken = new RubberChicken(
            //    Content.Load<Texture2D>("rubberchicken"),
            //    new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2),
            //    RUBBER_CHICKEN_DAMAGE);

            // load assets
            chickenSprite = Content.Load<Texture2D>("rubberchicken");
            bearSprite = Content.Load<Texture2D>("teddybear");
            explosionSpriteStrip = Content.Load<Texture2D>("explosion");

            // spawn initial rubber chicken
            SpawnInitialRubberChickens();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO:           
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
            MouseState mouse = Mouse.GetState();
            foreach (RubberChicken chicken in chickens)
            {
                chicken.Update(gameTime, mouse);
            }
            foreach (TeddyBear bear in bears)
            {
                bear.Update(gameTime);
            }
            foreach (Explosion explosion in explosions)
            {
                explosion.Update(gameTime);
            }

            // check for collisions between chickens and teddies
            // Using nested loops. Need outer for loop because we might add chickens
            for (int i = 0; i < chickens.Count; i++)
            {
                foreach (TeddyBear bear in bears)
                {
                    if (chickens[i].Active &&
                        bear.Active &&
                        chickens[i].CollisionRectangle.Intersects(bear.CollisionRectangle))
                    {
                        // detected collision, apply damage to bear and explode as appropriate
                        // Added health field and TakeDamage methods to TeddyBear
                        bear.TakeDamage(chickens[i].Damage);
                        if (!bear.Active)
                        {
                            // Changed explosion class to start playing on creation
                            explosions.Add(new Explosion(explosionSpriteStrip,
                                bear.CollisionRectangle.Center.X,
                                bear.CollisionRectangle.Center.Y));
                        }

                        // explode chicken and spawn new chicken at start location of this one
                        // Cool bug when I tried testing with above in place but not this code
                        // Added GetChickenStartY here (duplicated code in multiple places)
                        //chickens[i].Active = false;
                        //explosions.Add(new Explosion(explosionSpriteStrip,
                        //    chickens[i].CollisionRectangle.Center.X,
                        //    chickens[i].CollisionRectangle.Center.Y));
                        //chickens.Add(new RubberChicken(chickenSprite,
                        //    new Vector2(chickens[i].CollisionRectangle.Center.X,
                        //        GetChickenStartY()), CHICKEN_DAMAGE));

                    }
                }
            }

            
            // spawn teddy as appropriate
            elapsedSpawnMilliseconds += gameTime.ElapsedGameTime.Milliseconds;
            if (elapsedSpawnMilliseconds >= TOTAL_SPAWN_MILLISECONDS)
            {
                elapsedSpawnMilliseconds = 0;

                // Added a new constructor for providing sprote and velocity
                // TeddyBear constructors should be cleaned up!
                // Turned off teddy bouncing for this game ;)
                bears.Add(new TeddyBear(bearSprite, rand.Next(WINDOW_WIDTH - bearSprite.Width + 1),
                    -bearSprite.Height / 2,
                    new Vector2(0, TEDDY_BEAR_SPEED),
                    WINDOW_HEIGHT,WINDOW_HEIGHT));
            }


            // check for chicken leaving window
            foreach (RubberChicken chicken in chickens)
            {
                if (chicken.CollisionRectangle.Bottom < 0)
                {
                    chicken.Reset(GetChickenStartY());
                }
            }

            // check for teddy leaving window
            foreach (TeddyBear bear in bears)
            {
                if (bear.CollisionRectangle.Top > WINDOW_HEIGHT)
                {
                    bear.Active = false;
                }
            }

            // clean out dead teddies NOT WORKING
            //for (int i = bears.Count - 1; i > 0; i--)
            //{
            //    if (!explosions[i].Active)
            //    {
            //        bears.RemoveAt(i);
            //    }
            //}

                base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // draw the rubber chicken
            spriteBatch.Begin();

            //rubberChicken.Draw(spriteBatch);
            foreach (RubberChicken chicken in chickens)
            {
                chicken.Draw(spriteBatch);
            }
            foreach (TeddyBear bear in bears)
            {
                bear.Draw(spriteBatch);
            }
            foreach (Explosion explosion in explosions)
            {
                explosion.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        #region Private Method

        private void SpawnInitialRubberChickens()
        {
            // use rubber chicken width for horizontal placement
            int xSpacing = WINDOW_WIDTH / NUM_CHICKEN;
            int currentX = xSpacing / 2;

            // spawn the chickens
            int y = GetChickenStartY();
            for (int i = 0; i < NUM_CHICKEN; i++)
            {
                chickens.Add(new RubberChicken(chickenSprite, new Vector2(currentX, y), CHICKEN_DAMAGE));
                currentX += xSpacing;
            }

        }

        private int GetChickenStartY()
        {
            return WINDOW_HEIGHT - chickenSprite.Height / 2;
        }

        #endregion

    }
}
