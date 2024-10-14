using menustate;
using gamestate;
using Microsoft.Xna.Framework.Graphics;
using palette;
using pausetstate;

namespace statemanager;

class StateManager
{
    private Palette colourPalette;
    private MenuState menu;
    private GameState game;
    private PausetState pause;
    private string gamestate;
    public StateManager(int sw, int sh)
    {
        //initializing palette
        colourPalette = new Palette();

        //initializing states
        menu = new MenuState(sw, sh);
        game = new GameState(sw, sh);

        //setting starting state
        var startingState = "menu";
        gamestate = startingState;
    }

    public void Update(float deltaTime)
    {
        //menu state update and resetting game on new game
        if (gamestate == "menu" || gamestate == "lose")
        {
            gamestate = menu.Update(gamestate, colourPalette);
            if (gamestate == "game")
            {
                //refreshing game and resetting score and speed
                game.Reset();
            }
        }

        //game state update
        if (gamestate == "game")
        {
            gamestate = game.Update(gamestate, deltaTime);
            if (gamestate == "pause")
            {
                pause = new PausetState(0.5f);
            }
        }

        if (gamestate == "pause")
        {
            gamestate = pause.Update(deltaTime);
        }
    }

    public void Draw(SpriteBatch _spriteBatch, SpriteFont font, SpriteFont smallFont, Texture2D blankTexture, Texture2D heartSprite)
    {
        //drawing menu state
        if (gamestate == "menu")
        {
            menu.DrawMainMenu(_spriteBatch, font);
        }

        //drawing game state
        if (gamestate == "game" || gamestate == "pause")
        {
            game.Draw(_spriteBatch, colourPalette.palette, smallFont, blankTexture, heartSprite);
        }

        //drawing lose state
        if (gamestate == "lose")
        {
            menu.DrawLoseMenu(_spriteBatch, font, smallFont, game.score);
        }
    }
}