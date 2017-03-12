using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RpgTest
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        int timer = 280;
        const int TIMER = 280;

        int jumpTimer = 400;
        const int JUMPTIMER = 400;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D[] groundTextures = new Texture2D[10];
        Rectangle[] groundRectangles = new Rectangle[10];

        Texture2D[] characterIdleRight = new Texture2D[3];
        Texture2D[] characterIdleLeft = new Texture2D[3];
        int charIdleAnimation;
        int charXPosition;
        int charYposition;
        Vector2 charPosition;
        Rectangle charRectangle;
        bool lookingForward;
        int speed;
        int gravity;
        bool canJump;

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

            base.Initialize();
            IsMouseVisible = true;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            for (int i = 0; i < groundTextures.Length; i++)
            {
                groundTextures[i] = Content.Load<Texture2D>("ground");

                Vector2 position = new Vector2(i * 128, 465);

                groundRectangles[i] = new Rectangle((int)position.X, (int)position.Y, 128, 64);
            }

            characterIdleRight[0] = Content.Load<Texture2D>("rogue like idle_Animation 1_0");
            characterIdleRight[1] = Content.Load<Texture2D>("rogue like idle_Animation 1_1");
            characterIdleRight[2] = Content.Load<Texture2D>("rogue like idle_Animation 1_2");
            characterIdleLeft[0] = Content.Load<Texture2D>("rogue like idle_Animation 1_0_2");
            characterIdleLeft[1] = Content.Load<Texture2D>("rogue like idle_Animation 1_1_2");
            characterIdleLeft[2] = Content.Load<Texture2D>("rogue like idle_Animation 1_2_2");
            charIdleAnimation = 0;
            charXPosition = 0;
            charYposition = 380;
            charPosition = new Vector2(charXPosition, charYposition);
            charRectangle = new Rectangle(charXPosition, charYposition, 80, 80);
            lookingForward = true;
            canJump = true;
            speed = 4;
            gravity = 2;
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

            // TODO: Add your update logic here
            charYposition += gravity;
            charPosition.Y = charYposition;
            charRectangle.Y = charYposition;

            int elapsed = (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            timer -= elapsed;
            if (timer < 0)
            {
                charIdleAnimation++;
                //Timer expired, execute action
                timer = TIMER;   //Reset Timer
            }

            //jumpTimer -= elapsed;
            //if (jumpTimer < 0)
            //{
            //    canJump = true;
            //    //Timer expired, execute action
            //    jumpTimer = JUMPTIMER;   //Reset Timer
            //}

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                charXPosition += speed;

                lookingForward = true;
                if (charXPosition > 740)
                {
                    charXPosition = 740;
                }
                charPosition.X = charXPosition;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                charXPosition -= speed;

                lookingForward = false;
                if (charXPosition < 0)
                {
                    charXPosition = 0;
                }
                charPosition.X = charXPosition;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                if (canJump)
                {
                    charYposition -= 8;
                    if (charYposition < 0)
                    {
                        charYposition = 0;
                    }
                    //canJump = false;
                }
                //canJump = false;
                //charPosition.Y = charYposition;
            }

            for (int i = 0; i < groundRectangles.Length; i++)
            {
                if (charRectangle.Intersects(groundRectangles[i]))
                {
                    //charPosition.Y -= gravity;
                    //charRectangle.Y -= gravity;
                    charYposition -= gravity;
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
            spriteBatch.Begin();

            for (int i = 0; i < groundTextures.Length; i++)
            {
                Vector2 position = new Vector2(i * 128, 435);

                spriteBatch.Draw(groundTextures[i], position, Color.AliceBlue);
            }

            if (charIdleAnimation > 2)
            {
                charIdleAnimation = 0;
            }

            if (lookingForward)
            {
                spriteBatch.Draw(characterIdleRight[charIdleAnimation], charPosition, Color.White);
            }
            else
            {
                spriteBatch.Draw(characterIdleLeft[charIdleAnimation], charPosition, Color.White);
            }



            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
