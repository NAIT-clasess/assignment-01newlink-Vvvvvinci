using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Assignment_01;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    SpriteFont _textRendering; //Text rendering
    Texture2D _backgroundTexture2d; //Background rendering
    Rectangle _backgroundRectangle; //Background rendering
    Texture2D _moonTexture2d; //Static image rendering

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _graphics.PreferredBackBufferWidth = 800; //background, 800x480
        _graphics.PreferredBackBufferHeight = 480;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        _textRendering = Content.Load<SpriteFont>("textRendering"); // Text rendering
        _backgroundTexture2d = Content.Load<Texture2D>("Background_Monogame"); // load background
        _backgroundRectangle = new Rectangle(0, 0, 800, 480); // define size and position of background
        _moonTexture2d = Content.Load<Texture2D>("Moon_Static_Monogame"); // load picture
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        // Print
        _spriteBatch.Begin();
        _spriteBatch.Draw(_backgroundTexture2d, _backgroundRectangle, Color.White); // background rendering
        _spriteBatch.Draw(_moonTexture2d, new Vector2(10,0), Color.White); // Static image rendering, moon
        _spriteBatch.DrawString(_textRendering, "Hello, my name is Xun", new Vector2(310, 0), Color.White); // textRendering
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
