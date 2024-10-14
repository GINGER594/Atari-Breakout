using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using statemanager;

namespace Atari_Breakout;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private const int screenWidth = 480;
    private const int screenHeight = 360;
    private const int framerate = 60;
    private SpriteFont font;
    private SpriteFont smallFont;
    private Texture2D blankTexture;
    private Texture2D heartSprite;
    private StateManager stateManager;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        //setting screen dimensions
        _graphics.PreferredBackBufferWidth = screenWidth;
        _graphics.PreferredBackBufferHeight = screenHeight;
        _graphics.ApplyChanges();

        //capping framerate
        TargetElapsedTime = TimeSpan.FromMilliseconds(1000 / framerate);
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        stateManager = new StateManager(screenWidth, screenHeight);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        //loading fonts
        font = Content.Load<SpriteFont>("BreakoutFont");
        smallFont = Content.Load<SpriteFont>("BreakoutFontSmall");

        //creating blank texture
        blankTexture = new Texture2D(GraphicsDevice, 1, 1);
        blankTexture.SetData(new[] { Color.White });

        //loading heart sprite
        heartSprite = Content.Load<Texture2D>("HeartSprite");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        stateManager.Update(deltaTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        stateManager.Draw(_spriteBatch, font, smallFont, blankTexture, heartSprite);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
