using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Basic_Collision_Detection
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Random rand;
        ShapeDrawer shapeDrawer;
        Circle circle1;
        Circle circle2;
        AABB rec1;
        AABB rec2;
        Color circleColor;
        Color recColor;
        bool circleKeyUp = true;
        bool recKeyUp = true;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            rand = new Random();
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
            shapeDrawer = new ShapeDrawer(spriteBatch, GraphicsDevice);
            circle1 = new Circle(200, 200, 10);
            circle2 = new Circle(150, 150, 10);
            rec1 = new AABB(150, 150, 200, 50);
            rec2 = new AABB(400, 150, 200, 50);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Get user input to change circles
            if(Keyboard.GetState().IsKeyDown(Keys.C) && circleKeyUp)
            {
                circle1 = new Circle(rand.Next(0, GraphicsDevice.Viewport.Width), rand.Next(0, GraphicsDevice.Viewport.Height), rand.Next(60, 200));
                circle2 = new Circle(rand.Next(0, GraphicsDevice.Viewport.Width), rand.Next(0, GraphicsDevice.Viewport.Height), rand.Next(60, 200));
                circleKeyUp = false;
            } else if(Keyboard.GetState().IsKeyUp(Keys.C))
            {
                circleKeyUp = true;
            }

            // Get user input to change rectangles
            if (Keyboard.GetState().IsKeyDown(Keys.R) && recKeyUp)
            {
                rec1 = new AABB(rand.Next(0, GraphicsDevice.Viewport.Width), rand.Next(0, GraphicsDevice.Viewport.Height), rand.Next(60, 300), rand.Next(60, 300));
                rec2 = new AABB(rand.Next(0, GraphicsDevice.Viewport.Width), rand.Next(0, GraphicsDevice.Viewport.Height), rand.Next(60, 300), rand.Next(60, 300));
                recKeyUp = false;
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.R))
            {
                recKeyUp = true;
            }

            // Change Circles' color to red if overlapping, white if not
            if (circle1.Intersects(circle2))
            {
                circleColor = Color.Red;
            } else
            {
                circleColor = Color.White;
            }

            // Change Rectangle' color to red if overlapping, white if not
            if (rec1.Intersects(rec2))
            {
                Console.WriteLine("coloring red");
                recColor = Color.Red;
            }
            else
            {
                Console.WriteLine("coloring white");
                recColor = Color.White;
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
            shapeDrawer.DrawCircle((int)circle1.Getx(), (int)circle1.Gety(), (int)circle1.Getradius(), 100, circleColor);
            shapeDrawer.DrawCircle((int)circle2.Getx(), (int)circle2.Gety(), (int)circle2.Getradius(), 100, circleColor);
            shapeDrawer.DrawRectOutline((int)rec1.Getx(), (int)rec1.Gety(), (int)rec1.GetWidth(), (int)rec1.GetHeight(), recColor);
            shapeDrawer.DrawRectOutline((int)rec2.Getx(), (int)rec2.Gety(), (int)rec2.GetWidth(), (int)rec2.GetHeight(), recColor);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
