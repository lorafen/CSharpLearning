using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RubberChicken
{
    /// <summary>
    /// An animated explosion object
    /// </summary>
    public class Explosion
    {
        #region Fields

        // object location
        Rectangle drawRectangle;

        // animation strip info
        const string STRIP_NAME = "explosion";
        Texture2D strip;
        int frameWidth;
        int frameHeight;

        // hard-coded animation info. There are better ways to do this, we just
        // don't know enough to use them yet
        const int FRAMES_PER_ROW = 3;
        const int NUM_ROWS = 3;
        const int NUM_FRAMES = 9;

        // fields used to track and draw animations
        Rectangle sourceRectangle;
        int currentFrame;
        const int FRAME_TIME = 10;
        int elapsedFrameTime = 0;

        // active or not
        bool active = true;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a new explosion object and starts playing it at the given location
        /// </summary>
        /// <param name="strip">sprite strip for the explosion</param>
        /// <param name="x">x location for the center of the explosion</param>
        /// <param name="y">y location for the center of the explosion</param>
        public Explosion(Texture2D strip, int x, int y)
        {
            this.strip = strip;

            // initialize and play explosion
            Initialize();
            Play(x, y);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets whether or not the explosion is active
        /// </summary>
        public bool Active
        {
            get { return active;  }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Updates the explosion. This only has an effect if the explosion animation is active
        /// </summary>
        /// <param name="gameTime">game time</param>
        public void Update(GameTime gameTime)
        {
            if (active)
            {
                // check for advancing animation frame
                elapsedFrameTime += gameTime.ElapsedGameTime.Milliseconds;
                if (elapsedFrameTime > FRAME_TIME)
                {
                    // reset frame timer
                    elapsedFrameTime = 0;

                    // advance the animation
                    if (currentFrame < NUM_FRAMES - 1)
                    {
                        currentFrame++;
                        SetSourceRectangleLocation(currentFrame);
                    }
                    else
                    {
                        // reached the end of the animation
                        active = false;
                    }
                }
            }
        }

        /// <summary>
        /// Draws the explosion. This only has an effect if the explosion animation is active
        /// </summary>
        /// <param name="spriteBatch">spritebatch</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (active)
            {
                spriteBatch.Draw(strip, drawRectangle, sourceRectangle, Color.White);
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Initializes the explosion
        /// </summary>
        private void Initialize()
        {
            // calculate frame size
            frameWidth = strip.Width / FRAMES_PER_ROW;
            frameHeight = strip.Height / NUM_ROWS;

            // set initial draw and source rectangles
            drawRectangle = new Rectangle(0, 0, frameWidth, frameHeight);
            sourceRectangle = new Rectangle(0, 0, frameWidth, frameHeight);
        }

        /// <summary>
        /// Sets the source rectangle location to correspond with the given frame
        /// </summary>
        /// <param name="frameNumber">the frame number</param>
        private void SetSourceRectangleLocation(int frameNumber)
        {
            // calculate X and Y based on frame number
            sourceRectangle.X = (frameNumber % FRAMES_PER_ROW) * frameWidth;
            sourceRectangle.Y = (frameNumber / FRAMES_PER_ROW) * frameHeight;
        }

        /// <summary>
        /// Starts playing the animation for the explosion
        /// </summary>
        /// <param name="x">x location for the center of the explosion</param>
        /// <param name="y">y location for the center of the explosion</param>
        private void Play(int x, int y)
        {
            // reset tracking values
            elapsedFrameTime = 0;
            currentFrame = 0;

            // set draw location and source rectangle
            drawRectangle.X = x - frameWidth / 2;
            drawRectangle.Y = y - frameWidth / 2;
            SetSourceRectangleLocation(currentFrame);
        }

        #endregion
 
    }
}
