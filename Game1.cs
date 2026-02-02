using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Assignment_01;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    SpriteFont _textRendering; // Text rendering
    Texture2D _backgroundTexture2d; // Background rendering
    Texture2D _moonTexture2d; // Static image rendering
    Texture2D _playerTexture2d; // Keyboard-controlled movement
    Texture2D _playerRightTexture2d; // Keyboard-controlled movement
    Texture2D _playerLeftTexture2d; // Keyboard-controlled movement
    Rectangle _playerRectangle; // player's position and size
    Texture2D _cloudTexture2d; // Automatic movement of on-screen content
    Rectangle _cloudRectangle; // cloud position
    int cloudDirection = 1; // move right
    float leftBound; // set Boundary
    float rightBound;
    List<Texture2D> _ArrowTexturelist; // arrow list
    Rectangle _arrowRectangle;
    int current = 0;
    
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
        _moonTexture2d = Content.Load<Texture2D>("Moon_Static_Monogame"); // load picture
        _playerTexture2d = Content.Load<Texture2D>("PlayerRight"); // load player, start position(towards right)
        _playerRightTexture2d = Content.Load<Texture2D>("PlayerRight");
        _playerLeftTexture2d = Content.Load<Texture2D>("PlayerLeft");
        _playerRectangle = new Rectangle(0, 300, 72, 125); // define start point
        _cloudTexture2d = Content.Load<Texture2D>("Cloud");
        _cloudRectangle = new Rectangle(0, 22, 120, 59);
        leftBound = 0;
        rightBound = 800 - _cloudTexture2d.Width; // bounces before cloud leaving the screen
        _ArrowTexturelist = new List<Texture2D>();
        for(int i = 0; i < 13; i++)
        {
            _ArrowTexturelist.Add(Content.Load<Texture2D>("Arrow" + i));
        }
        _arrowRectangle = new Rectangle(150, 400, 144, 27);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        var keyBoard = Keyboard.GetState();
        if (keyBoard.IsKeyDown(Keys.Left) || keyBoard.IsKeyDown(Keys.A))
        {
            _playerTexture2d = _playerLeftTexture2d;
            _playerRectangle.X -= 1;
        }
        else if (keyBoard.IsKeyDown(Keys.Right) || keyBoard.IsKeyDown(Keys.D))
        {
            _playerTexture2d = _playerRightTexture2d;
            _playerRectangle.X += 1;
        }
        else if (keyBoard.IsKeyDown(Keys.Up) || keyBoard.IsKeyDown(Keys.W))
        {
            _playerRectangle.Y -= 1;
        }
        else if (keyBoard.IsKeyDown(Keys.Down) || keyBoard.IsKeyDown(Keys.S))
        {
            _playerRectangle.Y += 1;
        }

        _cloudRectangle.X += cloudDirection;

        if (_cloudRectangle.X >= rightBound) // right boundary
        {
            cloudDirection = -1;
        }

        if (_cloudRectangle.X <= leftBound) // left boundary
        {
            cloudDirection = 1;
        }

        if(current >= 12) // arrow
        {
            current = 0;
        }
        else
        {
            current += 1;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        // Print
        _spriteBatch.Begin();
        _spriteBatch.Draw(_backgroundTexture2d, new Rectangle(0, 0, 800, 480), Color.White); // background rendering
        _spriteBatch.Draw(_moonTexture2d, new Vector2(10,0), Color.White); // Static image rendering, moon
        _spriteBatch.DrawString(_textRendering, "Hello, my name is Xun", new Vector2(310, 0), Color.White); // textRendering
        _spriteBatch.Draw(_playerTexture2d, _playerRectangle, Color.White); // draw player
        _spriteBatch.Draw(_cloudTexture2d, _cloudRectangle, Color.White); // draw cloud
        _spriteBatch.Draw(_ArrowTexturelist[current], _arrowRectangle, Color.White); // draw arrow
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
