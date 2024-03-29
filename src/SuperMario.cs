﻿using LabFour.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LabFour;

public class SuperMario : Game
{
    private GameScreenBase _currentScreen;
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public readonly int screenX;
    public readonly int screenY;

    public SuperMario()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _graphics.PreferredBackBufferWidth = 800;
        _graphics.PreferredBackBufferHeight = 480;

        screenX = _graphics.PreferredBackBufferWidth;
        screenY = _graphics.PreferredBackBufferHeight;

        _graphics.ApplyChanges();
    }

    protected override void Initialize()
    {
        _currentScreen = new StartScreen(this);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _currentScreen.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        if (
            GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
            || Keyboard.GetState().IsKeyDown(Keys.Escape)
        )
            Exit();

        _currentScreen.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _currentScreen.Draw(_spriteBatch);

        base.Draw(gameTime);
    }

    public void ChangeScreen(GameScreenBase newScreen)
    {
        // Cleaner or transitions, if necessary
        // ...

        // Load new content
        newScreen.LoadContent();

        // Change to the new screen
        _currentScreen = newScreen;
    }
}
